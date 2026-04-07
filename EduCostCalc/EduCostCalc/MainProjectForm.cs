using EduCostCalc.Models;
using EduCostCalc.Services;

namespace EduCostCalc
{
    public partial class MainForm : Form
    {
        private Company _currentCompany;
        private CostCalculator _calculator;

        public MainForm()
        {
            InitializeComponent();
            InitializeCompany();
        }

        private void InitializeCompany()
        {
            _currentCompany = new Company();
            _calculator = new CostCalculator(_currentCompany);
        }

        private void BtnSaveData_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что объем выпуска больше 0
                if (nudOutputVolume.Value <= 0)
                {
                    MessageBox.Show("Объем выпуска должен быть больше 0!", "Ошибка ввода",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudOutputVolume.Focus();
                    return;
                }

                // Проверяем, что цена больше 0
                if (nudPricePerUnit.Value <= 0)
                {
                    MessageBox.Show("Цена реализации должна быть больше 0!", "Ошибка ввода",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudPricePerUnit.Focus();
                    return;
                }

                // Сохраняем данные из формы в модель
                SaveFormDataToCompany();
                MessageBox.Show("Данные успешно сохранены!", "Информация",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при сохранении данных: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Проверяем, что объем выпуска больше 0
                if (nudOutputVolume.Value <= 0)
                {
                    MessageBox.Show("Объем выпуска должен быть больше 0!", "Ошибка ввода",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudOutputVolume.Focus();
                    return;
                }

                // Проверяем, что цена больше 0
                if (nudPricePerUnit.Value <= 0)
                {
                    MessageBox.Show("Цена реализации должна быть больше 0!", "Ошибка ввода",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    nudPricePerUnit.Focus();
                    return;
                }

                // Сохраняем данные
                SaveFormDataToCompany();

                // Показываем результаты
                ShowCalculationResults();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при расчете: {ex.Message}",
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveFormDataToCompany()
        {
            // Параметры производства
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

        private void ShowCalculationResults()
        {
            string results = "=== РЕЗУЛЬТАТЫ РАСЧЕТА ===\n\n";

            results += $"Объем выпуска: {_currentCompany.Production.OutputVolume:N0} шт.\n";
            results += $"Выручка (TR): {_calculator.CalculateTotalRevenue():N2} руб.\n\n";

            results += "--- ПЕРЕМЕННЫЕ ЗАТРАТЫ ---\n";
            results += $"На единицу: {_currentCompany.VariableCosts.TotalVariableCostPerUnit:N2} руб.\n";
            results += $"Всего (VC): {_calculator.GetTotalVariableCosts():N2} руб.\n\n";

            results += "--- ПОСТОЯННЫЕ ЗАТРАТЫ ---\n";
            results += $"Всего (FC): {_currentCompany.FixedCosts.TotalFixedCosts:N2} руб.\n";
            results += $"Соц. отчисления: {_calculator.CalculateSocialContributions():N2} руб.\n\n";

            results += "--- СОВОКУПНЫЕ ИЗДЕРЖКИ ---\n";
            results += $"Всего (TC): {_calculator.CalculateTotalCosts():N2} руб.\n";
            results += $"Средние (ATC): {_calculator.CalculateAverageTotalCost():N2} руб./шт.\n\n";

            results += "--- ПРИБЫЛЬ ---\n";
            results += $"Бухгалтерская: {_calculator.CalculateAccountingProfit():N2} руб.\n";
            results += $"Налог на прибыль: {_calculator.CalculateProfitTax():N2} руб.\n";
            results += $"Чистая прибыль: {_calculator.CalculateNetProfit():N2} руб.\n\n";

            results += "--- ПОКАЗАТЕЛИ ---\n";
            results += $"Рентабельность: {_calculator.CalculateProfitability():N2}%\n";

            decimal bep = _calculator.CalculateBreakEvenPoint();
            if (bep >= 0)
                results += $"Точка безубыточности: {bep:N0} шт.\n";
            else
                results += $"Точка безубыточности: недостижима\n";

            results += $"Запас прочности: {_calculator.CalculateSafetyMargin():N2}%\n";

            MessageBox.Show(results, "Результаты расчета",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}