using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace EduCostCalc.Helpers
{
    public static class ChartDrawer
    {
        // === Структура для элемента легенды ===
        public struct LegendItem
        {
            public string Label;
            public Color Color;
            public int LineWidth;
            public DashStyle DashStyle;
        }

        public static void DrawCostCurves(Graphics g, Rectangle bounds,
            decimal[] volumes, decimal fc, decimal avc, decimal price,
            LegendItem[] legendItems = null)
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
                g.DrawLine(axisPen, bounds.Left, bounds.Bottom, bounds.Right, bounds.Bottom);
                g.DrawLine(axisPen, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom);
            }

            var maxQ = volumes[^1];
            var maxCost = fc + (avc * maxQ) * 1.1m;
            if (maxCost == 0) maxCost = 100m;

            double ScaleX(decimal q) => bounds.Left + (double)(q / maxQ) * bounds.Width * 0.82;
            double ScaleY(decimal value) => bounds.Bottom - (double)(value / maxCost) * bounds.Height;

            // FC
            using (var pen = new Pen(Color.Red, 2))
                g.DrawLine(pen, (int)ScaleX(volumes[0]), (int)ScaleY(fc),
                               (int)ScaleX(volumes[^1]), (int)ScaleY(fc));

            // VC и TC
            using (var vcPen = new Pen(Color.Blue, 2))
            using (var tcPen = new Pen(Color.Green, 3))
            {
                for (int i = 1; i < volumes.Length; i++)
                {
                    // ✅ ИСПРАВЛЕНИЕ: разделили объявление var на две строки
                    var q1 = volumes[i - 1];
                    var q2 = volumes[i];

                    g.DrawLine(vcPen, (int)ScaleX(q1), (int)ScaleY(avc * q1),
                                         (int)ScaleX(q2), (int)ScaleY(avc * q2));
                    g.DrawLine(tcPen, (int)ScaleX(q1), (int)ScaleY(fc + avc * q1),
                                         (int)ScaleX(q2), (int)ScaleY(fc + avc * q2));
                }
            }

            // Подписи осей
            using (var font = new Font("Segoe UI", 9F))
            using (var brush = new SolidBrush(Color.Black))
            {
                g.DrawString("Q (объем выпуска)", font, brush, bounds.Right - 90, bounds.Bottom + 25);
                g.DrawString("Издержки (руб.)", font, brush, bounds.Left + 5, bounds.Top - 35);
            }

            // ✅ Легенда (справа)
            if (legendItems != null && legendItems.Length > 0)
                DrawLegend(g, bounds, legendItems);
        }

        public static void DrawProfitChart(Graphics g, Rectangle bounds,
            decimal[] volumes, decimal fc, decimal avc, decimal price,
            LegendItem[] legendItems = null)
        {
            g.Clear(Color.White);

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

            using (var axisPen = new Pen(Color.Black, 2))
            {
                g.DrawLine(axisPen, bounds.Left, bounds.Top + bounds.Height / 2,
                    bounds.Right, bounds.Top + bounds.Height / 2);
                g.DrawLine(axisPen, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom);
            }

            var maxQ = volumes[^1];
            var maxProfit = Math.Max(
                Math.Abs((decimal)(price - avc) * volumes[0] - fc),
                Math.Abs((decimal)(price - avc) * maxQ - fc));
            var scale = maxProfit * 1.1m;
            if (scale == 0) scale = 100m;

            double ScaleX(decimal q) => bounds.Left + (double)(q / maxQ) * bounds.Width * 0.82;
            double ScaleY(decimal profit) => bounds.Top + bounds.Height / 2 -
                (double)(profit / scale) * bounds.Height / 2;

            using (var profitPen = new Pen(Color.DarkBlue, 3))
            {
                for (int i = 1; i < volumes.Length; i++)
                {
                    // ✅ ИСПРАВЛЕНИЕ: разделили все var-объявления
                    var q1 = volumes[i - 1];
                    var q2 = volumes[i];
                    var p1 = (price - avc) * q1 - fc;
                    var p2 = (price - avc) * q2 - fc;

                    g.DrawLine(profitPen, (int)ScaleX(q1), (int)ScaleY(p1),
                                           (int)ScaleX(q2), (int)ScaleY(p2));
                }
            }

            using (var font = new Font("Segoe UI", 9F))
            {
                g.DrawString("Прибыль / Убыток", font, Brushes.Black, bounds.Left + 5, bounds.Top - 30);
            }

            if (legendItems != null && legendItems.Length > 0)
                DrawLegend(g, bounds, legendItems);
        }

        // ✅ Вспомогательный метод отрисовки легенды
        private static void DrawLegend(Graphics g, Rectangle bounds, LegendItem[] items)
        {
            int legendX = bounds.Left + (int)(bounds.Width * 0.83); int legendY = bounds.Top + 10;
            int itemHeight = 22;

            using (var font = new Font("Segoe UI", 8F))
            using (var titleFont = new Font("Segoe UI", 8.5F, FontStyle.Bold))
            using (var brush = new SolidBrush(Color.Black))
            {
                // Заголовок легенды
                g.DrawString("Условные обозначения", titleFont, brush, legendX, legendY);
                legendY += 18;

                // Элементы
                foreach (var item in items)
                {
                    // Линия-образец
                    using (var pen = new Pen(item.Color, item.LineWidth) { DashStyle = item.DashStyle })
                        g.DrawLine(pen, legendX, legendY + 8, legendX + 30, legendY + 8);

                    // Текст
                    g.DrawString(item.Label, font, brush, legendX + 35, legendY + 2);
                    legendY += itemHeight;
                }
            }
        }
    }
}