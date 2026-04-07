using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCostCalc.Models
{
    /// <summary>
    /// Налоговые настройки и социальные отчисления
    /// </summary>
    public class TaxSettings
    {
        /// <summary>
        /// Ставка социальных отчислений (% от ФОТ, по умолчанию 38.5)
        /// </summary>
        public decimal SocialContributionRate { get; set; } = 38.5m;

        /// <summary>
        /// Ставка налога на прибыль (%)
        /// </summary>
        public decimal ProfitTaxRate { get; set; } = 20.0m;

        /// <summary>
        /// Коэффициент социальных отчислений (для расчетов)
        /// </summary>
        public decimal SocialContributionCoefficient => SocialContributionRate / 100m;

        /// <summary>
        /// Коэффициент налога на прибыль (для расчетов)
        /// </summary>
        public decimal ProfitTaxCoefficient => ProfitTaxRate / 100m;
    }
}
