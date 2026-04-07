using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCostCalc.Models
{
    /// <summary>
    /// Постоянные затраты (в месяц)
    /// </summary>
    public class FixedCosts
    {
        /// <summary>
        /// Аренда помещения
        /// </summary>
        public decimal Rent { get; set; }

        /// <summary>
        /// Амортизация оборудования
        /// </summary>
        public decimal Depreciation { get; set; }

        /// <summary>
        /// Окладная часть ЗП (управление, охрана)
        /// </summary>
        public decimal SalaryAdministrative { get; set; }

        /// <summary>
        /// Коммунальные услуги (фикс.)
        /// </summary>
        public decimal Utilities { get; set; }

        /// <summary>
        /// Проценты по кредитам
        /// </summary>
        public decimal LoanInterest { get; set; }

        /// <summary>
        /// Общие постоянные издержки (FC)
        /// </summary>
        public decimal TotalFixedCosts =>
            Rent + Depreciation + SalaryAdministrative + Utilities + LoanInterest;
    }
}
