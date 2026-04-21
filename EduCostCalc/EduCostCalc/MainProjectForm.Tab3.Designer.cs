using System.Windows.Forms;

namespace EduCostCalc
{
    partial class MainForm
    {
        // Группы ввода
        private GroupBox groupBoxBaseParams3, groupBoxDirectCosts, groupBoxProdOverhead, groupBoxAdminCosts;
        private GroupBox groupBoxOperating, groupBoxCommercial, groupBoxImplicit;
        // Контролы ввода
        private Label lblBaseQ3, lblBaseP3, lblDirectRawMat, lblDirectMainLabor, lblOverheadAuxLabor;
        private Label lblOverheadTechEnergy, lblOverheadOtherPerc, lblAdminStaffWage, lblAdminRent;
        private Label lblAdminHeating, lblAdminComm, lblAdminSecurity, lblAdminOffice, lblAdminOtherPerc;
        private Label lblOpDepreciation, lblOpLease, lblOpLoan, lblOpTaxes;
        private Label lblCommSalesWage, lblCommOtherPerc, lblImpCapital, lblImpLabor, lblImpRent, lblImpNormalProfit;
        private NumericUpDown nudOutputVolume3, nudPricePerUnit3, nudRawMaterialsDirect, nudMainLaborWage;
        private NumericUpDown nudAuxiliaryLaborWage, nudTechnologicalEnergy, nudOtherProdOverheadPerc;
        private NumericUpDown nudAdminStaffWage, nudRentAdmin, nudHeating, nudCommunication, nudSecurity;
        private NumericUpDown nudOfficeSupplies, nudOtherAdminPerc, nudDepreciationCost, nudLeasePayments;
        private NumericUpDown nudLoanInterestCost, nudTaxesInCost, nudSalesStaffWage, nudOtherCommPerc;
        private NumericUpDown nudOpportunityCapital, nudOpportunityLabor, nudOpportunityRent, nudNormalProfit;
        // Кнопки
        private Button btnCalculateDetailed, btnClearTab3, btnInfoCostStructure;
        // Результаты
        private GroupBox groupBoxCostResults, groupBoxProfitResults, groupBoxEfficiency, groupBoxBreakEven;
        private Label lblResDirect, valResDirect, lblResProdOverhead, valResProdOverhead, lblResAdmin, valResAdmin;
        private Label lblResOperating, valResOperating, lblResProdCost, valResProdCost, lblResCommercial, valResCommercial;
        private Label lblResFullCost, valResFullCost, lblResCostPerUnit, valResCostPerUnit;
        private Label lblResRevenue, valResRevenue, lblResGrossProfit, valResGrossProfit, lblResOperatingProfit, valResOperatingProfit;
        private Label lblResNetProfit, valResNetProfit, lblResEconomicProfit, valResEconomicProfit;
        private Label lblResCM, valResCM, lblResCMRatio, valResCMRatio, lblResProfitability, valResProfitability;
        private Label lblResROS, valResROS, lblResBEPUnits, valResBEPUnits, lblResBEPValue, valResBEPValue;
        private Label lblResSafetyUnits, valResSafetyUnits, lblResSafetyPerc, valResSafetyPerc;

