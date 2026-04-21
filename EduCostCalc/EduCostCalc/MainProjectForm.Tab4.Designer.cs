using System.Drawing;
using System.Windows.Forms;

namespace EduCostCalc
{
    partial class MainForm
    {
        private Panel panelChart1;
        private Panel panelChart2;
        private ComboBox cboChartType;
        private Button btnRefreshCharts;

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

            var lblChartHint = new Label
            {
                AutoSize = true,
                Location = new Point(10, 10),
                Text = "Выберите тип отображения:",
                Font = new Font("Segoe UI", 9F)
            };

            cboChartType = new ComboBox
            {
                Location = new Point(180, 8),
                Size = new Size(250, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboChartType.Items.AddRange(new[] {
            "Кривые издержек",
            "Прибыль",
            "Оба графика"
        });
            cboChartType.SelectedIndex = 2;

            btnRefreshCharts = new Button
            {
                Location = new Point(450, 5),
                Size = new Size(130, 30),
                Text = "Обновить",
                BackColor = Color.LightBlue
            };
            btnRefreshCharts.Click += BtnRefreshCharts_Click;

            panelControls.Controls.AddRange(new Control[] { lblChartHint, cboChartType, btnRefreshCharts });

            // Панель для графика 1
            panelChart1 = new Panel
            {
                Location = new Point(15, 75),
                Size = new Size(970, 250),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            panelChart1.Paint += PanelChart1_Paint;

            // Панель для графика 2
            panelChart2 = new Panel
            {
                Location = new Point(15, 340),
                Size = new Size(970, 250),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            panelChart2.Paint += PanelChart2_Paint;

            tabPage4.Controls.AddRange(new Control[] { panelControls, panelChart1, panelChart2 });
        }

        private void PanelChart1_Paint(object sender, PaintEventArgs e)
        {
            if (_currentCompany == null) return;

            var maxQ = Math.Max((int)_currentCompany.Production.OutputVolume, 100);
            var step = maxQ > 1000 ? 50 : 10;
            var volumes = Enumerable.Range(0, (maxQ / step) + 1)
                .Select(i => (decimal)(i * step)).ToArray();

            var fc = _currentCompany.FixedCosts.TotalFixedCosts;
            var avc = _currentCompany.VariableCosts.TotalVariableCostPerUnit;
            var price = _currentCompany.Production.PricePerUnit;

            Helpers.ChartDrawer.DrawCostCurves(e.Graphics,
                new Rectangle(10, 10, panelChart1.Width - 20, panelChart1.Height - 20),
                volumes, fc, avc, price);
        }

        private void PanelChart2_Paint(object sender, PaintEventArgs e)
        {
            if (_currentCompany == null) return;

            var maxQ = Math.Max((int)_currentCompany.Production.OutputVolume, 100);
            var step = maxQ > 1000 ? 50 : 10;
            var volumes = Enumerable.Range(0, (maxQ / step) + 1)
                .Select(i => (decimal)(i * step)).ToArray();

            var fc = _currentCompany.FixedCosts.TotalFixedCosts;
            var avc = _currentCompany.VariableCosts.TotalVariableCostPerUnit;
            var price = _currentCompany.Production.PricePerUnit;

            Helpers.ChartDrawer.DrawProfitChart(e.Graphics,
                new Rectangle(10, 10, panelChart2.Width - 20, panelChart2.Height - 20),
                volumes, fc, avc, price);
        }
    }
}