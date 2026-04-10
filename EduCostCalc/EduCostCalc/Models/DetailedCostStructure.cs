using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCostCalc.Models
{
    /// <summary>
    /// Прямые затраты
    /// </summary>
    public class DirectCosts
    {
        public decimal RawMaterialsPerUnit { get; set; }
        public decimal MainLaborWagePerUnit { get; set; }

        public decimal TotalDirectCostsPerUnit =>
            RawMaterialsPerUnit + MainLaborWagePerUnit;

        public decimal GetTotalDirectCosts(decimal outputVolume) =>
            TotalDirectCostsPerUnit * outputVolume;
    }

    /// <summary>
    /// Общепроизводственные расходы
    /// </summary>
    public class ProductionOverheadCosts
    {
        public decimal AuxiliaryLaborWage { get; set; }
        public decimal TechnologicalEnergyWater { get; set; }
        public decimal OtherProductionOverheadPercent { get; set; } = 13m;

        public decimal OtherProductionOverhead
        {
            get
            {
                var baseAmount = AuxiliaryLaborWage + TechnologicalEnergyWater;
                return baseAmount * (OtherProductionOverheadPercent / 100m);
            }
        }

        public decimal TotalProductionOverhead =>
            AuxiliaryLaborWage + TechnologicalEnergyWater + OtherProductionOverhead;
    }

    /// <summary>
    /// Общезаводские (административные) расходы
    /// </summary>
    public class AdministrativeCosts
    {
        public decimal AdministrativeStaffWage { get; set; }
        public decimal Rent { get; set; }
        public decimal Heating { get; set; }
        public decimal Communication { get; set; }
        public decimal Security { get; set; }
        public decimal OfficeSupplies { get; set; }
        public decimal OtherAdministrativePercent { get; set; } = 13m;

        public decimal OtherAdministrative
        {
            get
            {
                var baseAmount = AdministrativeStaffWage + Rent + Heating +
                               Communication + Security + OfficeSupplies;
                return baseAmount * (OtherAdministrativePercent / 100m);
            }
        }

        public decimal TotalAdministrativeCosts =>
            AdministrativeStaffWage + Rent + Heating + Communication +
            Security + OfficeSupplies + OtherAdministrative;
    }

    /// <summary>
    /// Эксплуатационные расходы
    /// </summary>
    public class OperatingCosts
    {
        public decimal Depreciation { get; set; }
        public decimal LeasePayments { get; set; }
        public decimal LoanInterest { get; set; }
        public decimal TaxesIncludedInCost { get; set; }

        public decimal TotalOperatingCosts =>
            Depreciation + LeasePayments + LoanInterest + TaxesIncludedInCost;
    }

    /// <summary>
    /// Коммерческие расходы
    /// </summary>
    public class CommercialCosts
    {
        public decimal SalesStaffWage { get; set; }
        public decimal SocialContributionsForSales =>
            SalesStaffWage * 0.385m; // 38.5%
        public decimal OtherCommercialPercent { get; set; } = 13m;

        public decimal OtherCommercial
        {
            get
            {
                var baseAmount = SalesStaffWage + SocialContributionsForSales;
                return baseAmount * (OtherCommercialPercent / 100m);
            }
        }

        public decimal TotalCommercialCosts =>
            SalesStaffWage + SocialContributionsForSales + OtherCommercial;
    }

    /// <summary>
    /// Внутренние (неявные) издержки
    /// </summary>
    public class ImplicitCosts
    {
        public decimal OpportunityCostCapital { get; set; } // Упущенный процент на капитал
        public decimal OpportunityCostOwnerLabor { get; set; } // Упущенная ЗП владельца
        public decimal OpportunityCostRent { get; set; } // Упущенная рента
        public decimal NormalProfit { get; set; } // Нормальная прибыль

        public decimal TotalImplicitCosts =>
            OpportunityCostCapital + OpportunityCostOwnerLabor +
            OpportunityCostRent + NormalProfit;
    }
}