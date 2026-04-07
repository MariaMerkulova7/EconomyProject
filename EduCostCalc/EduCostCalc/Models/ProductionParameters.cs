using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCostCalc.Models
{
    /// <summary>
    /// Параметры производства: объем выпуска и цена
    /// </summary>
    public class ProductionParameters
    {
        /// <summary>
        /// Объем выпуска Q (шт/мес)
        /// </summary>
        public decimal OutputVolume { get; set; }

        /// <summary>
        /// Цена реализации P (руб/шт)
        /// </summary>
        public decimal PricePerUnit { get; set; }

        /// <summary>
        /// Выручка (TR = P * Q)
        /// </summary>
        public decimal TotalRevenue => OutputVolume * PricePerUnit;
    }
}
