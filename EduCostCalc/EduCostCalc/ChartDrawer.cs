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

            // Сетка
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

            // Оси координат
            using (var axisPen = new Pen(Color.Black, 2))
            {
                g.DrawLine(axisPen, bounds.Left, bounds.Bottom, bounds.Right, bounds.Bottom);
                g.DrawLine(axisPen, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom);
            }

            var maxQ = volumes[^1];
            var maxRevenue = price * maxQ;
            var maxCost = fc + (avc * maxQ);
            var maxVal = Math.Max(maxRevenue, maxCost) * 1.1m;
            if (maxVal == 0) maxVal = 100m;

            // Функции масштабирования
            double ScaleX(decimal q) => bounds.Left + (double)(q / maxQ) * bounds.Width * 0.82;
            double ScaleY(decimal value) => bounds.Bottom - (double)(value / maxVal) * bounds.Height;

            // 1. FC (Постоянные издержки) - Красный пунктир
            using (var pen = new Pen(Color.Red, 2) { DashStyle = DashStyle.Dash })
            {
                g.DrawLine(pen, (int)ScaleX(volumes[0]), (int)ScaleY(fc),
                               (int)ScaleX(volumes[^1]), (int)ScaleY(fc));
            }

            // 2. VC (Переменные издержки) - Синий
            // 3. TC (Совокупные издержки) - Зеленый
            using (var vcPen = new Pen(Color.Blue, 2))
            using (var tcPen = new Pen(Color.Green, 3))
            {
                for (int i = 1; i < volumes.Length; i++)
                {
                    var q1 = volumes[i - 1];
                    var q2 = volumes[i];

                    g.DrawLine(vcPen, (int)ScaleX(q1), (int)ScaleY(avc * q1),
                                         (int)ScaleX(q2), (int)ScaleY(avc * q2));
                    g.DrawLine(tcPen, (int)ScaleX(q1), (int)ScaleY(fc + avc * q1),
                                         (int)ScaleX(q2), (int)ScaleY(fc + avc * q2));
                }
            }

            // 4. TR (Выручка) - Оранжевый жирный
            using (var trPen = new Pen(Color.DarkOrange, 3))
            {
                g.DrawLine(trPen, (int)ScaleX(volumes[0]), (int)ScaleY(0),
                                     (int)ScaleX(volumes[^1]), (int)ScaleY(price * maxQ));
            }

            // 5. ТОЧКА БЕЗУБЫТОЧНОСТИ (BEP)
            // BEP (шт) = FC / (P - AVC)
            if (price > avc)
            {
                decimal bepQ = fc / (price - avc);

                // Рисуем только если точка попадает в видимую область графика
                if (bepQ <= maxQ && bepQ >= 0)
                {
                    // Вертикальная пунктирная линия (Magenta)
                    using (var bepPen = new Pen(Color.Magenta, 2) { DashStyle = DashStyle.DashDot })
                    {
                        int xBep = (int)ScaleX(bepQ);
                        g.DrawLine(bepPen, xBep, bounds.Top, xBep, bounds.Bottom);
                    }

                    // Маркер точки пересечения (круг)
                    int xBepPixel = (int)ScaleX(bepQ);
                    int yBepPixel = (int)ScaleY(price * bepQ); // TR = TC в этой точке

                    using (var markerPen = new Pen(Color.Magenta, 3))
                    {
                        g.DrawEllipse(markerPen, xBepPixel - 6, yBepPixel - 6, 12, 12);
                    }

                    // Подпись BEP
                    using (var font = new Font("Segoe UI", 8F, FontStyle.Bold))
                    using (var brush = new SolidBrush(Color.Magenta))
                    {
                        g.DrawString("BEP", font, brush, xBepPixel + 8, yBepPixel - 15);
                        g.DrawString($"Q={bepQ:N0}", new Font("Segoe UI", 7F), brush, xBepPixel + 8, yBepPixel - 2);
                    }
                }
            }

            // Подписи осей
            using (var font = new Font("Segoe UI", 9F))
            using (var brush = new SolidBrush(Color.Black))
            {
                g.DrawString("Q (объем выпуска, шт.)", font, brush, bounds.Right - 140, bounds.Bottom + 25);
                g.DrawString("Издержки / Выручка (руб.)", font, brush, bounds.Left + 5, bounds.Top - 35);
            }

            // Легенда
            if (legendItems != null && legendItems.Length > 0)
                DrawLegend(g, bounds, legendItems);
        }

        public static void DrawProfitChart(Graphics g, Rectangle bounds,
            decimal[] volumes, decimal fc, decimal avc, decimal price,
            LegendItem[] legendItems = null)
        {
            g.Clear(Color.White);

            // Сетка
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

            // Оси координат
            using (var axisPen = new Pen(Color.Black, 2))
            {
                // Горизонтальная ось (линия нулевой прибыли)
                g.DrawLine(axisPen, bounds.Left, bounds.Top + bounds.Height / 2,
                    bounds.Right, bounds.Top + bounds.Height / 2);
                // Вертикальная ось
                g.DrawLine(axisPen, bounds.Left, bounds.Top, bounds.Left, bounds.Bottom);
            }

            var maxQ = volumes[^1];
            var maxProfit = Math.Max(
                Math.Abs((decimal)(price - avc) * volumes[0] - fc),
                Math.Abs((decimal)(price - avc) * maxQ - fc));
            var scale = maxProfit * 1.1m;
            if (scale == 0) scale = 100m;

            // Функции масштабирования
            double ScaleX(decimal q) => bounds.Left + (double)(q / maxQ) * bounds.Width * 0.82;
            double ScaleY(decimal profit) => bounds.Top + bounds.Height / 2 -
                (double)(profit / scale) * bounds.Height / 2;

            // Линия прибыли
            using (var profitPen = new Pen(Color.DarkBlue, 3))
            {
                for (int i = 1; i < volumes.Length; i++)
                {
                    var q1 = volumes[i - 1];
                    var q2 = volumes[i];
                    var p1 = (price - avc) * q1 - fc;
                    var p2 = (price - avc) * q2 - fc;

                    g.DrawLine(profitPen, (int)ScaleX(q1), (int)ScaleY(p1),
                                            (int)ScaleX(q2), (int)ScaleY(p2));
                }
            }

            // Подпись нулевой линии (точка безубыточности)
            using (var font = new Font("Segoe UI", 8F, FontStyle.Bold))
            using (var brush = new SolidBrush(Color.Red))
            {
                g.DrawString("Зона безубыточности (Прибыль = 0)", font, brush,
                    bounds.Right - 200, bounds.Top + bounds.Height / 2 + 5);
            }

            // Подписи осей
            using (var font = new Font("Segoe UI", 9F))
            {
                g.DrawString("Q (объем выпуска, шт.)", font, Brushes.Black, bounds.Right - 140, bounds.Bottom + 25);
                g.DrawString("Прибыль / Убыток (руб.)", font, Brushes.Black, bounds.Left + 5, bounds.Top - 30);
            }

            // Легенда
            if (legendItems != null && legendItems.Length > 0)
                DrawLegend(g, bounds, legendItems);
        }

        // Вспомогательный метод отрисовки легенды
        private static void DrawLegend(Graphics g, Rectangle bounds, LegendItem[] items)
        {
            int legendX = bounds.Left + (int)(bounds.Width * 0.83);
            int legendY = bounds.Top + 10;
            int itemHeight = 22;

            using (var font = new Font("Segoe UI", 8F))
            using (var titleFont = new Font("Segoe UI", 8.5F, FontStyle.Bold))
            using (var brush = new SolidBrush(Color.Black))
            {
                // Заголовок легенды
                g.DrawString("Условные обозначения", titleFont, brush, legendX, legendY);
                legendY += 18;

                // Элементы легенды
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