        private void InitializeTab3()
        {
            // === БАЗОВАЯ НАСТРОЙКА ВКЛАДКИ ===
            tabPage3.AutoScroll = true;
            tabPage3.AutoScrollMinSize = new Size(1150, 1550);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(20);
            tabPage3.Size = new Size(1016, 622);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "3. Себестоимость и Прибыль";
            tabPage3.UseVisualStyleBackColor = true;

            // ==========================================
            // 1. ИНИЦИАЛИЗАЦИЯ ВСЕХ КОНТРОЛОВ
            // ==========================================
            groupBoxBaseParams3 = new GroupBox(); groupBoxDirectCosts = new GroupBox(); groupBoxProdOverhead = new GroupBox();
            groupBoxAdminCosts = new GroupBox(); groupBoxOperating = new GroupBox(); groupBoxCommercial = new GroupBox();
            groupBoxImplicit = new GroupBox(); groupBoxCostResults = new GroupBox(); groupBoxProfitResults = new GroupBox();
            groupBoxEfficiency = new GroupBox(); groupBoxBreakEven = new GroupBox();

            lblBaseQ3 = new Label(); nudOutputVolume3 = new NumericUpDown();
            lblBaseP3 = new Label(); nudPricePerUnit3 = new NumericUpDown();
            lblDirectRawMat = new Label(); nudRawMaterialsDirect = new NumericUpDown();
            lblDirectMainLabor = new Label(); nudMainLaborWage = new NumericUpDown();
            lblOverheadAuxLabor = new Label(); nudAuxiliaryLaborWage = new NumericUpDown();
            lblOverheadTechEnergy = new Label(); nudTechnologicalEnergy = new NumericUpDown();
            lblOverheadOtherPerc = new Label(); nudOtherProdOverheadPerc = new NumericUpDown();
            lblAdminStaffWage = new Label(); nudAdminStaffWage = new NumericUpDown();
            lblAdminRent = new Label(); nudRentAdmin = new NumericUpDown();
            lblAdminHeating = new Label(); nudHeating = new NumericUpDown();
            lblAdminComm = new Label(); nudCommunication = new NumericUpDown();
            lblAdminSecurity = new Label(); nudSecurity = new NumericUpDown();
            lblAdminOffice = new Label(); nudOfficeSupplies = new NumericUpDown();
            lblAdminOtherPerc = new Label(); nudOtherAdminPerc = new NumericUpDown();
            lblOpDepreciation = new Label(); nudDepreciationCost = new NumericUpDown();
            lblOpLease = new Label(); nudLeasePayments = new NumericUpDown();
            lblOpLoan = new Label(); nudLoanInterestCost = new NumericUpDown();
            lblOpTaxes = new Label(); nudTaxesInCost = new NumericUpDown();
            lblCommSalesWage = new Label(); nudSalesStaffWage = new NumericUpDown();
            lblCommOtherPerc = new Label(); nudOtherCommPerc = new NumericUpDown();
            lblImpCapital = new Label(); nudOpportunityCapital = new NumericUpDown();
            lblImpLabor = new Label(); nudOpportunityLabor = new NumericUpDown();
            lblImpRent = new Label(); nudOpportunityRent = new NumericUpDown();
            lblImpNormalProfit = new Label(); nudNormalProfit = new NumericUpDown();

            btnCalculateDetailed = new Button(); btnClearTab3 = new Button(); btnInfoCostStructure = new Button();

            lblResDirect = new Label(); valResDirect = new Label();
            lblResProdOverhead = new Label(); valResProdOverhead = new Label();
            lblResAdmin = new Label(); valResAdmin = new Label();
            lblResOperating = new Label(); valResOperating = new Label();
            lblResProdCost = new Label(); valResProdCost = new Label();
            lblResCommercial = new Label(); valResCommercial = new Label();
            lblResFullCost = new Label(); valResFullCost = new Label();
            lblResCostPerUnit = new Label(); valResCostPerUnit = new Label();
            lblResRevenue = new Label(); valResRevenue = new Label();
            lblResGrossProfit = new Label(); valResGrossProfit = new Label();
            lblResOperatingProfit = new Label(); valResOperatingProfit = new Label();
            lblResNetProfit = new Label(); valResNetProfit = new Label();
            lblResEconomicProfit = new Label(); valResEconomicProfit = new Label();
            lblResCM = new Label(); valResCM = new Label();
            lblResCMRatio = new Label(); valResCMRatio = new Label();
            lblResProfitability = new Label(); valResProfitability = new Label();
            lblResROS = new Label(); valResROS = new Label();
            lblResBEPUnits = new Label(); valResBEPUnits = new Label();
            lblResBEPValue = new Label(); valResBEPValue = new Label();
            lblResSafetyUnits = new Label(); valResSafetyUnits = new Label();
            lblResSafetyPerc = new Label(); valResSafetyPerc = new Label();

            // ==========================================
            // 2. ВСПОМОГАТЕЛЬНЫЕ ФУНКЦИИ
            // ==========================================
            void SetupNud(NumericUpDown nud, int dec = 2, decimal max = 999999999)
            {
                nud.DecimalPlaces = dec; nud.ThousandsSeparator = true; nud.Maximum = max;
                nud.Size = new Size(150, 23);
            }
            void SetupPercNud(NumericUpDown nud)
            {
                nud.DecimalPlaces = 1; nud.ThousandsSeparator = false; nud.Maximum = 100; nud.Minimum = 0;
                nud.Size = new Size(70, 23);
            }
            void SetupLabel(Label lbl, string text, int x, int y)
            {
                lbl.AutoSize = true; lbl.Text = text; lbl.Location = new Point(x, y);
            }
            void SetupValue(Label lbl, int x, int y, Color fore, bool bold = false)
            {
                lbl.AutoSize = true; lbl.Location = new Point(x, y); lbl.Text = "0 руб.";
                lbl.ForeColor = fore; lbl.Font = new Font("Segoe UI", 9F, bold ? FontStyle.Bold : FontStyle.Regular);
            }
            void AddInputRow(Label l, NumericUpDown n, string t, int y, int xNud = 235)
            {
                SetupLabel(l, t, 15, y);
                n.Location = new Point(xNud, y);
            }
            void AddResultRow(Label l, Label v, string t, int y, Color c, bool b = false)
            {
                SetupLabel(l, t, 15, y);
                SetupValue(v, 210, y, c, b);
            }

            // Настройка NumericUpDown
            SetupNud(nudOutputVolume3, 0); SetupNud(nudPricePerUnit3);
            SetupNud(nudRawMaterialsDirect); SetupNud(nudMainLaborWage);
            SetupNud(nudAuxiliaryLaborWage); SetupNud(nudTechnologicalEnergy);
            SetupPercNud(nudOtherProdOverheadPerc); nudOtherProdOverheadPerc.Value = 13;
            SetupNud(nudAdminStaffWage); SetupNud(nudRentAdmin); SetupNud(nudHeating);
            SetupNud(nudCommunication); SetupNud(nudSecurity); SetupNud(nudOfficeSupplies);
            SetupPercNud(nudOtherAdminPerc); nudOtherAdminPerc.Value = 13;
            SetupNud(nudDepreciationCost); SetupNud(nudLeasePayments); SetupNud(nudLoanInterestCost);
            SetupNud(nudTaxesInCost);
            SetupNud(nudSalesStaffWage); SetupPercNud(nudOtherCommPerc); nudOtherCommPerc.Value = 13;
            SetupNud(nudOpportunityCapital); SetupNud(nudOpportunityLabor); SetupNud(nudOpportunityRent); SetupNud(nudNormalProfit);

            // Настройка кнопок
            btnCalculateDetailed.Size = new Size(160, 35); btnCalculateDetailed.Text = "Рассчитать";
            btnCalculateDetailed.Font = new Font("Segoe UI", 9F, FontStyle.Bold); btnCalculateDetailed.BackColor = Color.LightGreen;
            btnCalculateDetailed.Click += BtnCalculateDetailed_Click;

            btnClearTab3.Size = new Size(120, 35); btnClearTab3.Text = "Очистить";
            btnClearTab3.Font = new Font("Segoe UI", 9F, FontStyle.Bold); btnClearTab3.BackColor = Color.LightCoral;

            btnClearTab3.Click += BtnClearTab3_Click;

            btnInfoCostStructure.Size = new Size(110, 35); btnInfoCostStructure.Text = "Теория";
            btnInfoCostStructure.Click += BtnInfoCostStructure_Click;

            // ==========================================
            // 3. ЛЕВАЯ КОЛОНКА: ВВОД ДАННЫХ (X=20)
            // ==========================================
            int leftX = 20, currentY = 20;

            groupBoxBaseParams3.Location = new Point(leftX, currentY); groupBoxBaseParams3.Size = new Size(520, 100); groupBoxBaseParams3.Text = "Базовые параметры";
            AddInputRow(lblBaseQ3, nudOutputVolume3, "Объем выпуска Q (шт):", 28);
            AddInputRow(lblBaseP3, nudPricePerUnit3, "Цена реализации P (руб):", 58);
            groupBoxBaseParams3.Controls.AddRange(new Control[] { lblBaseQ3, nudOutputVolume3, lblBaseP3, nudPricePerUnit3 });
            currentY += 130;

            groupBoxDirectCosts.Location = new Point(leftX, currentY); groupBoxDirectCosts.Size = new Size(520, 100); groupBoxDirectCosts.Text = "1. Прямые затраты (на ед.)";
            AddInputRow(lblDirectRawMat, nudRawMaterialsDirect, "Сырье и материалы (руб/шт):", 28);
            AddInputRow(lblDirectMainLabor, nudMainLaborWage, "ЗП основного персонала (руб/шт):", 58);
            groupBoxDirectCosts.Controls.AddRange(new Control[] { lblDirectRawMat, nudRawMaterialsDirect, lblDirectMainLabor, nudMainLaborWage });
            currentY += 130;

            groupBoxProdOverhead.Location = new Point(leftX, currentY); groupBoxProdOverhead.Size = new Size(520, 120); groupBoxProdOverhead.Text = "2. Общепроизводственные расходы";
            AddInputRow(lblOverheadAuxLabor, nudAuxiliaryLaborWage, "ЗП вспомогательного персонала:", 25);
            AddInputRow(lblOverheadTechEnergy, nudTechnologicalEnergy, "Техн. энергия/вода/пар:", 55);
            AddInputRow(lblOverheadOtherPerc, nudOtherProdOverheadPerc, "Прочие общепроизв. (% от суммы):", 85);
            groupBoxProdOverhead.Controls.AddRange(new Control[] { lblOverheadAuxLabor, nudAuxiliaryLaborWage, lblOverheadTechEnergy, nudTechnologicalEnergy, lblOverheadOtherPerc, nudOtherProdOverheadPerc });
            currentY += 150;

            groupBoxAdminCosts.Location = new Point(leftX, currentY); groupBoxAdminCosts.Size = new Size(520, 260); groupBoxAdminCosts.Text = "3. Общезаводские (административные) расходы";
            int adY = 25;
            AddInputRow(lblAdminStaffWage, nudAdminStaffWage, "ЗП АУП:", adY); adY += 30;
            AddInputRow(lblAdminRent, nudRentAdmin, "Аренда:", adY); adY += 30;
            AddInputRow(lblAdminHeating, nudHeating, "Отопление:", adY); adY += 30;
            AddInputRow(lblAdminComm, nudCommunication, "Связь:", adY); adY += 30;
            AddInputRow(lblAdminSecurity, nudSecurity, "Охрана:", adY); adY += 30;
            AddInputRow(lblAdminOffice, nudOfficeSupplies, "Канцелярия:", adY); adY += 30;
            AddInputRow(lblAdminOtherPerc, nudOtherAdminPerc, "Прочие общезаводские (%):", adY);
            groupBoxAdminCosts.Controls.AddRange(new Control[] { lblAdminStaffWage, nudAdminStaffWage, lblAdminRent, nudRentAdmin, lblAdminHeating, nudHeating, lblAdminComm, nudCommunication, lblAdminSecurity, nudSecurity, lblAdminOffice, nudOfficeSupplies, lblAdminOtherPerc, nudOtherAdminPerc });
            currentY += 290;

            groupBoxOperating.Location = new Point(leftX, currentY); groupBoxOperating.Size = new Size(520, 160); groupBoxOperating.Text = "4. Эксплуатационные расходы";
            int opY = 25;
            AddInputRow(lblOpDepreciation, nudDepreciationCost, "Амортизация:", opY); opY += 30;
            AddInputRow(lblOpLease, nudLeasePayments, "Лизинговые платежи:", opY); opY += 30;
            AddInputRow(lblOpLoan, nudLoanInterestCost, "Проценты по кредитам:", opY); opY += 30;
            AddInputRow(lblOpTaxes, nudTaxesInCost, "Налоги на себестоимость:", opY);
            groupBoxOperating.Controls.AddRange(new Control[] { lblOpDepreciation, nudDepreciationCost, lblOpLease, nudLeasePayments, lblOpLoan, nudLoanInterestCost, lblOpTaxes, nudTaxesInCost });
            currentY += 190;

            groupBoxCommercial.Location = new Point(leftX, currentY); groupBoxCommercial.Size = new Size(520, 110); groupBoxCommercial.Text = "5. Коммерческие расходы";
            AddInputRow(lblCommSalesWage, nudSalesStaffWage, "ЗП сбытового персонала:", 28);
            AddInputRow(lblCommOtherPerc, nudOtherCommPerc, "Прочие коммерческие (% от суммы):", 58);
            groupBoxCommercial.Controls.AddRange(new Control[] { lblCommSalesWage, nudSalesStaffWage, lblCommOtherPerc, nudOtherCommPerc });
            currentY += 140;

            groupBoxImplicit.Location = new Point(leftX, currentY); groupBoxImplicit.Size = new Size(520, 160); groupBoxImplicit.Text = "6. Внутренние (неявные) издержки";
            int impY = 25;
            AddInputRow(lblImpCapital, nudOpportunityCapital, "Упущенный % на капитал:", impY); impY += 30;
            AddInputRow(lblImpLabor, nudOpportunityLabor, "Упущенная ЗП владельца:", impY); impY += 30;
            AddInputRow(lblImpRent, nudOpportunityRent, "Упущенная рента:", impY); impY += 30;
            AddInputRow(lblImpNormalProfit, nudNormalProfit, "Нормальная прибыль:", impY);
            groupBoxImplicit.Controls.AddRange(new Control[] { lblImpCapital, nudOpportunityCapital, lblImpLabor, nudOpportunityLabor, lblImpRent, nudOpportunityRent, lblImpNormalProfit, nudNormalProfit });
            currentY += 190;

            btnCalculateDetailed.Location = new Point(leftX, currentY);
            btnClearTab3.Location = new Point(leftX + 175, currentY);
            btnInfoCostStructure.Location = new Point(leftX + 310, currentY);

            // ==========================================
            // 4. ПРАВАЯ КОЛОНКА: РЕЗУЛЬТАТЫ (X=560)
            // ==========================================
            int rightX = 560, rightY = 20;

            groupBoxCostResults.Location = new Point(rightX, rightY); groupBoxCostResults.Size = new Size(520, 270); groupBoxCostResults.Text = "Структура себестоимости";
            int rcY = 25;
            AddResultRow(lblResDirect, valResDirect, "Прямые затраты:", rcY, Color.DarkBlue); rcY += 25;
            AddResultRow(lblResProdOverhead, valResProdOverhead, "Общепроизводственные:", rcY, Color.DarkBlue); rcY += 25;
            AddResultRow(lblResAdmin, valResAdmin, "Общезаводские:", rcY, Color.DarkBlue); rcY += 25;
            AddResultRow(lblResOperating, valResOperating, "Эксплуатационные:", rcY, Color.DarkBlue); rcY += 25;
            AddResultRow(lblResProdCost, valResProdCost, "Производственная себестоимость:", rcY + 5, Color.DarkGreen, true); rcY += 35;
            AddResultRow(lblResCommercial, valResCommercial, "Коммерческие расходы:", rcY, Color.DarkBlue); rcY += 25;
            AddResultRow(lblResFullCost, valResFullCost, "ПОЛНАЯ СЕБЕСТОИМОСТЬ:", rcY, Color.DarkRed, true); rcY += 30;
            AddResultRow(lblResCostPerUnit, valResCostPerUnit, "Себестоимость 1 ед.:", rcY, Color.Purple, true);
            groupBoxCostResults.Controls.AddRange(new Control[] { lblResDirect, valResDirect, lblResProdOverhead, valResProdOverhead, lblResAdmin, valResAdmin, lblResOperating, valResOperating, lblResProdCost, valResProdCost, lblResCommercial, valResCommercial, lblResFullCost, valResFullCost, lblResCostPerUnit, valResCostPerUnit });
            rightY += 290;

            groupBoxProfitResults.Location = new Point(rightX, rightY); groupBoxProfitResults.Size = new Size(520, 200); groupBoxProfitResults.Text = "Расчет прибыли";
            int rpY = 25;
            AddResultRow(lblResRevenue, valResRevenue, "Выручка (TR):", rpY, Color.Black, true); rpY += 25;
            AddResultRow(lblResGrossProfit, valResGrossProfit, "Валовая прибыль:", rpY, Color.Blue); rpY += 25;
            AddResultRow(lblResOperatingProfit, valResOperatingProfit, "Прибыль от реализации:", rpY, Color.Purple); rpY += 25;
            AddResultRow(lblResNetProfit, valResNetProfit, "Чистая прибыль (после налога):", rpY, Color.Green, true); rpY += 25;
            AddResultRow(lblResEconomicProfit, valResEconomicProfit, "Экономическая прибыль:", rpY + 5, Color.DarkOrange, true);
            groupBoxProfitResults.Controls.AddRange(new Control[] { lblResRevenue, valResRevenue, lblResGrossProfit, valResGrossProfit, lblResOperatingProfit, valResOperatingProfit, lblResNetProfit, valResNetProfit, lblResEconomicProfit, valResEconomicProfit });
            rightY += 220;

            groupBoxEfficiency.Location = new Point(rightX, rightY); groupBoxEfficiency.Size = new Size(520, 150); groupBoxEfficiency.Text = "Показатели эффективности";
            int reY = 25;
            AddResultRow(lblResCM, valResCM, "Маржинальная прибыль:", reY, Color.Teal); reY += 25;
            AddResultRow(lblResCMRatio, valResCMRatio, "Коэф. марж. прибыли:", reY, Color.Teal); reY += 25;
            AddResultRow(lblResProfitability, valResProfitability, "Рентабельность продукции:", reY, Color.DarkCyan); reY += 25;
            AddResultRow(lblResROS, valResROS, "Рентабельность продаж (ROS):", reY, Color.DarkCyan);
            groupBoxEfficiency.Controls.AddRange(new Control[] { lblResCM, valResCM, lblResCMRatio, valResCMRatio, lblResProfitability, valResProfitability, lblResROS, valResROS });
            rightY += 170;

            groupBoxBreakEven.Location = new Point(rightX, rightY); groupBoxBreakEven.Size = new Size(520, 150); groupBoxBreakEven.Text = "Точка безубыточности и запас прочности";
            int rbY = 25;
            AddResultRow(lblResBEPUnits, valResBEPUnits, "BEP (в шт.):", rbY, Color.Red); rbY += 25;
            AddResultRow(lblResBEPValue, valResBEPValue, "BEP (в руб.):", rbY, Color.Red); rbY += 25;
            AddResultRow(lblResSafetyUnits, valResSafetyUnits, "Запас прочности (шт):", rbY + 5, Color.Green); rbY += 25;
            AddResultRow(lblResSafetyPerc, valResSafetyPerc, "Запас прочности (%):", rbY, Color.Green);
            groupBoxBreakEven.Controls.AddRange(new Control[] { lblResBEPUnits, valResBEPUnits, lblResBEPValue, valResBEPValue, lblResSafetyUnits, valResSafetyUnits, lblResSafetyPerc, valResSafetyPerc });

            // ==========================================
            // 5. ДОБАВЛЕНИЕ НА ВКЛАДКУ
            // ==========================================
            tabPage3.Controls.AddRange(new Control[] {
        groupBoxBreakEven, groupBoxEfficiency, groupBoxProfitResults, groupBoxCostResults,
        btnInfoCostStructure, btnClearTab3, btnCalculateDetailed,
        groupBoxImplicit, groupBoxCommercial, groupBoxOperating, groupBoxAdminCosts,
        groupBoxProdOverhead, groupBoxDirectCosts, groupBoxBaseParams3
    });
        }

    }
}