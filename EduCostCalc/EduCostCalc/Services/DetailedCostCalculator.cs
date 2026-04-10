using EduCostCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCostCalc.Services
{
    public class DetailedCostCalculator
    {
        private readonly Company _company;

        public DetailedCostCalculator(Company company)
        {
            _company = company;
        }

        #region Расчет себестоимости по статьям

        /// <summary>
        /// Прямые затраты (всего)
        /// </summary>
        public decimal CalculateDirectCosts() =>
            _company.DirectCosts.GetTotalDirectCosts(_company.Production.OutputVolume);

        /// <summary>
        /// Социальные отчисления от прямых затрат (38.5% от ЗП основного персонала)
        /// </summary>
        public decimal CalculateSocialContributionsDirect()
        {
            var mainLaborWageTotal = _company.DirectCosts.MainLaborWagePerUnit *
                                    _company.Production.OutputVolume;
            return mainLaborWageTotal * (_company.TaxSettings.SocialContributionRate / 100m);
        }

        /// <summary>
        /// Производственная себестоимость
        /// </summary>
        public decimal CalculateProductionCost()
        {
            var directCosts = CalculateDirectCosts();
            var socialDirect = CalculateSocialContributionsDirect();
            var productionOverhead = _company.ProductionOverhead.TotalProductionOverhead;
            var administrativeCosts = _company.AdministrativeCosts.TotalAdministrativeCosts;
            var operatingCosts = _company.OperatingCosts.TotalOperatingCosts;

            return directCosts + socialDirect + productionOverhead +
                   administrativeCosts + operatingCosts;
        }

        /// <summary>
        /// Полная себестоимость (с коммерческими расходами)
        /// </summary>
        public decimal CalculateFullCost()
        {
            var productionCost = CalculateProductionCost();
            var commercialCosts = _company.CommercialCosts.TotalCommercialCosts;

            return productionCost + commercialCosts;
        }

        /// <summary>
        /// Себестоимость единицы продукции
        /// </summary>
        public decimal CalculateCostPerUnit()
        {
            if (_company.Production.OutputVolume == 0)
                return 0;

            return CalculateFullCost() / _company.Production.OutputVolume;
        }

        #endregion

        #region Расчет прибыли

        /// <summary>
        /// Выручка (TR)
        /// </summary>
        public decimal CalculateRevenue() => _company.Production.TotalRevenue;

        /// <summary>
        /// Валовая прибыль (Gross Profit)
        /// </summary>
        public decimal CalculateGrossProfit()
        {
            var revenue = CalculateRevenue();
            var productionCost = CalculateProductionCost();
            return revenue - productionCost;
        }

        /// <summary>
        /// Прибыль от реализации (Operating Profit)
        /// </summary>
        public decimal CalculateOperatingProfit()
        {
            var revenue = CalculateRevenue();
            var fullCost = CalculateFullCost();
            return revenue - fullCost;
        }

        /// <summary>
        /// Бухгалтерская прибыль (до налогообложения)
        /// </summary>
        public decimal CalculateAccountingProfitBeforeTax()
        {
            return CalculateOperatingProfit();
        }

        /// <summary>
        /// Налог на прибыль
        /// </summary>
        public decimal CalculateProfitTax()
        {
            var profit = CalculateAccountingProfitBeforeTax();
            return profit > 0 ? profit * (_company.TaxSettings.ProfitTaxRate / 100m) : 0;
        }

        /// <summary>
        /// Чистая прибыль (после налогов)
        /// </summary>
        public decimal CalculateNetProfit()
        {
            return CalculateAccountingProfitBeforeTax() - CalculateProfitTax();
        }

        /// <summary>
        /// Экономическая прибыль (с учетом внутренних издержек)
        /// </summary>
        public decimal CalculateEconomicProfit()
        {
            var netProfit = CalculateNetProfit();
            var implicitCosts = _company.ImplicitCosts.TotalImplicitCosts;
            return netProfit - implicitCosts;
        }

        #endregion

        #region Показатели эффективности

        /// <summary>
        /// Маржинальная прибыль (Contribution Margin)
        /// </summary>
        public decimal CalculateContributionMargin()
        {
            var revenue = CalculateRevenue();
            var variableCosts = CalculateTotalVariableCosts();
            return revenue - variableCosts;
        }

        /// <summary>
        /// Коэффициент маржинальной прибыли
        /// </summary>
        public decimal CalculateContributionMarginRatio()
        {
            var revenue = CalculateRevenue();
            if (revenue == 0) return 0;
            return (CalculateContributionMargin() / revenue) * 100m;
        }

        /// <summary>
        /// Рентабельность продукции (по полной себестоимости)
        /// </summary>
        public decimal CalculateProfitabilityFullCost()
        {
            var fullCost = CalculateFullCost();
            if (fullCost == 0) return 0;
            return (CalculateOperatingProfit() / fullCost) * 100m;
        }

        /// <summary>
        /// Рентабельность продаж (ROS)
        /// </summary>
        public decimal CalculateReturnOnSales()
        {
            var revenue = CalculateRevenue();
            if (revenue == 0) return 0;
            return (CalculateNetProfit() / revenue) * 100m;
        }

        #endregion

        #region Точка безубыточности и запас прочности

        /// <summary>
        /// Точка безубыточности в единицах продукции (BEP units)
        /// BEP = FC / (P - AVC)
        /// </summary>
        public decimal CalculateBreakEvenPointUnits()
        {
            var fixedCosts = CalculateTotalFixedCosts();
            var pricePerUnit = _company.Production.PricePerUnit;
            var avgVariableCostPerUnit = CalculateAverageVariableCostPerUnit();

            if (pricePerUnit <= avgVariableCostPerUnit)
                return -1; // Точка безубыточности недостижима

            return fixedCosts / (pricePerUnit - avgVariableCostPerUnit);
        }

        /// <summary>
        /// Точка безубыточности в денежном выражении (BEP value)
        /// </summary>
        public decimal CalculateBreakEvenPointValue()
        {
            var bepUnits = CalculateBreakEvenPointUnits();
            if (bepUnits < 0) return -1;
            return bepUnits * _company.Production.PricePerUnit;
        }

        /// <summary>
        /// Запас финансовой прочности в единицах
        /// </summary>
        public decimal CalculateSafetyMarginUnits()
        {
            var bepUnits = CalculateBreakEvenPointUnits();
            if (bepUnits < 0) return 0;
            return _company.Production.OutputVolume - bepUnits;
        }

        /// <summary>
        /// Запас финансовой прочности в процентах
        /// </summary>
        public decimal CalculateSafetyMarginPercent()
        {
            var currentVolume = _company.Production.OutputVolume;
            if (currentVolume == 0) return 0;

            var safetyMarginUnits = CalculateSafetyMarginUnits();
            return (safetyMarginUnits / currentVolume) * 100m;
        }

        #endregion

        #region Вспомогательные методы

        private decimal CalculateTotalFixedCosts()
        {
            return _company.ProductionOverhead.TotalProductionOverhead +
                   _company.AdministrativeCosts.TotalAdministrativeCosts +
                   _company.OperatingCosts.TotalOperatingCosts;
        }

        private decimal CalculateTotalVariableCosts()
        {
            var outputVolume = _company.Production.OutputVolume;
            return _company.DirectCosts.GetTotalDirectCosts(outputVolume) +
                   CalculateSocialContributionsDirect() +
                   _company.CommercialCosts.TotalCommercialCosts;
        }

        private decimal CalculateAverageVariableCostPerUnit()
        {
            var outputVolume = _company.Production.OutputVolume;
            if (outputVolume == 0) return 0;
            return CalculateTotalVariableCosts() / outputVolume;
        }

        #endregion
    }
}