namespace EduCostCalc
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            tabPage2 = new TabPage();
            tabPage3 = new TabPage();
            tabPage4 = new TabPage();

            // Элементы управления - NumericUpDown вместо TextBox
            lblProductionGroup = new Label();
            lblOutputVolume = new Label();
            nudOutputVolume = new NumericUpDown();
            lblPricePerUnit = new Label();
            nudPricePerUnit = new NumericUpDown();

            lblVariableCostsGroup = new Label();
            lblRawMaterials = new Label();
            nudRawMaterials = new NumericUpDown();
            lblEnergyTransport = new Label();
            nudEnergyTransport = new NumericUpDown();
            lblPieceworkWage = new Label();
            nudPieceworkWage = new NumericUpDown();

            lblFixedCostsGroup = new Label();
            lblRent = new Label();
            nudRent = new NumericUpDown();
            lblDepreciation = new Label();
            nudDepreciation = new NumericUpDown();
            lblSalaryAdmin = new Label();
            nudSalaryAdmin = new NumericUpDown();
            lblUtilities = new Label();
            nudUtilities = new NumericUpDown();
            lblLoanInterest = new Label();
            nudLoanInterest = new NumericUpDown();

            lblTaxSettingsGroup = new Label();
            lblSocialRate = new Label();
            nudSocialRate = new NumericUpDown();
            lblProfitTaxRate = new Label();
            nudProfitTaxRate = new NumericUpDown();

            btnSaveData = new Button();
            btnCalculate = new Button();

            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            SuspendLayout();

            // tabControl1
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1024, 650);
            tabControl1.TabIndex = 0;

            // tabPage1 - Ввод данных
            tabPage1.AutoScroll = true;
            tabPage1.Controls.Add(btnCalculate);
            tabPage1.Controls.Add(btnSaveData);
            tabPage1.Controls.Add(nudProfitTaxRate);
            tabPage1.Controls.Add(lblProfitTaxRate);
            tabPage1.Controls.Add(nudSocialRate);
            tabPage1.Controls.Add(lblSocialRate);
            tabPage1.Controls.Add(lblTaxSettingsGroup);
            tabPage1.Controls.Add(nudLoanInterest);
            tabPage1.Controls.Add(lblLoanInterest);
            tabPage1.Controls.Add(nudUtilities);
            tabPage1.Controls.Add(lblUtilities);
            tabPage1.Controls.Add(nudSalaryAdmin);
            tabPage1.Controls.Add(lblSalaryAdmin);
            tabPage1.Controls.Add(nudDepreciation);
            tabPage1.Controls.Add(lblDepreciation);
            tabPage1.Controls.Add(nudRent);
            tabPage1.Controls.Add(lblRent);
            tabPage1.Controls.Add(lblFixedCostsGroup);
            tabPage1.Controls.Add(nudPieceworkWage);
            tabPage1.Controls.Add(lblPieceworkWage);
            tabPage1.Controls.Add(nudEnergyTransport);
            tabPage1.Controls.Add(lblEnergyTransport);
            tabPage1.Controls.Add(nudRawMaterials);
            tabPage1.Controls.Add(lblRawMaterials);
            tabPage1.Controls.Add(lblVariableCostsGroup);
            tabPage1.Controls.Add(nudPricePerUnit);
            tabPage1.Controls.Add(lblPricePerUnit);
            tabPage1.Controls.Add(nudOutputVolume);
            tabPage1.Controls.Add(lblOutputVolume);
            tabPage1.Controls.Add(lblProductionGroup);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(15);
            tabPage1.Size = new Size(1016, 622);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Ввод данных";
            tabPage1.UseVisualStyleBackColor = true;

            // tabPage2
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1016, 622);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Расчёт издержек";
            tabPage2.UseVisualStyleBackColor = true;

            // tabPage3
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1016, 622);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Расчёт себестоимости";
            tabPage3.UseVisualStyleBackColor = true;

            // tabPage4
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1016, 622);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Графики";
            tabPage4.UseVisualStyleBackColor = true;

            // lblProductionGroup
            lblProductionGroup.AutoSize = true;
            lblProductionGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProductionGroup.Location = new Point(15, 15);
            lblProductionGroup.Name = "lblProductionGroup";
            lblProductionGroup.Size = new Size(130, 19);
            lblProductionGroup.TabIndex = 0;
            lblProductionGroup.Text = "Объём и цена";

            // lblOutputVolume
            lblOutputVolume.AutoSize = true;
            lblOutputVolume.Location = new Point(15, 50);
            lblOutputVolume.Name = "lblOutputVolume";
            lblOutputVolume.Size = new Size(120, 15);
            lblOutputVolume.TabIndex = 1;
            lblOutputVolume.Text = "Объем выпуска Q:";

            // nudOutputVolume
            nudOutputVolume.Location = new Point(250, 47);
            nudOutputVolume.Name = "nudOutputVolume";
            nudOutputVolume.Size = new Size(150, 23);
            nudOutputVolume.TabIndex = 2;
            nudOutputVolume.Value = 0;
            nudOutputVolume.TextAlign = HorizontalAlignment.Right;
            nudOutputVolume.ThousandsSeparator = true;
            nudOutputVolume.Maximum = 1000000000;

            // lblPricePerUnit
            lblPricePerUnit.AutoSize = true;
            lblPricePerUnit.Location = new Point(15, 85);
            lblPricePerUnit.Name = "lblPricePerUnit";
            lblPricePerUnit.Size = new Size(135, 15);
            lblPricePerUnit.TabIndex = 3;
            lblPricePerUnit.Text = "Цена реализации P:";

            // nudPricePerUnit
            nudPricePerUnit.Location = new Point(250, 82);
            nudPricePerUnit.Name = "nudPricePerUnit";
            nudPricePerUnit.Size = new Size(150, 23);
            nudPricePerUnit.TabIndex = 4;
            nudPricePerUnit.Value = 0;
            nudPricePerUnit.TextAlign = HorizontalAlignment.Right;
            nudPricePerUnit.ThousandsSeparator = true;
            nudPricePerUnit.Maximum = 1000000000;
            nudPricePerUnit.DecimalPlaces = 2;

            // lblVariableCostsGroup
            lblVariableCostsGroup.AutoSize = true;
            lblVariableCostsGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVariableCostsGroup.Location = new Point(15, 130);
            lblVariableCostsGroup.Name = "lblVariableCostsGroup";
            lblVariableCostsGroup.Size = new Size(260, 19);
            lblVariableCostsGroup.TabIndex = 5;
            lblVariableCostsGroup.Text = "Переменные затраты на единицу";

            // lblRawMaterials
            lblRawMaterials.AutoSize = true;
            lblRawMaterials.Location = new Point(15, 165);
            lblRawMaterials.Name = "lblRawMaterials";
            lblRawMaterials.Size = new Size(145, 15);
            lblRawMaterials.TabIndex = 6;
            lblRawMaterials.Text = "Сырье и материалы:";

            // nudRawMaterials
            nudRawMaterials.Location = new Point(250, 162);
            nudRawMaterials.Name = "nudRawMaterials";
            nudRawMaterials.Size = new Size(150, 23);
            nudRawMaterials.TabIndex = 7;
            nudRawMaterials.Value = 0;
            nudRawMaterials.TextAlign = HorizontalAlignment.Right;
            nudRawMaterials.ThousandsSeparator = true;
            nudRawMaterials.Maximum = 1000000000;
            nudRawMaterials.DecimalPlaces = 2;

            // lblEnergyTransport
            lblEnergyTransport.AutoSize = true;
            lblEnergyTransport.Location = new Point(15, 200);
            lblEnergyTransport.Name = "lblEnergyTransport";
            lblEnergyTransport.Size = new Size(140, 15);
            lblEnergyTransport.TabIndex = 8;
            lblEnergyTransport.Text = "Энергия/транспорт:";

            // nudEnergyTransport
            nudEnergyTransport.Location = new Point(250, 197);
            nudEnergyTransport.Name = "nudEnergyTransport";
            nudEnergyTransport.Size = new Size(150, 23);
            nudEnergyTransport.TabIndex = 9;
            nudEnergyTransport.Value = 0;
            nudEnergyTransport.TextAlign = HorizontalAlignment.Right;
            nudEnergyTransport.ThousandsSeparator = true;
            nudEnergyTransport.Maximum = 1000000000;
            nudEnergyTransport.DecimalPlaces = 2;

            // lblPieceworkWage
            lblPieceworkWage.AutoSize = true;
            lblPieceworkWage.Location = new Point(15, 235);
            lblPieceworkWage.Name = "lblPieceworkWage";
            lblPieceworkWage.Size = new Size(125, 15);
            lblPieceworkWage.TabIndex = 10;
            lblPieceworkWage.Text = "Сдельная ЗП:";

            // nudPieceworkWage
            nudPieceworkWage.Location = new Point(250, 232);
            nudPieceworkWage.Name = "nudPieceworkWage";
            nudPieceworkWage.Size = new Size(150, 23);
            nudPieceworkWage.TabIndex = 11;
            nudPieceworkWage.Value = 0;
            nudPieceworkWage.TextAlign = HorizontalAlignment.Right;
            nudPieceworkWage.ThousandsSeparator = true;
            nudPieceworkWage.Maximum = 1000000000;
            nudPieceworkWage.DecimalPlaces = 2;

            // lblFixedCostsGroup
            lblFixedCostsGroup.AutoSize = true;
            lblFixedCostsGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFixedCostsGroup.Location = new Point(15, 280);
            lblFixedCostsGroup.Name = "lblFixedCostsGroup";
            lblFixedCostsGroup.Size = new Size(225, 19);
            lblFixedCostsGroup.TabIndex = 12;
            lblFixedCostsGroup.Text = "Постоянные затраты (месяц)";

            // lblRent
            lblRent.AutoSize = true;
            lblRent.Location = new Point(15, 315);
            lblRent.Name = "lblRent";
            lblRent.Size = new Size(115, 15);
            lblRent.TabIndex = 13;
            lblRent.Text = "Аренда помещения:";

            // nudRent
            nudRent.Location = new Point(250, 312);
            nudRent.Name = "nudRent";
            nudRent.Size = new Size(150, 23);
            nudRent.TabIndex = 14;
            nudRent.Value = 0;
            nudRent.TextAlign = HorizontalAlignment.Right;
            nudRent.ThousandsSeparator = true;
            nudRent.Maximum = 1000000000;
            nudRent.DecimalPlaces = 2;

            // lblDepreciation
            lblDepreciation.AutoSize = true;
            lblDepreciation.Location = new Point(15, 350);
            lblDepreciation.Name = "lblDepreciation";
            lblDepreciation.Size = new Size(175, 15);
            lblDepreciation.TabIndex = 15;
            lblDepreciation.Text = "Амортизация оборудования:";

            // nudDepreciation
            nudDepreciation.Location = new Point(250, 347);
            nudDepreciation.Name = "nudDepreciation";
            nudDepreciation.Size = new Size(150, 23);
            nudDepreciation.TabIndex = 16;
            nudDepreciation.Value = 0;
            nudDepreciation.TextAlign = HorizontalAlignment.Right;
            nudDepreciation.ThousandsSeparator = true;
            nudDepreciation.Maximum = 1000000000;
            nudDepreciation.DecimalPlaces = 2;

            // lblSalaryAdmin
            lblSalaryAdmin.AutoSize = true;
            lblSalaryAdmin.Location = new Point(15, 385);
            lblSalaryAdmin.Name = "lblSalaryAdmin";
            lblSalaryAdmin.Size = new Size(200, 15);
            lblSalaryAdmin.TabIndex = 17;
            lblSalaryAdmin.Text = "Окладная часть ЗП (упр., охрана):";

            // nudSalaryAdmin
            nudSalaryAdmin.Location = new Point(250, 382);
            nudSalaryAdmin.Name = "nudSalaryAdmin";
            nudSalaryAdmin.Size = new Size(150, 23);
            nudSalaryAdmin.TabIndex = 18;
            nudSalaryAdmin.Value = 0;
            nudSalaryAdmin.TextAlign = HorizontalAlignment.Right;
            nudSalaryAdmin.ThousandsSeparator = true;
            nudSalaryAdmin.Maximum = 1000000000;
            nudSalaryAdmin.DecimalPlaces = 2;

            // lblUtilities
            lblUtilities.AutoSize = true;
            lblUtilities.Location = new Point(15, 420);
            lblUtilities.Name = "lblUtilities";
            lblUtilities.Size = new Size(165, 15);
            lblUtilities.TabIndex = 19;
            lblUtilities.Text = "Коммунальные услуги:";

            // nudUtilities
            nudUtilities.Location = new Point(250, 417);
            nudUtilities.Name = "nudUtilities";
            nudUtilities.Size = new Size(150, 23);
            nudUtilities.TabIndex = 20;
            nudUtilities.Value = 0;
            nudUtilities.TextAlign = HorizontalAlignment.Right;
            nudUtilities.ThousandsSeparator = true;
            nudUtilities.Maximum = 1000000000;
            nudUtilities.DecimalPlaces = 2;

            // lblLoanInterest
            lblLoanInterest.AutoSize = true;
            lblLoanInterest.Location = new Point(15, 455);
            lblLoanInterest.Name = "lblLoanInterest";
            lblLoanInterest.Size = new Size(135, 15);
            lblLoanInterest.TabIndex = 21;
            lblLoanInterest.Text = "Проценты по кредитам:";

            // nudLoanInterest
            nudLoanInterest.Location = new Point(250, 452);
            nudLoanInterest.Name = "nudLoanInterest";
            nudLoanInterest.Size = new Size(150, 23);
            nudLoanInterest.TabIndex = 22;
            nudLoanInterest.Value = 0;
            nudLoanInterest.TextAlign = HorizontalAlignment.Right;
            nudLoanInterest.ThousandsSeparator = true;
            nudLoanInterest.Maximum = 1000000000;
            nudLoanInterest.DecimalPlaces = 2;

            // lblTaxSettingsGroup
            lblTaxSettingsGroup.AutoSize = true;
            lblTaxSettingsGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTaxSettingsGroup.Location = new Point(15, 500);
            lblTaxSettingsGroup.Name = "lblTaxSettingsGroup";
            lblTaxSettingsGroup.Size = new Size(135, 19);
            lblTaxSettingsGroup.TabIndex = 23;
            lblTaxSettingsGroup.Text = "Доп. настройки";

            // lblSocialRate
            lblSocialRate.AutoSize = true;
            lblSocialRate.Location = new Point(15, 535);
            lblSocialRate.Name = "lblSocialRate";
            lblSocialRate.Size = new Size(210, 15);
            lblSocialRate.TabIndex = 24;
            lblSocialRate.Text = "Ставка соц. отчислений (%):";

            // nudSocialRate
            nudSocialRate.Location = new Point(250, 532);
            nudSocialRate.Name = "nudSocialRate";
            nudSocialRate.Size = new Size(150, 23);
            nudSocialRate.TabIndex = 25;
            nudSocialRate.Value = 38.5M;
            nudSocialRate.TextAlign = HorizontalAlignment.Right;
            nudSocialRate.ThousandsSeparator = true;
            nudSocialRate.Maximum = 100;
            nudSocialRate.DecimalPlaces = 1;

            // lblProfitTaxRate
            lblProfitTaxRate.AutoSize = true;
            lblProfitTaxRate.Location = new Point(15, 570);
            lblProfitTaxRate.Name = "lblProfitTaxRate";
            lblProfitTaxRate.Size = new Size(165, 15);
            lblProfitTaxRate.TabIndex = 26;
            lblProfitTaxRate.Text = "Налог на прибыль (%):";

            // nudProfitTaxRate
            nudProfitTaxRate.Location = new Point(250, 567);
            nudProfitTaxRate.Name = "nudProfitTaxRate";
            nudProfitTaxRate.Size = new Size(150, 23);
            nudProfitTaxRate.TabIndex = 27;
            nudProfitTaxRate.Value = 20;
            nudProfitTaxRate.TextAlign = HorizontalAlignment.Right;
            nudProfitTaxRate.ThousandsSeparator = true;
            nudProfitTaxRate.Maximum = 100;
            nudProfitTaxRate.DecimalPlaces = 1;

            // btnSaveData
            btnSaveData.Location = new Point(15, 610);
            btnSaveData.Name = "btnSaveData";
            btnSaveData.Size = new Size(150, 30);
            btnSaveData.TabIndex = 28;
            btnSaveData.Text = "Сохранить данные";
            btnSaveData.UseVisualStyleBackColor = true;
            btnSaveData.Click += BtnSaveData_Click;

            // btnCalculate
            btnCalculate.Location = new Point(180, 610);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(150, 30);
            btnCalculate.TabIndex = 29;
            btnCalculate.Text = "Рассчитать";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += BtnCalculate_Click;

            // MainForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 650);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Обучающий калькулятор по расчёту издержек и прибыли";
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;

        private Label lblProductionGroup;
        private Label lblOutputVolume;
        private NumericUpDown nudOutputVolume;
        private Label lblPricePerUnit;
        private NumericUpDown nudPricePerUnit;

        private Label lblVariableCostsGroup;
        private Label lblRawMaterials;
        private NumericUpDown nudRawMaterials;
        private Label lblEnergyTransport;
        private NumericUpDown nudEnergyTransport;
        private Label lblPieceworkWage;
        private NumericUpDown nudPieceworkWage;

        private Label lblFixedCostsGroup;
        private Label lblRent;
        private NumericUpDown nudRent;
        private Label lblDepreciation;
        private NumericUpDown nudDepreciation;
        private Label lblSalaryAdmin;
        private NumericUpDown nudSalaryAdmin;
        private Label lblUtilities;
        private NumericUpDown nudUtilities;
        private Label lblLoanInterest;
        private NumericUpDown nudLoanInterest;

        private Label lblTaxSettingsGroup;
        private Label lblSocialRate;
        private NumericUpDown nudSocialRate;
        private Label lblProfitTaxRate;
        private NumericUpDown nudProfitTaxRate;

        private Button btnSaveData;
        private Button btnCalculate;
    }
}