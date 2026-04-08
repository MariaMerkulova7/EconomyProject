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
            _currentCompany.Production.OutputVolume = nudOutputVolume.Value;
            _currentCompany.Production.PricePerUnit = nudPricePerUnit.Value;

            _currentCompany.VariableCosts.RawMaterialsPerUnit = nudRawMaterials.Value;
            _currentCompany.VariableCosts.EnergyTransportPerUnit = nudEnergyTransport.Value;
            _currentCompany.VariableCosts.PieceworkWagePerUnit = nudPieceworkWage.Value;

            _currentCompany.FixedCosts.Rent = nudRent.Value;
            _currentCompany.FixedCosts.Depreciation = nudDepreciation.Value;
            _currentCompany.FixedCosts.SalaryAdministrative = nudSalaryAdmin.Value;
            _currentCompany.FixedCosts.Utilities = nudUtilities.Value;
            _currentCompany.FixedCosts.LoanInterest = nudLoanInterest.Value;

            _currentCompany.TaxSettings.SocialContributionRate = nudSocialRate.Value;
            _currentCompany.TaxSettings.ProfitTaxRate = nudProfitTaxRate.Value;
        }

        private void UpdateCostsTab()
        {
            try
            {
                decimal accountingCosts = _calculator.CalculateTotalCosts();
                lblAccountingCostsValue.Text = $"{accountingCosts:N2} руб.";

                lblInternalCostsValue.Text = "0 руб. (опционально)";

                decimal fc = _currentCompany.FixedCosts.TotalFixedCosts;
                lblFCValue.Text = $"{fc:N2} руб.";

                decimal vc = _calculator.GetTotalVariableCosts();
                lblVCValue.Text = $"{vc:N2} руб.";

                decimal tc = _calculator.CalculateTotalCosts();
                lblTCValue.Text = $"{tc:N2} руб.";

                decimal afc = _calculator.CalculateAverageFixedCost();
                lblAFCValue.Text = $"{afc:N2} руб./шт.";

                decimal avc = _calculator.CalculateAverageVariableCost();
                lblAVCValue.Text = $"{avc:N2} руб./шт.";

                decimal atc = _calculator.CalculateAverageTotalCost();
                lblATCValue.Text = $"{atc:N2} руб./шт.";

                decimal mc = avc; // В упрощенной линейной модели MC ≈ AVC
                lblMCValue.Text = $"{mc:N2} руб./шт.";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при обновлении вкладки издержек: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ================= THEORY BUTTONS =================

        private void BtnInfoAccounting_Click(object sender, EventArgs e) => ShowTheory("БУХГАЛТЕРСКИЕ (ЯВНЫЕ) ИЗДЕРЖКИ",
            "Фактические денежные затраты предприятия, связанные с производственной деятельностью.\n\n" +
            "📋 Включают:\n" +
            "• Материально-производственные затраты (сырьё, материалы, топливо)\n" +
            "• Оплата труда наёмных работников\n" +
            "• Отчисления на социальные нужды (38,5% от ФОТ)\n" +
            "• Амортизационные расходы\n" +
            "• Прочие затраты (аренда, проценты по кредитам, налоги)\n\n" +
            "💰 Формула: Бухгалтерские издержки = FC + VC\n\n" +
            "📊 Значение:\nИспользуются для расчёта бухгалтерской прибыли и составления финансовой отчётности.");

        private void BtnInfoInternal_Click(object sender, EventArgs e) => ShowTheory("ВНУТРЕННИЕ (НЕЯВНЫЕ) ИЗДЕРЖКИ",
            "Затраты собственных ресурсов предприятия, оценённые по наилучшему варианту альтернативного использования.\n\n" +
            "📋 Включают:\n" +
            "• Упущенная зарплата владельца (если бы работал по найму)\n" +
            "• Упущенная рента за использование собственного помещения/земли\n" +
            "• Упущенный процент на вложенный капитал\n" +
            "• Нормальная прибыль (вознаграждение за предпринимательский риск)\n\n" +
            "📊 Значение:\nИспользуются для расчёта экономической прибыли. Показывают, сколько фирма жертвует, используя свои ресурсы в данном производстве.");

        private void BtnInfoFC_Click(object sender, EventArgs e) => ShowTheory("ПОСТОЯННЫЕ ИЗДЕРЖКИ (FC)",
            "Издержки, величина которых НЕ изменяется с изменением объёма производства.\n\n" +
            "📚 Примеры:\n" +
            "• Аренда помещения\n" +
            "• Амортизация оборудования\n" +
            "• Окладная часть ЗП (управление, охрана)\n" +
            "• Коммунальные услуги (фиксированная часть)\n" +
            "• Проценты по кредитам\n\n" +
            "💡 Особенность: Существуют даже при нулевом выпуске (Q=0).\n" +
            "📊 График: Прямая линия, параллельная оси объёма производства.");

        private void BtnInfoVC_Click(object sender, EventArgs e) => ShowTheory("ПЕРЕМЕННЫЕ ИЗДЕРЖКИ (VC)",
            "Издержки, которые изменяются пропорционально изменению объёма производства.\n\n" +
            "📚 Примеры:\n" +
            "• Сырьё и материалы (на единицу × Q)\n" +
            "• Энергия/транспорт (на единицу × Q)\n" +
            "• Сдельная заработная плата (на единицу × Q)\n\n" +
            "💰 Формула: VC = AVC × Q\n" +
            "При Q = 0, VC = 0. \n📊 График: Восходящая линия из начала координат.");

        private void BtnInfoTC_Click(object sender, EventArgs e) => ShowTheory("СОВОКУПНЫЕ (ОБЩИЕ) ИЗДЕРЖКИ (TC)",
            "Сумма всех постоянных и переменных издержек фирмы.\n\n" +
            "💰 Формула: TC = FC + VC\n" +
            "Являются функцией от объёма выпуска: TC = f(Q)\n\n" +
            "📊 Значение:\n• Показывают общие затраты предприятия на производство данного объёма продукции.\n" +
            "• Используются для расчёта прибыли (Profit = TR - TC) и определения точки безубыточности.");

        private void BtnInfoAFC_Click(object sender, EventArgs e) => ShowTheory("СРЕДНИЕ ПОСТОЯННЫЕ ИЗДЕРЖКИ (AFC)",
            "Постоянные издержки в расчёте на единицу продукции.\n\n" +
            "💰 Формула: AFC = FC / Q\n\n" +
            "📈 Динамика: Постоянно СНИЖАЮТСЯ с ростом объёма производства (эффект масштаба).\n" +
            "📚 Пример: Если FC = 100 000 руб., то при Q=100 AFC=1000, при Q=1000 AFC=100.\n" +
            "Чем больше производим, тем меньше постоянных затрат на единицу!");

        private void BtnInfoAVC_Click(object sender, EventArgs e) => ShowTheory("СРЕДНИЕ ПЕРЕМЕННЫЕ ИЗДЕРЖКИ (AVC)",
            "Переменные издержки в расчёте на единицу продукции.\n\n" +
            "💰 Формула: AVC = VC / Q\n" +
            "Или: AVC = сырьё + энергия + сдельная ЗП (на единицу)\n\n" +
            "📈 Динамика: Сначала могут снижаться (эффект масштаба), затем расти (закон убывающей отдачи).\n" +
            "⚠️ Если P < AVC - фирме следует прекратить производство!");

        private void BtnInfoATC_Click(object sender, EventArgs e) => ShowTheory("СРЕДНИЕ СОВОКУПНЫЕ ИЗДЕРЖКИ (ATC)",
            "Совокупные издержки в расчёте на единицу продукции (себестоимость).\n\n" +
            "💰 Формула: ATC = TC / Q  или  ATC = AFC + AVC\n\n" +
            "📈 Динамика: U-образная кривая: сначала снижается, достигает минимума, затем растёт.\n" +
            "Сравнение с ценой:\n" +
            "• P > ATC → прибыль\n" +
            "• P = ATC → нулевая прибыль\n" +
            "• P < ATC → убытки");

        private void BtnInfoMC_Click(object sender, EventArgs e) => ShowTheory("ПРЕДЕЛЬНЫЕ ИЗДЕРЖКИ (MC)",
            "Дополнительные издержки на производство каждой дополнительной единицы продукции.\n\n" +
            "💰 Формула: MC = ΔTC / ΔQ  или  MC = ΔVC / ΔQ\n\n" +
            "📈 Динамика: U-образная кривая, пересекает AVC и ATC в точках их минимума.\n" +
            "Правило максимизации прибыли: Производить до тех пор, пока MR = MC.\n" +
            "• MC < P → выгодно увеличивать производство\n" +
            "• MC > P → выгодно сокращать производство\n" +
            "• MC = P → оптимальный объём выпуска");

        private void ShowTheory(string title, string content)
        {
            MessageBox.Show(content, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}