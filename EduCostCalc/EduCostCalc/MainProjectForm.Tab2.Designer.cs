namespace EduCostCalc
{
    partial class MainForm
    {
        private GroupBox groupBoxAccountingCosts, groupBoxInternalCosts, groupBoxByVolume;
        private Label lblAccountingTitle, lblAccountingCostsFormula, lblAccountingCostsValue;
        private Button btnInfoAccounting;
        private Label lblInternalTitle, lblInternalCostsFormula, lblInternalCostsValue;
        private Button btnInfoInternal;

        private Label lblFCTitle, lblFCFormula, lblFCValue, lblVCTitle, lblVCFormula, lblVCValue;
        private Label lblTCTitle, lblTCFormula, lblTCValue, lblAFCTitle, lblAFCFormula, lblAFCValue;
        private Label lblAVCTitle, lblAVCFormula, lblAVCValue, lblATCTitle, lblATCFormula, lblATCValue;
        private Label lblMCTitle, lblMCFormula, lblMCValue;
        private Button btnInfoFC, btnInfoVC, btnInfoTC, btnInfoAFC, btnInfoAVC, btnInfoATC, btnInfoMC;

        private void InitializeTab2()
        {
            tabPage2.AutoScroll = true;
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(15);
            tabPage2.Size = new Size(1016, 622);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "2. Расчёт издержек";
            tabPage2.UseVisualStyleBackColor = true;

            // --- Бухгалтерские издержки ---
            groupBoxAccountingCosts = new GroupBox() { Location = new Point(15, 15), Size = new Size(970, 100), TabIndex = 0, Text = "Бухгалтерские (явные) издержки" };
            lblAccountingTitle = new Label() { AutoSize = true, Location = new Point(10, 30), Text = "Сырье, ЗП, Амортизация, Налоги" };
            lblAccountingCostsFormula = new Label() { AutoSize = false, Location = new Point(250, 25), Size = new Size(150, 35), Text = "FC + VC", BackColor = Color.FromArgb(240, 240, 240), BorderStyle = BorderStyle.FixedSingle, TextAlign = ContentAlignment.MiddleCenter };
            lblAccountingCostsValue = new Label() { AutoSize = true, Font = new Font("Segoe UI", 9F, FontStyle.Bold), ForeColor = Color.DodgerBlue, Location = new Point(450, 30), Text = "0 руб." };
            btnInfoAccounting = new Button() { Location = new Point(800, 25), Size = new Size(100, 30), Text = "Теория" };
            btnInfoAccounting.Click += BtnInfoAccounting_Click;
            groupBoxAccountingCosts.Controls.AddRange(new Control[] { lblAccountingTitle, lblAccountingCostsFormula, lblAccountingCostsValue, btnInfoAccounting });

            // --- Внутренние издержки ---
            groupBoxInternalCosts = new GroupBox() { Location = new Point(15, 125), Size = new Size(970, 80), TabIndex = 1, Text = "Внутренние (неявные) издержки" };
            lblInternalTitle = new Label() { AutoSize = true, Location = new Point(10, 30), Text = "Упущенная ЗП, Рента, Процент" };
            lblInternalCostsFormula = new Label() { AutoSize = false, Location = new Point(250, 25), Size = new Size(150, 35), Text = "Опционально", BackColor = Color.FromArgb(240, 240, 240), BorderStyle = BorderStyle.FixedSingle, TextAlign = ContentAlignment.MiddleCenter };
            lblInternalCostsValue = new Label() { AutoSize = true, ForeColor = Color.Gray, Location = new Point(450, 30), Text = "0 руб." };
            btnInfoInternal = new Button() { Location = new Point(800, 25), Size = new Size(100, 30), Text = "Теория" };
            btnInfoInternal.Click += BtnInfoInternal_Click;
            groupBoxInternalCosts.Controls.AddRange(new Control[] { lblInternalTitle, lblInternalCostsFormula, lblInternalCostsValue, btnInfoInternal });

            // --- По объёму производства ---
            groupBoxByVolume = new GroupBox() { Location = new Point(15, 220), Size = new Size(970, 400), TabIndex = 2, Text = "Классификация по объёму производства (Краткосрочный период)" };

            // Вспомогательная функция для отрисовки строк
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
                labelFormula.Size = new Size(150, 35);
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

            // ✅ ИСПРАВЛЕНИЕ: Явная инициализация элементов перед передачей в SetupRow
            lblFCTitle = new Label(); lblFCFormula = new Label(); lblFCValue = new Label(); btnInfoFC = new Button();
            SetupRow(lblFCTitle, lblFCFormula, lblFCValue, btnInfoFC, 25, "Постоянные (FC):", "Не зависят от Q", "0 руб.", BtnInfoFC_Click);

            lblVCTitle = new Label(); lblVCFormula = new Label(); lblVCValue = new Label(); btnInfoVC = new Button();
            SetupRow(lblVCTitle, lblVCFormula, lblVCValue, btnInfoVC, 65, "Переменные (VC):", "Зависят от Q", "0 руб.", BtnInfoVC_Click);

            lblTCTitle = new Label(); lblTCFormula = new Label(); lblTCValue = new Label(); btnInfoTC = new Button();
            SetupRow(lblTCTitle, lblTCFormula, lblTCValue, btnInfoTC, 105, "Совокупные (TC):", "TC = FC + VC", "0 руб.", BtnInfoTC_Click);

            lblAFCTitle = new Label(); lblAFCFormula = new Label(); lblAFCValue = new Label(); btnInfoAFC = new Button();
            SetupRow(lblAFCTitle, lblAFCFormula, lblAFCValue, btnInfoAFC, 145, "Средние постоянные (AFC):", "AFC = FC / Q", "0 руб./шт.", BtnInfoAFC_Click);

            lblAVCTitle = new Label(); lblAVCFormula = new Label(); lblAVCValue = new Label(); btnInfoAVC = new Button();
            SetupRow(lblAVCTitle, lblAVCFormula, lblAVCValue, btnInfoAVC, 185, "Средние переменные (AVC):", "AVC = VC / Q", "0 руб./шт.", BtnInfoAVC_Click);

            lblATCTitle = new Label(); lblATCFormula = new Label(); lblATCValue = new Label(); btnInfoATC = new Button();
            SetupRow(lblATCTitle, lblATCFormula, lblATCValue, btnInfoATC, 225, "Средние общие (ATC):", "ATC = TC / Q", "0 руб./шт.", BtnInfoATC_Click);

            lblMCTitle = new Label(); lblMCFormula = new Label(); lblMCValue = new Label(); btnInfoMC = new Button();
            SetupRow(lblMCTitle, lblMCFormula, lblMCValue, btnInfoMC, 265, "Предельные (MC):", "MC = ΔVC / ΔQ", "0 руб./шт.", BtnInfoMC_Click);

            // Добавление всех элементов в GroupBox
            groupBoxByVolume.Controls.AddRange(new Control[] {
                lblFCTitle, lblFCFormula, lblFCValue, btnInfoFC,
                lblVCTitle, lblVCFormula, lblVCValue, btnInfoVC,
                lblTCTitle, lblTCFormula, lblTCValue, btnInfoTC,
                lblAFCTitle, lblAFCFormula, lblAFCValue, btnInfoAFC,
                lblAVCTitle, lblAVCFormula, lblAVCValue, btnInfoAVC,
                lblATCTitle, lblATCFormula, lblATCValue, btnInfoATC,
                lblMCTitle, lblMCFormula, lblMCValue, btnInfoMC
            });

            tabPage2.Controls.AddRange(new Control[] { groupBoxByVolume, groupBoxInternalCosts, groupBoxAccountingCosts });
        }
    }
}