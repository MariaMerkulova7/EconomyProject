using EduCostCalc.Models;

namespace EduCostCalc.Services
{
    /// <summary>
    /// Сервис для расчета издержек и прибыли
    /// </summary>
    public class CostCalculator
    {
        private readonly Company _company;

        public CostCalculator(Company company)
        {
            _company = company;
        }

        /// <summary>
        /// Расчет фонда оплаты труда (сдельная часть)
        /// </summary>
        public decimal CalculatePieceworkFund() =>
            _company.VariableCosts.PieceworkWagePerUnit * _company.Production.OutputVolume;

        /// <summary>
        /// Расчет социальных отчислений
        /// </summary>
        public decimal CalculateSocialContributions()
        {
            // Соц. отчисления начисляются на всю ЗП (сдельную + окладную)
            decimal totalWageFund = CalculatePieceworkFund() + _company.FixedCosts.SalaryAdministrative;
            return totalWageFund * _company.TaxSettings.SocialContributionCoefficient;
        }

        /// <summary>
        /// Общие (совокупные) издержки TC = FC + VC
        /// </summary>
        public decimal CalculateTotalCosts()
        {
            decimal variableCosts = _company.VariableCosts.GetTotalVariableCosts(_company.Production.OutputVolume);
            decimal fixedCosts = _company.FixedCosts.TotalFixedCosts;
            decimal socialContributions = CalculateSocialContributions();

            return variableCosts + fixedCosts + socialContributions;
        }

        /// <summary>
        /// Средние общие издержки ATC = TC / Q
        /// </summary>
        public decimal CalculateAverageTotalCost()
        {
            if (_company.Production.OutputVolume == 0)
                return 0;

            return CalculateTotalCosts() / _company.Production.OutputVolume;
        }

        /// <summary>
        /// Средние постоянные издержки AFC = FC / Q
        /// </summary>
        public decimal CalculateAverageFixedCost()
        {
            if (_company.Production.OutputVolume == 0)
                return 0;

            return _company.FixedCosts.TotalFixedCosts / _company.Production.OutputVolume;
        }

        /// <summary>
        /// Средние переменные издержки AVC = VC / Q
        /// </summary>
        public decimal CalculateAverageVariableCost()
        {
            if (_company.Production.OutputVolume == 0)
                return 0;

            return _company.VariableCosts.TotalVariableCostPerUnit;
        }

        /// <summary>
        /// Бухгалтерская прибыль = TR - Явные издержки
        /// </summary>
        public decimal CalculateAccountingProfit()
        {
            return _company.Production.TotalRevenue - CalculateTotalCosts();
        }

        /// <summary>
        /// Налог на прибыль
        /// </summary>
        public decimal CalculateProfitTax()
        {
            decimal profit = CalculateAccountingProfit();
            return profit > 0 ? profit * _company.TaxSettings.ProfitTaxCoefficient : 0;
        }

        /// <summary>
        /// Чистая прибыль (после налогообложения)
        /// </summary>
        public decimal CalculateNetProfit()
        {
            return CalculateAccountingProfit() - CalculateProfitTax();
        }

        /// <summary>
        /// Рентабельность продукции = (Прибыль / Себестоимость) * 100%
        /// </summary>
        public decimal CalculateProfitability()
        {
            decimal totalCosts = CalculateTotalCosts();
            if (totalCosts == 0)
                return 0;

            return (CalculateAccountingProfit() / totalCosts) * 100m;
        }

        /// <summary>
        /// Точка безубыточности (в единицах продукции)
        /// BEP = FC / (P - AVC)
        /// </summary>
        public decimal CalculateBreakEvenPoint()
        {
            decimal pricePerUnit = _company.Production.PricePerUnit;
            decimal avgVariableCost = _company.VariableCosts.TotalVariableCostPerUnit;

            if (pricePerUnit <= avgVariableCost)
                return -1; // Точка безубыточности недостижима

            return _company.FixedCosts.TotalFixedCosts / (pricePerUnit - avgVariableCost);
        }

        /// <summary>
        /// Запас финансовой прочности (в %)
        /// </summary>
        public decimal CalculateSafetyMargin()
        {
            decimal bep = CalculateBreakEvenPoint();
            if (bep < 0 || _company.Production.OutputVolume == 0)
                return 0;

            return ((_company.Production.OutputVolume - bep) / _company.Production.OutputVolume) * 100m;
        }

        // Вспомогательные методы
        public decimal GetTotalVariableCosts() =>
            _company.VariableCosts.GetTotalVariableCosts(_company.Production.OutputVolume);

        public decimal CalculateTotalRevenue() => _company.Production.TotalRevenue;

        /// <summary>
        /// Предельные издержки (MC = ΔTC / ΔQ). 
        /// В линейной модели при ΔQ=1: MC = Переменные затраты на ед. + Соц. отчисления на доп. ЗП.
        /// </summary>
        public decimal CalculateMarginalCost()
        {
            if (_company.Production.OutputVolume <= 0) return 0;

            // MC = d(TC)/dQ. Постоянные издержки (FC) не влияют на прирост.
            // На каждую дополнительную единицу тратятся:
            // 1. Сырьё + Энергия + Сдельная ЗП (уже есть в TotalVariableCostPerUnit)
            // 2. Соц. отчисления именно на эту дополнительную сдельную ЗП
            decimal variablePerUnit = _company.VariableCosts.TotalVariableCostPerUnit;
            decimal socialOnMarginalWage = _company.VariableCosts.PieceworkWagePerUnit *
                                           _company.TaxSettings.SocialContributionCoefficient;

            return variablePerUnit + socialOnMarginalWage;
        } 
    }
}