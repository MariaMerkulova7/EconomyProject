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

            // === TAB 1: INPUT CONTROLS ===
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

            // === TAB 2: COST CALCULATION CONTROLS ===
            groupBoxAccountingCosts = new GroupBox();
            groupBoxInternalCosts = new GroupBox();
            groupBoxByVolume = new GroupBox();

            lblAccountingTitle = new Label();
            lblAccountingCostsFormula = new Label();
            lblAccountingCostsValue = new Label();
            btnInfoAccounting = new Button();

            lblInternalTitle = new Label();
            lblInternalCostsFormula = new Label();
            lblInternalCostsValue = new Label();
            btnInfoInternal = new Button();

            lblFCTitle = new Label(); lblFCFormula = new Label(); lblFCValue = new Label(); btnInfoFC = new Button();
            lblVCTitle = new Label(); lblVCFormula = new Label(); lblVCValue = new Label(); btnInfoVC = new Button();
            lblTCTitle = new Label(); lblTCFormula = new Label(); lblTCValue = new Label(); btnInfoTC = new Button();
            lblAFCTitle = new Label(); lblAFCFormula = new Label(); lblAFCValue = new Label(); btnInfoAFC = new Button();
            lblAVCTitle = new Label(); lblAVCFormula = new Label(); lblAVCValue = new Label(); btnInfoAVC = new Button();
            lblATCTitle = new Label(); lblATCFormula = new Label(); lblATCValue = new Label(); btnInfoATC = new Button();
            lblMCTitle = new Label(); lblMCFormula = new Label(); lblMCValue = new Label(); btnInfoMC = new Button();

            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            groupBoxAccountingCosts.SuspendLayout();
            groupBoxInternalCosts.SuspendLayout();
            groupBoxByVolume.SuspendLayout();
            SuspendLayout();

            // tabControl1
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1024, 650);
            tabControl1.TabIndex = 0;

            // tabPage1
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
            tabPage1.Text = "1. Ввод данных";
            tabPage1.UseVisualStyleBackColor = true;

            // tabPage2
            tabPage2.AutoScroll = true;
            tabPage2.Controls.Add(groupBoxByVolume);
            tabPage2.Controls.Add(groupBoxInternalCosts);
            tabPage2.Controls.Add(groupBoxAccountingCosts);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(15);
            tabPage2.Size = new Size(1016, 622);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "2. Расчёт издержек";
            tabPage2.UseVisualStyleBackColor = true;

            // groupBoxAccountingCosts
            groupBoxAccountingCosts.Controls.Add(lblAccountingTitle);
            groupBoxAccountingCosts.Controls.Add(lblAccountingCostsFormula);
            groupBoxAccountingCosts.Controls.Add(lblAccountingCostsValue);
            groupBoxAccountingCosts.Controls.Add(btnInfoAccounting);
            groupBoxAccountingCosts.Location = new Point(15, 15);
            groupBoxAccountingCosts.Name = "groupBoxAccountingCosts";
            groupBoxAccountingCosts.Size = new Size(970, 100);
            groupBoxAccountingCosts.TabIndex = 0;
            groupBoxAccountingCosts.TabStop = false;
            groupBoxAccountingCosts.Text = "Бухгалтерские (явные) издержки";

            lblAccountingTitle.AutoSize = true;
            lblAccountingTitle.Location = new Point(10, 30);
            lblAccountingTitle.Text = "Сырье, ЗП, Амортизация, Налоги";

            lblAccountingCostsFormula.AutoSize = false;
            lblAccountingCostsFormula.Location = new Point(250, 25);
            lblAccountingCostsFormula.Size = new Size(150, 35);
            lblAccountingCostsFormula.Text = "FC + VC";
            lblAccountingCostsFormula.BackColor = Color.FromArgb(240, 240, 240);
            lblAccountingCostsFormula.BorderStyle = BorderStyle.FixedSingle;
            lblAccountingCostsFormula.TextAlign = ContentAlignment.MiddleCenter;

            lblAccountingCostsValue.AutoSize = true;
            lblAccountingCostsValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblAccountingCostsValue.ForeColor = Color.DodgerBlue;
            lblAccountingCostsValue.Location = new Point(450, 30);
            lblAccountingCostsValue.Text = "0 руб.";

            btnInfoAccounting.Location = new Point(800, 25);
            btnInfoAccounting.Size = new Size(100, 30);
            btnInfoAccounting.Text = "Теория";
            btnInfoAccounting.Click += BtnInfoAccounting_Click;

            // groupBoxInternalCosts
            groupBoxInternalCosts.Controls.Add(lblInternalTitle);
            groupBoxInternalCosts.Controls.Add(lblInternalCostsFormula);
            groupBoxInternalCosts.Controls.Add(lblInternalCostsValue);
            groupBoxInternalCosts.Controls.Add(btnInfoInternal);
            groupBoxInternalCosts.Location = new Point(15, 125);
            groupBoxInternalCosts.Name = "groupBoxInternalCosts";
            groupBoxInternalCosts.Size = new Size(970, 80);
            groupBoxInternalCosts.TabIndex = 1;
            groupBoxInternalCosts.TabStop = false;
            groupBoxInternalCosts.Text = "Внутренние (неявные) издержки";

            lblInternalTitle.AutoSize = true;
            lblInternalTitle.Location = new Point(10, 30);
            lblInternalTitle.Text = "Упущенная ЗП, Рента, Процент";

            lblInternalCostsFormula.AutoSize = false;
            lblInternalCostsFormula.Location = new Point(250, 25);
            lblInternalCostsFormula.Size = new Size(150, 35);
            lblInternalCostsFormula.Text = "Опционально";
            lblInternalCostsFormula.BackColor = Color.FromArgb(240, 240, 240);
            lblInternalCostsFormula.BorderStyle = BorderStyle.FixedSingle;
            lblInternalCostsFormula.TextAlign = ContentAlignment.MiddleCenter;

            lblInternalCostsValue.AutoSize = true;
            lblInternalCostsValue.ForeColor = Color.Gray;
            lblInternalCostsValue.Location = new Point(450, 30);
            lblInternalCostsValue.Text = "0 руб.";

            btnInfoInternal.Location = new Point(800, 25);
            btnInfoInternal.Size = new Size(100, 30);
            btnInfoInternal.Text = "Теория";
            btnInfoInternal.Click += BtnInfoInternal_Click;

            // groupBoxByVolume
            groupBoxByVolume.Controls.Add(lblFCTitle); groupBoxByVolume.Controls.Add(lblFCFormula); groupBoxByVolume.Controls.Add(lblFCValue); groupBoxByVolume.Controls.Add(btnInfoFC);
            groupBoxByVolume.Controls.Add(lblVCTitle); groupBoxByVolume.Controls.Add(lblVCFormula); groupBoxByVolume.Controls.Add(lblVCValue); groupBoxByVolume.Controls.Add(btnInfoVC);
            groupBoxByVolume.Controls.Add(lblTCTitle); groupBoxByVolume.Controls.Add(lblTCFormula); groupBoxByVolume.Controls.Add(lblTCValue); groupBoxByVolume.Controls.Add(btnInfoTC);
            groupBoxByVolume.Controls.Add(lblAFCTitle); groupBoxByVolume.Controls.Add(lblAFCFormula); groupBoxByVolume.Controls.Add(lblAFCValue); groupBoxByVolume.Controls.Add(btnInfoAFC);
            groupBoxByVolume.Controls.Add(lblAVCTitle); groupBoxByVolume.Controls.Add(lblAVCFormula); groupBoxByVolume.Controls.Add(lblAVCValue); groupBoxByVolume.Controls.Add(btnInfoAVC);
            groupBoxByVolume.Controls.Add(lblATCTitle); groupBoxByVolume.Controls.Add(lblATCFormula); groupBoxByVolume.Controls.Add(lblATCValue); groupBoxByVolume.Controls.Add(btnInfoATC);
            groupBoxByVolume.Controls.Add(lblMCTitle); groupBoxByVolume.Controls.Add(lblMCFormula); groupBoxByVolume.Controls.Add(lblMCValue); groupBoxByVolume.Controls.Add(btnInfoMC);

            groupBoxByVolume.Location = new Point(15, 220);
            groupBoxByVolume.Name = "groupBoxByVolume";
            groupBoxByVolume.Size = new Size(970, 400);
            groupBoxByVolume.TabIndex = 2;
            groupBoxByVolume.TabStop = false;
            groupBoxByVolume.Text = "Классификация по объёму производства (Краткосрочный период)";

            void SetupRow(Label labelTitle, Label labelFormula, Label labelValue, Button btn, int yPos, string titleText, string formulaText, string valueText, EventHandler clickHandler)
            {
                labelTitle.Location = new Point(10, yPos);
                labelTitle.AutoSize = true;
                labelTitle.Text = titleText;

                labelFormula.Location = new Point(180, yPos);
                labelFormula.BackColor = Color.FromArgb(240, 240, 240);
                labelFormula.BorderStyle = BorderStyle.FixedSingle;
                labelFormula.Padding = new Padding(5);
                labelFormula.Text = formulaText;
                labelFormula.Width = 150;
                labelFormula.Height = 35;
                labelFormula.AutoSize = false;
                labelFormula.TextAlign = ContentAlignment.MiddleCenter;

                labelValue.Location = new Point(350, yPos + 8);
                labelValue.AutoSize = true;
                labelValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                labelValue.ForeColor = Color.DarkBlue;
                labelValue.Text = valueText;
                labelValue.Width = 200;

                btn.Location = new Point(800, yPos + 2);
                btn.Size = new Size(100, 30);
                btn.Text = "Теория";
                btn.Click += clickHandler;
            }

            SetupRow(lblFCTitle, lblFCFormula, lblFCValue, btnInfoFC, 25, "Постоянные (FC):", "Не зависят от Q", "0 руб.", BtnInfoFC_Click);
            SetupRow(lblVCTitle, lblVCFormula, lblVCValue, btnInfoVC, 65, "Переменные (VC):", "Зависят от Q", "0 руб.", BtnInfoVC_Click);
            SetupRow(lblTCTitle, lblTCFormula, lblTCValue, btnInfoTC, 105, "Совокупные (TC):", "TC = FC + VC", "0 руб.", BtnInfoTC_Click);
            SetupRow(lblAFCTitle, lblAFCFormula, lblAFCValue, btnInfoAFC, 145, "Средние постоянные (AFC):", "AFC = FC / Q", "0 руб./шт.", BtnInfoAFC_Click);
            SetupRow(lblAVCTitle, lblAVCFormula, lblAVCValue, btnInfoAVC, 185, "Средние переменные (AVC):", "AVC = VC / Q", "0 руб./шт.", BtnInfoAVC_Click);
            SetupRow(lblATCTitle, lblATCFormula, lblATCValue, btnInfoATC, 225, "Средние общие (ATC):", "ATC = TC / Q", "0 руб./шт.", BtnInfoATC_Click);
            SetupRow(lblMCTitle, lblMCFormula, lblMCValue, btnInfoMC, 265, "Предельные (MC):", "MC = AVC / ΔQ", "0 руб./шт.", BtnInfoMC_Click);

            // tabPage3 & 4
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(1016, 622);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "3. Себестоимость и Прибыль";
            tabPage3.UseVisualStyleBackColor = true;

            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(1016, 622);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "4. Графики";
            tabPage4.UseVisualStyleBackColor = true;

            // Tab1 Controls Setup
            lblProductionGroup.AutoSize = true;
            lblProductionGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProductionGroup.Location = new Point(15, 15);
            lblProductionGroup.Text = "Объём и цена";

            lblOutputVolume.AutoSize = true;
            lblOutputVolume.Location = new Point(15, 50);
            lblOutputVolume.Text = "Объем выпуска Q (шт):";

            nudOutputVolume.Location = new Point(250, 47);
            nudOutputVolume.Size = new Size(150, 23);
            nudOutputVolume.ThousandsSeparator = true;
            nudOutputVolume.Maximum = 1000000000;

            lblPricePerUnit.AutoSize = true;
            lblPricePerUnit.Location = new Point(15, 85);
            lblPricePerUnit.Text = "Цена реализации P (руб):";

            nudPricePerUnit.Location = new Point(250, 82);
            nudPricePerUnit.Size = new Size(150, 23);
            nudPricePerUnit.DecimalPlaces = 2;
            nudPricePerUnit.ThousandsSeparator = true;
            nudPricePerUnit.Maximum = 1000000000;

            lblVariableCostsGroup.AutoSize = true;
            lblVariableCostsGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblVariableCostsGroup.Location = new Point(15, 130);
            lblVariableCostsGroup.Text = "Переменные затраты на единицу";

            lblRawMaterials.AutoSize = true;
            lblRawMaterials.Location = new Point(15, 165);
            lblRawMaterials.Text = "Сырье и материалы (руб/шт):";
            nudRawMaterials.Location = new Point(250, 162);
            nudRawMaterials.Size = new Size(150, 23);
            nudRawMaterials.DecimalPlaces = 2;
            nudRawMaterials.ThousandsSeparator = true;
            nudRawMaterials.Maximum = 1000000000;

            lblEnergyTransport.AutoSize = true;
            lblEnergyTransport.Location = new Point(15, 200);
            lblEnergyTransport.Text = "Энергия/транспорт (руб/шт):";
            nudEnergyTransport.Location = new Point(250, 197);
            nudEnergyTransport.Size = new Size(150, 23);
            nudEnergyTransport.DecimalPlaces = 2;
            nudEnergyTransport.ThousandsSeparator = true;
            nudEnergyTransport.Maximum = 1000000000;

            lblPieceworkWage.AutoSize = true;
            lblPieceworkWage.Location = new Point(15, 235);
            lblPieceworkWage.Text = "Сдельная ЗП (руб/шт):";
            nudPieceworkWage.Location = new Point(250, 232);
            nudPieceworkWage.Size = new Size(150, 23);
            nudPieceworkWage.DecimalPlaces = 2;
            nudPieceworkWage.ThousandsSeparator = true;
            nudPieceworkWage.Maximum = 1000000000;

            lblFixedCostsGroup.AutoSize = true;
            lblFixedCostsGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFixedCostsGroup.Location = new Point(15, 280);
            lblFixedCostsGroup.Text = "Постоянные затраты (месяц)";

            lblRent.AutoSize = true;
            lblRent.Location = new Point(15, 315);
            lblRent.Text = "Аренда помещения:";
            nudRent.Location = new Point(250, 312);
            nudRent.Size = new Size(150, 23);
            nudRent.DecimalPlaces = 2;
            nudRent.ThousandsSeparator = true;
            nudRent.Maximum = 1000000000;

            lblDepreciation.AutoSize = true;
            lblDepreciation.Location = new Point(15, 350);
            lblDepreciation.Text = "Амортизация оборудования:";
            nudDepreciation.Location = new Point(250, 347);
            nudDepreciation.Size = new Size(150, 23);
            nudDepreciation.DecimalPlaces = 2;
            nudDepreciation.ThousandsSeparator = true;
            nudDepreciation.Maximum = 1000000000;

            lblSalaryAdmin.AutoSize = true;
            lblSalaryAdmin.Location = new Point(15, 385);
            lblSalaryAdmin.Text = "Окладная часть ЗП (упр., охрана):";
            nudSalaryAdmin.Location = new Point(250, 382);
            nudSalaryAdmin.Size = new Size(150, 23);
            nudSalaryAdmin.DecimalPlaces = 2;
            nudSalaryAdmin.ThousandsSeparator = true;
            nudSalaryAdmin.Maximum = 1000000000;

            lblUtilities.AutoSize = true;
            lblUtilities.Location = new Point(15, 420);
            lblUtilities.Text = "Коммунальные услуги:";
            nudUtilities.Location = new Point(250, 417);
            nudUtilities.Size = new Size(150, 23);
            nudUtilities.DecimalPlaces = 2;
            nudUtilities.ThousandsSeparator = true;
            nudUtilities.Maximum = 1000000000;

            lblLoanInterest.AutoSize = true;
            lblLoanInterest.Location = new Point(15, 455);
            lblLoanInterest.Text = "Проценты по кредитам:";
            nudLoanInterest.Location = new Point(250, 452);
            nudLoanInterest.Size = new Size(150, 23);
            nudLoanInterest.DecimalPlaces = 2;
            nudLoanInterest.ThousandsSeparator = true;
            nudLoanInterest.Maximum = 1000000000;

            lblTaxSettingsGroup.AutoSize = true;
            lblTaxSettingsGroup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTaxSettingsGroup.Location = new Point(15, 500);
            lblTaxSettingsGroup.Text = "Доп. настройки";

            lblSocialRate.AutoSize = true;
            lblSocialRate.Location = new Point(15, 535);
            lblSocialRate.Text = "Ставка соц. отчислений (%):";
            nudSocialRate.Location = new Point(250, 532);
            nudSocialRate.Size = new Size(150, 23);
            nudSocialRate.Value = 38.5M;
            nudSocialRate.Maximum = 100;
            nudSocialRate.DecimalPlaces = 1;

            lblProfitTaxRate.AutoSize = true;
            lblProfitTaxRate.Location = new Point(15, 570);
            lblProfitTaxRate.Text = "Налог на прибыль (%):";
            nudProfitTaxRate.Location = new Point(250, 567);
            nudProfitTaxRate.Size = new Size(150, 23);
            nudProfitTaxRate.Value = 20;
            nudProfitTaxRate.Maximum = 100;
            nudProfitTaxRate.DecimalPlaces = 1;

            btnSaveData.Location = new Point(15, 610);
            btnSaveData.Size = new Size(150, 30);
            btnSaveData.Text = "Сохранить данные";
            btnSaveData.Click += BtnSaveData_Click;

            btnCalculate.Location = new Point(180, 610);
            btnCalculate.Size = new Size(150, 30);
            btnCalculate.Text = "Рассчитать";
            btnCalculate.Click += BtnCalculate_Click;

            // MainForm
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1024, 650);
            Controls.Add(tabControl1);
            Name = "MainForm";
            Text = "Калькулятор издержек и прибыли";

            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            groupBoxAccountingCosts.ResumeLayout(false);
            groupBoxAccountingCosts.PerformLayout();
            groupBoxInternalCosts.ResumeLayout(false);
            groupBoxInternalCosts.PerformLayout();
            groupBoxByVolume.ResumeLayout(false);
            groupBoxByVolume.PerformLayout();
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

        // === TAB 2 CONTROLS (ОБЯЗАТЕЛЬНО ОБЪЯВЛЕНЫ ЗДЕСЬ) ===
        private GroupBox groupBoxAccountingCosts;
        private Label lblAccountingTitle;
        private Label lblAccountingCostsFormula;
        private Label lblAccountingCostsValue;
        private Button btnInfoAccounting;

        private GroupBox groupBoxInternalCosts;
        private Label lblInternalTitle;
        private Label lblInternalCostsFormula;
        private Label lblInternalCostsValue;
        private Button btnInfoInternal;

        private GroupBox groupBoxByVolume;

        private Label lblFCTitle, lblFCFormula, lblFCValue; private Button btnInfoFC;
        private Label lblVCTitle, lblVCFormula, lblVCValue; private Button btnInfoVC;
        private Label lblTCTitle, lblTCFormula, lblTCValue; private Button btnInfoTC;

        private Label lblAFCTitle, lblAFCFormula, lblAFCValue; private Button btnInfoAFC;
        private Label lblAVCTitle, lblAVCFormula, lblAVCValue; private Button btnInfoAVC;
        private Label lblATCTitle, lblATCFormula, lblATCValue; private Button btnInfoATC;
        private Label lblMCTitle, lblMCFormula, lblMCValue; private Button btnInfoMC;
    }
}