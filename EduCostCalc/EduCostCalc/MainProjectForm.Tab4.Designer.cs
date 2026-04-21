using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EduCostCalc
{
    partial class MainForm
    {
        private Chart chartCostCurves;
        private Chart chartProfitCurves;
        private ComboBox cboChartType;
        private Button btnRefreshCharts;
        private Label lblChartHint;

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

            // === Панель управления ===
            var panelControls = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                Padding = new Padding(10)
            };

            lblChartHint = new Label
            {
                AutoSize = true,
                Location = new Point(10, 10),
                Text = "Выберите тип отображения:",
                Font = new Font("Segoe UI", 9F)
            };

            cboChartType = new ComboBox
            {
                Location = new Point(180, 8),
                Size = new Size(200, 23),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboChartType.Items.AddRange(new[] {
                "Кривые издержек (краткосрочный период)",
                "Выручка и прибыль",
                "Точка безубыточности",
                "Все кривые (сводный)"
            });
            cboChartType.SelectedIndex = 0;

            btnRefreshCharts = new Button
            {
                Location = new Point(400, 5),
                Size = new Size(120, 30),
                Text = "Обновить графики",
                BackColor = Color.LightBlue
            };
            btnRefreshCharts.Click += BtnRefreshCharts_Click;

            panelControls.Controls.AddRange(new Control[] { lblChartHint, cboChartType, btnRefreshCharts });

            // === График 1: Кривые издержек ===
            chartCostCurves = new Chart
            {
                Size = new Size(970, 260),
                Location = new Point(15, 75),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            SetupChart(chartCostCurves, "Издержки производства", "Объем выпуска (Q)", "Издержки (руб.)");

            // === График 2: Прибыль и выручка ===
            chartProfitCurves = new Chart
            {
                Size = new Size(970, 260),
                Location = new Point(15, 345),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right
            };
            SetupChart(chartProfitCurves, "Выручка и прибыль", "Объем выпуска (Q)", "Сумма (руб.)");

            // === Добавление на вкладку ===
            tabPage4.Controls.AddRange(new Control[] { panelControls, chartCostCurves, chartProfitCurves });
        }

        private void SetupChart(Chart chart, string title, string xAxis, string yAxis)
        {
            chart.Titles.Clear();
            chart.Titles.Add(new Title(title, Docking.Top, new Font("Segoe UI", 11F, FontStyle.Bold), Color.Black));

            chart.ChartAreas.Clear();
            var area = new ChartArea
            {
                AxisX = { Title = xAxis, TitleFont = new Font("Segoe UI", 9F), LabelStyle = { Font = new Font("Segoe UI", 8F) } },
                AxisY = { Title = yAxis, TitleFont = new Font("Segoe UI", 9F), LabelStyle = { Font = new Font("Segoe UI", 8F), Format = "N0" } },
                CursorX = { IsUserSelectionEnabled = true, SelectionColor = Color.LightBlue },
                CursorY = { IsUserSelectionEnabled = true },
                AxisX = { IsMarginVisible = false },
                BackColor = Color.White,
                BorderColor = Color.LightGray,
                BorderWidth = 1
            };
            area.AxisX.MajorGrid.LineColor = Color.LightGray;
            area.AxisY.MajorGrid.LineColor = Color.LightGray;
            chart.ChartAreas.Add(area);

            chart.Legends.Clear();
            var legend = new Legend
            {
                Docking = Docking.Right,
                Font = new Font("Segoe UI", 8F),
                BorderColor = Color.LightGray,
                BorderWidth = 1
            };
            chart.Legends.Add(legend);

            chart.Series.Clear();
            chart.ChartType = SeriesChartType.Line;
            chart.AntiAliasing = AntiAliasing.All;
        }
    }
}