using System;
using System.Drawing;
using System.Windows.Forms;

namespace EduCostCalc.Helpers
{
    public static class ChartDrawer
    {
        public static void DrawCostCurves(Graphics g, Rectangle bounds,
            decimal[] volumes, decimal fc, decimal avc, decimal price)
        {
            // Очистка фона
            g.Clear(Color.White);

            // Сетки
            using (var gridPen = new Pen(Color.LightGray, 1))
            {
                for (int i = 0; i <= 10; i++)
                {
                    int x = bounds.Left + (bounds.Width * i / 10);
                    int y = bounds.Top + (bounds.Height * i / 10);
                    g.DrawLine(gridPen, x, bounds.Top, x, bounds.Bottom);
                    g.DrawLine(gridPen, bounds.Left, y, bounds.Right, y);
                }
            }

            // Оси
            using (var axisPen = new Pen(Color.Black, 2))
            {
                g.DrawLine(axisPen, bounds.Left, bounds.Bottom, bounds.Right, bounds.Bottom); // X
                g.DrawLine(axisPen, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom); // Y
            }

            // Масштаб
            var maxQ = volumes[^1];
            var maxCost = fc + (avc * maxQ) * 1.1m;

            // ИСПРАВЛЕНИЕ: Если maxCost = 0 (пустая форма), задаем дефолтный масштаб,
            // чтобы избежать деления на ноль в функции ScaleY
            if (maxCost == 0) maxCost = 100m;

            double ScaleX(decimal q) => bounds.Left + (double)(q / maxQ) * bounds.Width;
            double ScaleY(decimal value) => bounds.Bottom - (double)(value / maxCost) * bounds.Height;

            // Рисуем FC (горизонтальная линия)
            using (var fcPen = new Pen(Color.Red, 2))
            {
                g.DrawLine(fcPen,
                    (int)ScaleX(volumes[0]), (int)ScaleY(fc),
                    (int)ScaleX(volumes[^1]), (int)ScaleY(fc));
            }

            // Рисуем VC и TC
            using (var vcPen = new Pen(Color.Blue, 2))
            using (var tcPen = new Pen(Color.Green, 3))
            {
                for (int i = 1; i < volumes.Length; i++)
                {
                    var q1 = volumes[i - 1];
                    var q2 = volumes[i];

                    g.DrawLine(vcPen,
                        (int)ScaleX(q1), (int)ScaleY(avc * q1),
                        (int)ScaleX(q2), (int)ScaleY(avc * q2));

                    g.DrawLine(tcPen,
                        (int)ScaleX(q1), (int)ScaleY(fc + avc * q1),
                        (int)ScaleX(q2), (int)ScaleY(fc + avc * q2));
                }
            }

            // Подписи
            using (var font = new Font("Segoe UI", 9F))
            using (var brush = new SolidBrush(Color.Black))
            {
                g.DrawString("Q (объем)", font, brush, bounds.Right - 80, bounds.Bottom + 5);
                g.DrawString("Издержки", font, brush, bounds.Left + 5, bounds.Top - 20);
            }
        }

        public static void DrawProfitChart(Graphics g, Rectangle bounds,
            decimal[] volumes, decimal fc, decimal avc, decimal price)
        {
            g.Clear(Color.White);

            // Сетки
            using (var gridPen = new Pen(Color.LightGray, 1))
            {
                for (int i = 0; i <= 10; i++)
                {
                    int x = bounds.Left + (bounds.Width * i / 10);
                    int y = bounds.Top + (bounds.Height * i / 10);
                    g.DrawLine(gridPen, x, bounds.Top, x, bounds.Bottom);
                    g.DrawLine(gridPen, bounds.Left, y, bounds.Right, y);
                }
            }

            // Оси
            using (var axisPen = new Pen(Color.Black, 2))
            {
                // Ось X (нулевая прибыль) по центру, если позволяет масштаб
                g.DrawLine(axisPen, bounds.Left, bounds.Top + bounds.Height / 2,
                    bounds.Right, bounds.Top + bounds.Height / 2);
                g.DrawLine(axisPen, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom); // Y
            }

            var maxQ = volumes[^1];
            var maxProfit = Math.Max(
                Math.Abs((decimal)(price - avc) * volumes[0] - fc),
                Math.Abs((decimal)(price - avc) * maxQ - fc));
            var scale = maxProfit * 1.1m;

            // ИСПРАВЛЕНИЕ: Если scale = 0 (нет прибыли/убытков), задаем дефолт
            if (scale == 0) scale = 100m;

            double ScaleX(decimal q) => bounds.Left + (double)(q / maxQ) * bounds.Width;
            double ScaleY(decimal profit) => bounds.Top + bounds.Height / 2 -
                (double)(profit / scale) * bounds.Height / 2;

            // Рисуем линию прибыли
            using (var profitPen = new Pen(Color.DarkBlue, 3))
            {
                for (int i = 1; i < volumes.Length; i++)
                {
                    var q1 = volumes[i - 1];
                    var q2 = volumes[i];
                    var profit1 = (price - avc) * q1 - fc;
                    var profit2 = (price - avc) * q2 - fc;

                    g.DrawLine(profitPen,
                        (int)ScaleX(q1), (int)ScaleY(profit1),
                        (int)ScaleX(q2), (int)ScaleY(profit2));
                }
            }

            // Подписи
            using (var font = new Font("Segoe UI", 9F))
            {
                g.DrawString("Прибыль", font, Brushes.Black, bounds.Left + 5, bounds.Top + 5);
                g.DrawString("Убыток", font, Brushes.Black, bounds.Left + 5, bounds.Bottom - 20);
            }
        }


    }
}