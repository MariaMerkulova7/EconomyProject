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
                tabPage3.AutoScroll = true;
                tabPage3.Location = new Point(4, 24);
                tabPage3.Name = "tabPage3";
                tabPage3.Padding = new Padding(10);
                tabPage3.Size = new Size(1016, 622);
                tabPage3.TabIndex = 2;
                tabPage3.Text = "3. Себестоимость и Прибыль";
                tabPage3.UseVisualStyleBackColor = true;

                // ==========================================
                // 1. ЯВНАЯ ИНИЦИАЛИЗАЦИЯ ВСЕХ ЭЛЕМЕНТОВ
                // ==========================================
                // GroupBoxes
                groupBoxBaseParams3 = new GroupBox(); groupBoxDirectCosts = new GroupBox(); groupBoxProdOverhead = new GroupBox();
                groupBoxAdminCosts = new GroupBox(); groupBoxOperating = new GroupBox(); groupBoxCommercial = new GroupBox();
                groupBoxImplicit = new GroupBox(); groupBoxCostResults = new GroupBox(); groupBoxProfitResults = new GroupBox();
                groupBoxEfficiency = new GroupBox(); groupBoxBreakEven = new GroupBox();

                // Inputs
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

                // Buttons
                btnCalculateDetailed = new Button(); btnClearTab3 = new Button(); btnInfoCostStructure = new Button();

                // Result Labels
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
                // 2. НАСТРОЙКА СВОЙСТВ И РАЗМЕЩЕНИЕ
                // ==========================================

                // --- Base Params ---
                groupBoxBaseParams3.Location = new Point(10, 10);
                groupBoxBaseParams3.Size = new Size(480, 90);
                groupBoxBaseParams3.Text = "Базовые параметры";
                lblBaseQ3.Location = new Point(15, 30); lblBaseQ3.Text = "Объем выпуска Q:";
                nudOutputVolume3.Location = new Point(180, 27); nudOutputVolume3.Size = new Size(120, 23); nudOutputVolume3.ThousandsSeparator = true; nudOutputVolume3.Maximum = 1000000000;
                lblBaseP3.Location = new Point(15, 60); lblBaseP3.Text = "Цена реализации P:";
                nudPricePerUnit3.Location = new Point(180, 57); nudPricePerUnit3.Size = new Size(120, 23); nudPricePerUnit3.DecimalPlaces = 2; nudPricePerUnit3.ThousandsSeparator = true; nudPricePerUnit3.Maximum = 1000000000;
                groupBoxBaseParams3.Controls.AddRange(new Control[] { lblBaseQ3, nudOutputVolume3, lblBaseP3, nudPricePerUnit3 });

                // --- Direct Costs ---
                groupBoxDirectCosts.Location = new Point(10, 110);
                groupBoxDirectCosts.Size = new Size(480, 90);
                groupBoxDirectCosts.Text = "1. Прямые затраты (на ед.)";
                lblDirectRawMat.Location = new Point(15, 25); lblDirectRawMat.Text = "Сырье и материалы:";
                nudRawMaterialsDirect.Location = new Point(180, 22); nudRawMaterialsDirect.Size = new Size(120, 23); nudRawMaterialsDirect.DecimalPlaces = 2; nudRawMaterialsDirect.ThousandsSeparator = true;
                lblDirectMainLabor.Location = new Point(15, 55); lblDirectMainLabor.Text = "ЗП основного персонала:";
                nudMainLaborWage.Location = new Point(180, 52); nudMainLaborWage.Size = new Size(120, 23); nudMainLaborWage.DecimalPlaces = 2; nudMainLaborWage.ThousandsSeparator = true;
                groupBoxDirectCosts.Controls.AddRange(new Control[] { lblDirectRawMat, nudRawMaterialsDirect, lblDirectMainLabor, nudMainLaborWage });

                // --- Production Overhead ---
                groupBoxProdOverhead.Location = new Point(500, 110);
                groupBoxProdOverhead.Size = new Size(490, 120);
                groupBoxProdOverhead.Text = "2. Общепроизводственные расходы";
                lblOverheadAuxLabor.Location = new Point(15, 25); lblOverheadAuxLabor.Text = "ЗП вспомогательного:";
                nudAuxiliaryLaborWage.Location = new Point(200, 22); nudAuxiliaryLaborWage.Size = new Size(130, 23); nudAuxiliaryLaborWage.DecimalPlaces = 2; nudAuxiliaryLaborWage.ThousandsSeparator = true;
                lblOverheadTechEnergy.Location = new Point(15, 55); lblOverheadTechEnergy.Text = "Техн. энергия/вода/пар:";
                nudTechnologicalEnergy.Location = new Point(200, 52); nudTechnologicalEnergy.Size = new Size(130, 23); nudTechnologicalEnergy.DecimalPlaces = 2; nudTechnologicalEnergy.ThousandsSeparator = true;
                lblOverheadOtherPerc.Location = new Point(15, 85); lblOverheadOtherPerc.Text = "Прочие общепроизв. (%):";
                nudOtherProdOverheadPerc.Location = new Point(200, 82); nudOtherProdOverheadPerc.Size = new Size(80, 23); nudOtherProdOverheadPerc.Value = 13; nudOtherProdOverheadPerc.Maximum = 100;
                groupBoxProdOverhead.Controls.AddRange(new Control[] { lblOverheadAuxLabor, nudAuxiliaryLaborWage, lblOverheadTechEnergy, nudTechnologicalEnergy, lblOverheadOtherPerc, nudOtherProdOverheadPerc });

                // --- Admin Costs ---
                groupBoxAdminCosts.Location = new Point(10, 240);
                groupBoxAdminCosts.Size = new Size(480, 210);
                groupBoxAdminCosts.Text = "3. Общезаводские (административные) расходы";
                int adminY = 25;
                void SetAdmin(Label lbl, NumericUpDown nud, string txt, ref int y)
                {
                    lbl.Location = new Point(15, y); lbl.Text = txt;
                    nud.Location = new Point(150, y); nud.Size = new Size(130, 23); nud.DecimalPlaces = 2; y += 30;
                }
                SetAdmin(lblAdminStaffWage, nudAdminStaffWage, "ЗП АУП:", ref adminY);
                SetAdmin(lblAdminRent, nudRentAdmin, "Аренда:", ref adminY);
                SetAdmin(lblAdminHeating, nudHeating, "Отопление:", ref adminY);
                SetAdmin(lblAdminComm, nudCommunication, "Связь:", ref adminY);
                SetAdmin(lblAdminSecurity, nudSecurity, "Охрана:", ref adminY);
                SetAdmin(lblAdminOffice, nudOfficeSupplies, "Канцелярия:", ref adminY);
                lblAdminOtherPerc.Location = new Point(15, adminY); lblAdminOtherPerc.Text = "Прочие общезаводские (%):";
                nudOtherAdminPerc.Location = new Point(150, adminY); nudOtherAdminPerc.Size = new Size(80, 23); nudOtherAdminPerc.Value = 13; nudOtherAdminPerc.Maximum = 100;
                groupBoxAdminCosts.Controls.AddRange(new Control[] { lblAdminStaffWage, nudAdminStaffWage, lblAdminRent, nudRentAdmin, lblAdminHeating, nudHeating, lblAdminComm, nudCommunication, lblAdminSecurity, nudSecurity, lblAdminOffice, nudOfficeSupplies, lblAdminOtherPerc, nudOtherAdminPerc });

                // --- Operating Costs ---
                groupBoxOperating.Location = new Point(500, 240);
                groupBoxOperating.Size = new Size(490, 150);
                groupBoxOperating.Text = "4. Эксплуатационные расходы";
                int opY = 25;
                SetAdmin(lblOpDepreciation, nudDepreciationCost, "Амортизация:", ref opY);
                SetAdmin(lblOpLease, nudLeasePayments, "Лизинговые платежи:", ref opY);
                SetAdmin(lblOpLoan, nudLoanInterestCost, "Проценты по кредитам:", ref opY);
                SetAdmin(lblOpTaxes, nudTaxesInCost, "Налоги на себестоимость:", ref opY);
                groupBoxOperating.Controls.AddRange(new Control[] { lblOpDepreciation, nudDepreciationCost, lblOpLease, nudLeasePayments, lblOpLoan, nudLoanInterestCost, lblOpTaxes, nudTaxesInCost });

                // --- Commercial Costs ---
                groupBoxCommercial.Location = new Point(10, 460);
                groupBoxCommercial.Size = new Size(480, 90);
                groupBoxCommercial.Text = "5. Коммерческие расходы";
                lblCommSalesWage.Location = new Point(15, 25); lblCommSalesWage.Text = "ЗП сбытового персонала:";
                nudSalesStaffWage.Location = new Point(200, 22); nudSalesStaffWage.Size = new Size(130, 23); nudSalesStaffWage.DecimalPlaces = 2;
                lblCommOtherPerc.Location = new Point(15, 55); lblCommOtherPerc.Text = "Прочие коммерческие (%):";
                nudOtherCommPerc.Location = new Point(200, 52); nudOtherCommPerc.Size = new Size(80, 23); nudOtherCommPerc.Value = 13; nudOtherCommPerc.Maximum = 100;
                groupBoxCommercial.Controls.AddRange(new Control[] { lblCommSalesWage, nudSalesStaffWage, lblCommOtherPerc, nudOtherCommPerc });

                // --- Implicit Costs ---
                groupBoxImplicit.Location = new Point(500, 400);
                groupBoxImplicit.Size = new Size(490, 150);
                groupBoxImplicit.Text = "6. Внутренние (неявные) издержки";
                int impY = 25;
                SetAdmin(lblImpCapital, nudOpportunityCapital, "Упущенный % на капитал:", ref impY);
                SetAdmin(lblImpLabor, nudOpportunityLabor, "Упущенная ЗП владельца:", ref impY);
                SetAdmin(lblImpRent, nudOpportunityRent, "Упущенная рента:", ref impY);
                SetAdmin(lblImpNormalProfit, nudNormalProfit, "Нормальная прибыль:", ref impY);
                groupBoxImplicit.Controls.AddRange(new Control[] { lblImpCapital, nudOpportunityCapital, lblImpLabor, nudOpportunityLabor, lblImpRent, nudOpportunityRent, lblImpNormalProfit, nudNormalProfit });

                // --- Buttons ---
                btnCalculateDetailed.Location = new Point(10, 560);
                btnCalculateDetailed.Size = new Size(160, 35);
                btnCalculateDetailed.Text = "Рассчитать";
                btnCalculateDetailed.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                btnCalculateDetailed.BackColor = Color.LightGreen;
                btnCalculateDetailed.Click += BtnCalculateDetailed_Click;

                btnClearTab3.Location = new Point(180, 560);
                btnClearTab3.Size = new Size(120, 35);
                btnClearTab3.Text = "Очистить";
                btnClearTab3.Click += BtnClearTab3_Click;

                btnInfoCostStructure.Location = new Point(310, 560);
                btnInfoCostStructure.Size = new Size(100, 35);
                btnInfoCostStructure.Text = "Теория";
                btnInfoCostStructure.Click += BtnInfoCostStructure_Click;

                // --- Results Setup ---
                void AddCostRow(Label lbl, Label val, string text, int y)
                {
                    lbl.Location = new Point(15, y); lbl.Text = text; lbl.AutoSize = true;
                    val.Location = new Point(200, y); val.Text = "0 руб."; val.ForeColor = Color.DarkBlue; val.Font = new Font("Segoe UI", 9F, FontStyle.Bold); val.AutoSize = true;
                }
                void AddProfitRow(Label lbl, Label val, string text, int y, Color c)
                {
                    lbl.Location = new Point(15, y); lbl.Text = text; lbl.AutoSize = true;
                    val.Location = new Point(200, y); val.Text = "0 руб."; val.ForeColor = c; val.Font = new Font("Segoe UI", 9F, FontStyle.Bold); val.AutoSize = true;
                }

                groupBoxCostResults.Location = new Point(500, 10);
                groupBoxCostResults.Size = new Size(490, 220);
                groupBoxCostResults.Text = "Структура себестоимости";
                int resCY = 20;
                AddCostRow(lblResDirect, valResDirect, "Прямые затраты:", resCY);
                AddCostRow(lblResProdOverhead, valResProdOverhead, "Общепроизводственные:", resCY += 25);
                AddCostRow(lblResAdmin, valResAdmin, "Общезаводские:", resCY += 25);
                AddCostRow(lblResOperating, valResOperating, "Эксплуатационные:", resCY += 25);
                AddCostRow(lblResProdCost, valResProdCost, "Производственная себестоимость:", resCY += 30);
                valResProdCost.ForeColor = Color.DarkGreen;
                AddCostRow(lblResCommercial, valResCommercial, "Коммерческие расходы:", resCY += 25);
                AddCostRow(lblResFullCost, valResFullCost, "Полная себестоимость:", resCY += 25);
                valResFullCost.ForeColor = Color.DarkRed; valResFullCost.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                AddCostRow(lblResCostPerUnit, valResCostPerUnit, "Себестоимость ед.:", resCY += 30);
                groupBoxCostResults.Controls.AddRange(new Control[] { lblResDirect, valResDirect, lblResProdOverhead, valResProdOverhead, lblResAdmin, valResAdmin, lblResOperating, valResOperating, lblResProdCost, valResProdCost, lblResCommercial, valResCommercial, lblResFullCost, valResFullCost, lblResCostPerUnit, valResCostPerUnit });

                groupBoxProfitResults.Location = new Point(10, 10);
                groupBoxProfitResults.Size = new Size(480, 190);
                groupBoxProfitResults.Text = "Расчет прибыли";
                int resPY = 20;
                AddProfitRow(lblResRevenue, valResRevenue, "Выручка (TR):", resPY, Color.Black);
                AddProfitRow(lblResGrossProfit, valResGrossProfit, "Валовая прибыль:", resPY += 25, Color.Blue);
                AddProfitRow(lblResOperatingProfit, valResOperatingProfit, "Прибыль от реализации:", resPY += 25, Color.Purple);
                AddProfitRow(lblResNetProfit, valResNetProfit, "Чистая прибыль (после налога):", resPY += 25, Color.Green);
                AddProfitRow(lblResEconomicProfit, valResEconomicProfit, "Экономическая прибыль:", resPY += 30, Color.DarkOrange);
                groupBoxProfitResults.Controls.AddRange(new Control[] { lblResRevenue, valResRevenue, lblResGrossProfit, valResGrossProfit, lblResOperatingProfit, valResOperatingProfit, lblResNetProfit, valResNetProfit, lblResEconomicProfit, valResEconomicProfit });

                groupBoxEfficiency.Location = new Point(10, 210);
                groupBoxEfficiency.Size = new Size(480, 110);
                groupBoxEfficiency.Text = "Показатели эффективности";
                int resEY = 20;
                AddProfitRow(lblResCM, valResCM, "Маржинальная прибыль:", resEY, Color.Teal);
                AddProfitRow(lblResCMRatio, valResCMRatio, "Коэф. марж. прибыли:", resEY += 25, Color.Teal);
                AddProfitRow(lblResProfitability, valResProfitability, "Рентабельность продукции:", resEY += 25, Color.DarkCyan);
                AddProfitRow(lblResROS, valResROS, "Рентабельность продаж (ROS):", resEY += 25, Color.DarkCyan);
                groupBoxEfficiency.Controls.AddRange(new Control[] { lblResCM, valResCM, lblResCMRatio, valResCMRatio, lblResProfitability, valResProfitability, lblResROS, valResROS });

                groupBoxBreakEven.Location = new Point(10, 330);
                groupBoxBreakEven.Size = new Size(480, 130);
                groupBoxBreakEven.Text = "Точка безубыточности и запас прочности";
                int resBEY = 20;
                AddProfitRow(lblResBEPUnits, valResBEPUnits, "BEP (в шт. продукции):", resBEY, Color.Red);
                AddProfitRow(lblResBEPValue, valResBEPValue, "BEP (в денежном выражении):", resBEY += 25, Color.Red);
                AddProfitRow(lblResSafetyUnits, valResSafetyUnits, "Запас прочности (шт):", resBEY += 30, Color.Green);
                AddProfitRow(lblResSafetyPerc, valResSafetyPerc, "Запас прочности (%):", resBEY += 25, Color.Green);
                groupBoxBreakEven.Controls.AddRange(new Control[] { lblResBEPUnits, valResBEPUnits, lblResBEPValue, valResBEPValue, lblResSafetyUnits, valResSafetyUnits, lblResSafetyPerc, valResSafetyPerc });

                // --- Add all to TabPage ---
                tabPage3.Controls.AddRange(new Control[] {
                groupBoxBreakEven, groupBoxEfficiency, groupBoxProfitResults, groupBoxCostResults,
                groupBoxImplicit, groupBoxCommercial, groupBoxOperating, groupBoxAdminCosts,
                groupBoxProdOverhead, groupBoxDirectCosts, groupBoxBaseParams3,
                btnInfoCostStructure, btnClearTab3, btnCalculateDetailed
            });
            }
    }
}