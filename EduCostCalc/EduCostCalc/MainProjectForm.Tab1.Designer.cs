namespace EduCostCalc
{
    partial class MainForm
    {
        private Label lblProductionGroup, lblOutputVolume, lblPricePerUnit;
        private NumericUpDown nudOutputVolume, nudPricePerUnit;
        private Label lblVariableCostsGroup, lblRawMaterials, lblEnergyTransport, lblPieceworkWage;
        private NumericUpDown nudRawMaterials, nudEnergyTransport, nudPieceworkWage;
        private Label lblFixedCostsGroup, lblRent, lblDepreciation, lblSalaryAdmin, lblUtilities, lblLoanInterest;
        private NumericUpDown nudRent, nudDepreciation, nudSalaryAdmin, nudUtilities, nudLoanInterest;
        private Label lblTaxSettingsGroup, lblSocialRate, lblProfitTaxRate;
        private NumericUpDown nudSocialRate, nudProfitTaxRate;
        private Button btnSaveData, btnCalculate;

        private void InitializeTab1()
        {
            tabPage1.AutoScroll = true;
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(15);
            tabPage1.Size = new Size(1016, 622);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "1. Ввод данных";
            tabPage1.UseVisualStyleBackColor = true;

            lblProductionGroup = new Label() { AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(15, 15), Text = "Объём и цена" };
            lblOutputVolume = new Label() { AutoSize = true, Location = new Point(15, 50), Text = "Объем выпуска Q (шт): " };
            nudOutputVolume = new NumericUpDown() { Location = new Point(250, 47), Size = new Size(150, 23), ThousandsSeparator = true, Maximum = 1000000000 };

            lblPricePerUnit = new Label() { AutoSize = true, Location = new Point(15, 85), Text = "Цена реализации P (руб): " };
            nudPricePerUnit = new NumericUpDown() { Location = new Point(250, 82), Size = new Size(150, 23), DecimalPlaces = 2, ThousandsSeparator = true, Maximum = 1000000000 };

            lblVariableCostsGroup = new Label() { AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(15, 130), Text = "Переменные затраты на единицу" };
            lblRawMaterials = new Label() { AutoSize = true, Location = new Point(15, 165), Text = "Сырье и материалы (руб/шт): " };
            nudRawMaterials = new NumericUpDown() { Location = new Point(250, 162), Size = new Size(150, 23), DecimalPlaces = 2, ThousandsSeparator = true, Maximum = 1000000000 };

            lblEnergyTransport = new Label() { AutoSize = true, Location = new Point(15, 200), Text = "Энергия/транспорт (руб/шт): " };
            nudEnergyTransport = new NumericUpDown() { Location = new Point(250, 197), Size = new Size(150, 23), DecimalPlaces = 2, ThousandsSeparator = true, Maximum = 1000000000 };

            lblPieceworkWage = new Label() { AutoSize = true, Location = new Point(15, 235), Text = "Сдельная ЗП (руб/шт): " };
            nudPieceworkWage = new NumericUpDown() { Location = new Point(250, 232), Size = new Size(150, 23), DecimalPlaces = 2, ThousandsSeparator = true, Maximum = 1000000000 };

            lblFixedCostsGroup = new Label() { AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(15, 280), Text = "Постоянные затраты (месяц)" };
            lblRent = new Label() { AutoSize = true, Location = new Point(15, 315), Text = "Аренда помещения: " };
            nudRent = new NumericUpDown() { Location = new Point(250, 312), Size = new Size(150, 23), DecimalPlaces = 2, ThousandsSeparator = true, Maximum = 1000000000 };

            lblDepreciation = new Label() { AutoSize = true, Location = new Point(15, 350), Text = "Амортизация оборудования: " };
            nudDepreciation = new NumericUpDown() { Location = new Point(250, 347), Size = new Size(150, 23), DecimalPlaces = 2, ThousandsSeparator = true, Maximum = 1000000000 };

            lblSalaryAdmin = new Label() { AutoSize = true, Location = new Point(15, 385), Text = "Окладная часть ЗП (упр., охрана): " };
            nudSalaryAdmin = new NumericUpDown() { Location = new Point(250, 382), Size = new Size(150, 23), DecimalPlaces = 2, ThousandsSeparator = true, Maximum = 1000000000 };

            lblUtilities = new Label() { AutoSize = true, Location = new Point(15, 420), Text = "Коммунальные услуги: " };
            nudUtilities = new NumericUpDown() { Location = new Point(250, 417), Size = new Size(150, 23), DecimalPlaces = 2, ThousandsSeparator = true, Maximum = 1000000000 };

            lblLoanInterest = new Label() { AutoSize = true, Location = new Point(15, 455), Text = "Проценты по кредитам: " };
            nudLoanInterest = new NumericUpDown() { Location = new Point(250, 452), Size = new Size(150, 23), DecimalPlaces = 2, ThousandsSeparator = true, Maximum = 1000000000 };

            lblTaxSettingsGroup = new Label() { AutoSize = true, Font = new Font("Segoe UI", 10F, FontStyle.Bold), Location = new Point(15, 500), Text = "Доп. настройки" };
            lblSocialRate = new Label() { AutoSize = true, Location = new Point(15, 535), Text = "Ставка соц. отчислений (%): " };
            nudSocialRate = new NumericUpDown() { Location = new Point(250, 532), Size = new Size(150, 23), Value = 38.5M, Maximum = 100, DecimalPlaces = 1 };

            lblProfitTaxRate = new Label() { AutoSize = true, Location = new Point(15, 570), Text = "Налог на прибыль (%): " };
            nudProfitTaxRate = new NumericUpDown() { Location = new Point(250, 567), Size = new Size(150, 23), Value = 20, Maximum = 100, DecimalPlaces = 1 };

            btnSaveData = new Button() { Location = new Point(15, 610), Size = new Size(150, 30), Text = "Сохранить данные" };
            btnSaveData.Click += BtnSaveData_Click;

            btnCalculate = new Button() { Location = new Point(180, 610), Size = new Size(150, 30), Text = "Рассчитать" };
            btnCalculate.Click += BtnCalculate_Click;

            // Добавление на вкладку
            tabPage1.Controls.AddRange(new Control[] {
                lblProductionGroup, lblOutputVolume, nudOutputVolume, lblPricePerUnit, nudPricePerUnit,
                lblVariableCostsGroup, lblRawMaterials, nudRawMaterials, lblEnergyTransport, nudEnergyTransport,
                lblPieceworkWage, nudPieceworkWage, lblFixedCostsGroup, lblRent, nudRent, lblDepreciation,
                nudDepreciation, lblSalaryAdmin, nudSalaryAdmin, lblUtilities, nudUtilities, lblLoanInterest,
                nudLoanInterest, lblTaxSettingsGroup, lblSocialRate, nudSocialRate, lblProfitTaxRate,
                nudProfitTaxRate, btnSaveData, btnCalculate
            });
        }
    }
}