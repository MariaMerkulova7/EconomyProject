using System.Drawing;
using System.Windows.Forms;

namespace EduCostCalc
{
    partial class MainForm
    {
        private Panel panelCostCurves;
        private Panel panelProfitCurves;

        private void InitializeTab4()
        {
            tabPage4.AutoScroll = true;
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(15);
            tabPage4.Size = new Size(1016, 622);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "4. Графики";
            tabPage4.UseVisualStyleBackColor = true;

            // Панель управления
            var panelControls = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(10)
            };

            // Панель для графика издержек
            panelCostCurves = new Panel
            {
                Location = new Point(15, 75),
                Size = new Size(970, 250),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            panelCostCurves.Paint += PanelCostCurves_Paint;

            // Панель для графика прибыли
            panelProfitCurves = new Panel
            {
                Location = new Point(15, 340),
                Size = new Size(970, 250),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            panelProfitCurves.Paint += PanelProfitCurves_Paint;

            tabPage4.Controls.AddRange(new Control[] { panelControls, panelCostCurves, panelProfitCurves });
        }

        private void PanelCostCurves_Paint(object sender, PaintEventArgs e)
        {
            if (_currentCompany == null) return;

            var maxQ = Math.Max((int)_currentCompany.Production.OutputVolume, 100);
            var step = maxQ > 1000 ? 50 : 10;
            var volumes = Enumerable.Range(0, (maxQ / step) + 1)
                .Select(i => (decimal)(i * step)).ToArray();

            var fc = _currentCompany.FixedCosts.TotalFixedCosts;
            var avc = _currentCompany.VariableCosts.TotalVariableCostPerUnit;
            var price = _currentCompany.Production.PricePerUnit;

            // ✅ Легенда для графика издержек
            var legend = new[]
            {
            new Helpers.ChartDrawer.LegendItem { Label = "FC (Постоянные)", Color = Color.Red, LineWidth = 2, DashStyle = System.Drawing.Drawing2D.DashStyle.Solid },
            new Helpers.ChartDrawer.LegendItem { Label = "VC (Переменные)", Color = Color.Blue, LineWidth = 2, DashStyle = System.Drawing.Drawing2D.DashStyle.Solid },
            new Helpers.ChartDrawer.LegendItem { Label = "TC (Совокупные)", Color = Color.Green, LineWidth = 3, DashStyle = System.Drawing.Drawing2D.DashStyle.Solid }
        };

            Helpers.ChartDrawer.DrawCostCurves(e.Graphics,
                new Rectangle(10, 10, panelCostCurves.Width - 20, panelCostCurves.Height - 20),
                volumes, fc, avc, price, legend);
        }

        private void PanelProfitCurves_Paint(object sender, PaintEventArgs e)
        {
            if (_currentCompany == null) return;

            var maxQ = Math.Max((int)_currentCompany.Production.OutputVolume, 100);
            var step = maxQ > 1000 ? 50 : 10;
            var volumes = Enumerable.Range(0, (maxQ / step) + 1)
                .Select(i => (decimal)(i * step)).ToArray();

            var fc = _currentCompany.FixedCosts.TotalFixedCosts;
            var avc = _currentCompany.VariableCosts.TotalVariableCostPerUnit;
            var price = _currentCompany.Production.PricePerUnit;

            // ✅ Легенда для графика прибыли
            var legend = new[]
            {
            new Helpers.ChartDrawer.LegendItem { Label = "Прибыль", Color = Color.DarkBlue, LineWidth = 3, DashStyle = System.Drawing.Drawing2D.DashStyle.Solid }
        };

            Helpers.ChartDrawer.DrawProfitChart(e.Graphics,
                new Rectangle(10, 10, panelProfitCurves.Width - 20, panelProfitCurves.Height - 20),
                volumes, fc, avc, price, legend);
        }
    }
}