using EduCostCalc.Models;
using EduCostCalc.Services;
using System;
using System.Windows.Forms;

namespace EduCostCalc
{
    public partial class MainForm : Form
    {
        private readonly Company _currentCompany;
        private readonly CostCalculator _calculator;
        private readonly DetailedCostCalculator _detailedCalculator;

        public MainForm()
        {
            InitializeComponent();
            _currentCompany = new Company();
            _calculator = new CostCalculator(_currentCompany);
            _detailedCalculator = new DetailedCostCalculator(_currentCompany);
        }

        // ================= TAB 1: INPUT & SAVE =================
        private void BtnSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudOutputVolume.Value <= 0)
                {
                    MessageBox.Show("Объем выпуска должен быть больше 0!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudOutputVolume.Focus();
                    return;
                }
                if (nudPricePerUnit.Value <= 0)
                {
                    MessageBox.Show("Цена реализации должна быть больше 0!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudPricePerUnit.Focus();
                    return;
                }

                SaveFormDataToCompany();
                MessageBox.Show("Данные успешно сохранены!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudOutputVolume.Value <= 0 || nudPricePerUnit.Value <= 0)
                {
                    MessageBox.Show("Проверьте ввод объёма и цены (должны быть > 0)!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveFormDataToCompany();
                UpdateCostsTab();
                tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчете: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveFormDataToCompany()
        {
            // Базовые параметры
            _currentCompany.Production.OutputVolume = nudOutputVolume.Value;
            _currentCompany.Production.PricePerUnit = nudPricePerUnit.Value;

            // Переменные затраты
            _currentCompany.VariableCosts.RawMaterialsPerUnit = nudRawMaterials.Value;
            _currentCompany.VariableCosts.EnergyTransportPerUnit = nudEnergyTransport.Value;
            _currentCompany.VariableCosts.PieceworkWagePerUnit = nudPieceworkWage.Value;

            // Постоянные затраты
            _currentCompany.FixedCosts.Rent = nudRent.Value;
            _currentCompany.FixedCosts.Depreciation = nudDepreciation.Value;
            _currentCompany.FixedCosts.SalaryAdministrative = nudSalaryAdmin.Value;
            _currentCompany.FixedCosts.Utilities = nudUtilities.Value;
            _currentCompany.FixedCosts.LoanInterest = nudLoanInterest.Value;

            // Налоговые настройки
            _currentCompany.TaxSettings.SocialContributionRate = nudSocialRate.Value;
            _currentCompany.TaxSettings.ProfitTaxRate = nudProfitTaxRate.Value;
        }

        // ================= TAB 2: UPDATE & THEORY =================
        private void UpdateCostsTab()
        {
            try
            {
                decimal accountingCosts = _calculator.CalculateTotalCosts();
                lblAccountingCostsValue.Text = $"{accountingCosts:N2} руб.";
                lblInternalCostsValue.Text = "0 руб. (опционально)";

                lblFCValue.Text = $"{_currentCompany.FixedCosts.TotalFixedCosts:N2} руб.";
                lblVCValue.Text = $"{_calculator.GetTotalVariableCosts():N2} руб.";
                lblTCValue.Text = $"{accountingCosts:N2} руб.";

                lblAFCValue.Text = $"{_calculator.CalculateAverageFixedCost():N2} руб./шт.";
                lblAVCValue.Text = $"{_calculator.CalculateAverageVariableCost():N2} руб./шт.";
                lblATCValue.Text = $"{_calculator.CalculateAverageTotalCost():N2} руб./шт.";
                lblMCValue.Text = $"{_calculator.CalculateAverageVariableCost():N2} руб./шт."; // MC ≈ AVC в линейной модели
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении вкладки издержек: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= TAB 3: DETAILED CALCULATION =================
        private void BtnCalculateDetailed_Click(object sender, EventArgs e)
        {
            try
            {
                if (nudOutputVolume3.Value <= 0 || nudPricePerUnit3.Value <= 0)
                {
                    MessageBox.Show("Укажите объем выпуска и цену на вкладке 3!", "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                SaveDetailedFormData();
                UpdateTab3Results();
                MessageBox.Show("Расчет себестоимости и прибыли выполнен успешно!", "Информация", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчете: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveDetailedFormData()
        {
            // Синхронизация базовых параметров
            _currentCompany.Production.OutputVolume = nudOutputVolume3.Value;
            _currentCompany.Production.PricePerUnit = nudPricePerUnit3.Value;

            // Прямые затраты
            _currentCompany.DirectCosts.RawMaterialsPerUnit = nudRawMaterialsDirect.Value;
            _currentCompany.DirectCosts.MainLaborWagePerUnit = nudMainLaborWage.Value;

            // Общепроизводственные
            _currentCompany.ProductionOverhead.AuxiliaryLaborWage = nudAuxiliaryLaborWage.Value;
            _currentCompany.ProductionOverhead.TechnologicalEnergyWater = nudTechnologicalEnergy.Value;
            _currentCompany.ProductionOverhead.OtherProductionOverheadPercent = nudOtherProdOverheadPerc.Value;

            // Общезаводские/Административные
            _currentCompany.AdministrativeCosts.AdministrativeStaffWage = nudAdminStaffWage.Value;
            _currentCompany.AdministrativeCosts.Rent = nudRentAdmin.Value;
            _currentCompany.AdministrativeCosts.Heating = nudHeating.Value;
            _currentCompany.AdministrativeCosts.Communication = nudCommunication.Value;
            _currentCompany.AdministrativeCosts.Security = nudSecurity.Value;
            _currentCompany.AdministrativeCosts.OfficeSupplies = nudOfficeSupplies.Value;
            _currentCompany.AdministrativeCosts.OtherAdministrativePercent = nudOtherAdminPerc.Value;

            // Эксплуатационные
            _currentCompany.OperatingCosts.Depreciation = nudDepreciationCost.Value;
            _currentCompany.OperatingCosts.LeasePayments = nudLeasePayments.Value;
            _currentCompany.OperatingCosts.LoanInterest = nudLoanInterestCost.Value;
            _currentCompany.OperatingCosts.TaxesIncludedInCost = nudTaxesInCost.Value;

            // Коммерческие
            _currentCompany.CommercialCosts.SalesStaffWage = nudSalesStaffWage.Value;
            _currentCompany.CommercialCosts.OtherCommercialPercent = nudOtherCommPerc.Value;

            // Внутренние (неявные)
            _currentCompany.ImplicitCosts.OpportunityCostCapital = nudOpportunityCapital.Value;
            _currentCompany.ImplicitCosts.OpportunityCostOwnerLabor = nudOpportunityLabor.Value;
            _currentCompany.ImplicitCosts.OpportunityCostRent = nudOpportunityRent.Value;
            _currentCompany.ImplicitCosts.NormalProfit = nudNormalProfit.Value;
        }

        private void UpdateTab3Results()
        {
            // Структура себестоимости
            valResDirect.Text = $"{_detailedCalculator.CalculateDirectCosts():N2} руб.";
            valResProdOverhead.Text = $"{_currentCompany.ProductionOverhead.TotalProductionOverhead:N2} руб.";
            valResAdmin.Text = $"{_currentCompany.AdministrativeCosts.TotalAdministrativeCosts:N2} руб.";
            valResOperating.Text = $"{_currentCompany.OperatingCosts.TotalOperatingCosts:N2} руб.";
            valResProdCost.Text = $"{_detailedCalculator.CalculateProductionCost():N2} руб.";
            valResCommercial.Text = $"{_currentCompany.CommercialCosts.TotalCommercialCosts:N2} руб.";
            valResFullCost.Text = $"{_detailedCalculator.CalculateFullCost():N2} руб.";
            valResCostPerUnit.Text = $"{_detailedCalculator.CalculateCostPerUnit():N2} руб./шт.";

            // Прибыль
            valResRevenue.Text = $"{_detailedCalculator.CalculateRevenue():N2} руб.";
            valResGrossProfit.Text = $"{_detailedCalculator.CalculateGrossProfit():N2} руб.";
            valResOperatingProfit.Text = $"{_detailedCalculator.CalculateOperatingProfit():N2} руб.";
            valResNetProfit.Text = $"{_detailedCalculator.CalculateNetProfit():N2} руб.";
            valResEconomicProfit.Text = $"{_detailedCalculator.CalculateEconomicProfit():N2} руб.";

            // Эффективность
            valResCM.Text = $"{_detailedCalculator.CalculateContributionMargin():N2} руб.";
            valResCMRatio.Text = $"{_detailedCalculator.CalculateContributionMarginRatio():N2}%";
            valResProfitability.Text = $"{_detailedCalculator.CalculateProfitabilityFullCost():N2}%";
            valResROS.Text = $"{_detailedCalculator.CalculateReturnOnSales():N2}%";

            // Точка безубыточности
            var bepUnits = _detailedCalculator.CalculateBreakEvenPointUnits();
            var bepValue = _detailedCalculator.CalculateBreakEvenPointValue();

            if (bepUnits < 0)
            {
                valResBEPUnits.Text = "Недостижима (P ≤ AVC)";
                valResBEPValue.Text = "—";
            }
            else
            {
                valResBEPUnits.Text = $"{bepUnits:N0} шт.";
                valResBEPValue.Text = $"{bepValue:N2} руб.";
            }

            valResSafetyUnits.Text = $"{_detailedCalculator.CalculateSafetyMarginUnits():N0} шт.";
            valResSafetyPerc.Text = $"{_detailedCalculator.CalculateSafetyMarginPercent():N2}%";
        }

        private void BtnClearTab3_Click(object sender, EventArgs e)
        {
            // Сброс полей ввода на 0 или значения по умолчанию
            nudOutputVolume3.Value = 0; nudPricePerUnit3.Value = 0;
            nudRawMaterialsDirect.Value = 0; nudMainLaborWage.Value = 0;
            nudAuxiliaryLaborWage.Value = 0; nudTechnologicalEnergy.Value = 0; nudOtherProdOverheadPerc.Value = 13;
            nudAdminStaffWage.Value = 0; nudRentAdmin.Value = 0; nudHeating.Value = 0;
            nudCommunication.Value = 0; nudSecurity.Value = 0; nudOfficeSupplies.Value = 0; nudOtherAdminPerc.Value = 13;
            nudDepreciationCost.Value = 0; nudLeasePayments.Value = 0; nudLoanInterestCost.Value = 0; nudTaxesInCost.Value = 0;
            nudSalesStaffWage.Value = 0; nudOtherCommPerc.Value = 13;
            nudOpportunityCapital.Value = 0; nudOpportunityLabor.Value = 0; nudOpportunityRent.Value = 0; nudNormalProfit.Value = 0;

            // Сброс результатов
            foreach (Control ctrl in tabPage3.Controls)
            {
                if (ctrl is Label lbl && lbl.Name.StartsWith("valRes"))
                    lbl.Text = "0 руб.";
            }
        }

        // ================= THEORY BUTTONS =================
        private static void ShowTheory(string title, string content)
        {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnInfoAccounting_Click(object sender, EventArgs e) => ShowTheory("БУХГАЛТЕРСКИЕ (ЯВНЫЕ) ИЗДЕРЖКИ",
            "Фактические денежные затраты предприятия, связанные с производственной деятельностью.\n\n" +
            "📋 Включают:\n• Материально-производственные затраты\n• Оплата труда наёмных работников\n" +
            "• Отчисления на социальные нужды (38,5% от ФОТ)\n• Амортизационные расходы\n• Прочие затраты\n\n" +
            "💰 Формула: Бухгалтерские издержки = FC + VC\n\n📊 Значение: Используются для расчёта бухгалтерской прибыли и составления финансовой отчётности.");

        private void BtnInfoInternal_Click(object sender, EventArgs e) => ShowTheory("ВНУТРЕННИЕ (НЕЯВНЫЕ) ИЗДЕРЖКИ",
            "Затраты собственных ресурсов предприятия, оценённые по наилучшему варианту альтернативного использования.\n\n" +
            "📋 Включают:\n• Упущенная зарплата владельца\n• Упущенная рента\n• Упущенный процент на капитал\n• Нормальная прибыль\n\n" +
            "📊 Значение: Используются для расчёта экономической прибыли. Показывают альтернативные издержки использования собственных ресурсов.");

        private void BtnInfoFC_Click(object sender, EventArgs e) => ShowTheory("ПОСТОЯННЫЕ ИЗДЕРЖКИ (FC)",
            "Издержки, величина которых НЕ изменяется с изменением объёма производства.\n\n" +
            "📚 Примеры: Аренда, амортизация, окладная часть ЗП, коммунальные услуги, проценты по кредитам.\n" +
            "💡 Существуют даже при нулевом выпуске (Q=0). График: горизонтальная прямая.");

        private void BtnInfoVC_Click(object sender, EventArgs e) => ShowTheory("ПЕРЕМЕННЫЕ ИЗДЕРЖКИ (VC)",
            "Издержки, которые изменяются пропорционально изменению объёма производства.\n\n" +
            "📚 Примеры: Сырьё, энергия, сдельная ЗП.\n💰 Формула: VC = AVC × Q. При Q = 0, VC = 0.");

        private void BtnInfoTC_Click(object sender, EventArgs e) => ShowTheory("СОВОКУПНЫЕ ИЗДЕРЖКИ (TC)",
            "Сумма всех постоянных и переменных издержек фирмы.\n💰 Формула: TC = FC + VC\n" +
            "Используются для расчёта прибыли (Profit = TR - TC) и определения точки безубыточности.");

        private void BtnInfoAFC_Click(object sender, EventArgs e) => ShowTheory("СРЕДНИЕ ПОСТОЯННЫЕ ИЗДЕРЖКИ (AFC)",
            "Постоянные издержки в расчёте на единицу продукции.\n💰 Формула: AFC = FC / Q\n" +
            "📈 Постоянно снижаются с ростом объёма производства (эффект масштаба).");

        private void BtnInfoAVC_Click(object sender, EventArgs e) => ShowTheory("СРЕДНИЕ ПЕРЕМЕННЫЕ ИЗДЕРЖКИ (AVC)",
            "Переменные издержки в расчёте на единицу продукции.\n💰 Формула: AVC = VC / Q\n" +
            "⚠️ Если P < AVC - фирме следует прекратить производство в краткосрочном периоде!");

        private void BtnInfoATC_Click(object sender, EventArgs e) => ShowTheory("СРЕДНИЕ СОВОКУПНЫЕ ИЗДЕРЖКИ (ATC)",
            "Совокупные издержки в расчёте на единицу продукции (себестоимость).\n💰 Формула: ATC = TC / Q = AFC + AVC\n" +
            "📈 U-образная кривая. Сравнение с ценой определяет прибыль или убыток.");

        private void BtnInfoMC_Click(object sender, EventArgs e) => ShowTheory("ПРЕДЕЛЬНЫЕ ИЗДЕРЖКИ (MC)",
            "Дополнительные издержки на производство каждой дополнительной единицы продукции.\n💰 Формула: MC = ΔTC / ΔQ\n" +
            "Правило максимизации прибыли: MR = MC. В условиях совершенной конкуренции: P = MC.");

        private void BtnInfoCostStructure_Click(object sender, EventArgs e) => ShowTheory("СТРУКТУРА СЕБЕСТОИМОСТИ (Положение РФ №552)",
            "1️⃣ ПРЯМЫЕ ЗАТРАТЫ: Сырьё, ЗП основного персонала, соц. отчисления (38.5%)\n" +
            "2️⃣ ОБЩЕПРОИЗВОДСТВЕННЫЕ: ЗП вспомогательного, тех. энергия/вода, прочие (~13%)\n" +
            "3️⃣ ОБЩЕЗАВОДСКИЕ: ЗП АУП, аренда, отопление, связь, охрана, канцелярия, прочие (~13%)\n" +
            "4️⃣ ЭКСПЛУАТАЦИОННЫЕ: Амортизация, лизинг, проценты, налоги на себестоимость\n" +
            "= ПРОИЗВОДСТВЕННАЯ СЕБЕСТОИМОСТЬ\n" +
            "5️⃣ КОММЕРЧЕСКИЕ: ЗП сбыта + соц. отчисления, прочие (~13%)\n" +
            "= ПОЛНАЯ СЕБЕСТОИМОСТЬ");
    }
}