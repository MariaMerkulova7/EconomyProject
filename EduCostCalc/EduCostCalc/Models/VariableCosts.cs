using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCostCalc.Models
{
    /// <summary>
    /// Переменные затраты на единицу продукции
    /// </summary>
    public class VariableCosts
    {
        /// <summary>
        /// Сырье и материалы (руб/шт)
        /// </summary>
        public decimal RawMaterialsPerUnit { get; set; }

        /// <summary>
        /// Энергия/транспорт (руб/шт)
        /// </summary>
        public decimal EnergyTransportPerUnit { get; set; }

        /// <summary>
        /// Сдельная заработная плата (руб/шт)
        /// </summary>
        public decimal PieceworkWagePerUnit { get; set; }

        /// <summary>
        /// Общие переменные затраты на единицу
        /// </summary>
        public decimal TotalVariableCostPerUnit =>
            RawMaterialsPerUnit + EnergyTransportPerUnit + PieceworkWagePerUnit;

        /// <summary>
        /// Общие переменные затраты за период (VC = AVC * Q)
        /// </summary>
        public decimal GetTotalVariableCosts(decimal outputVolume) =>
            TotalVariableCostPerUnit * outputVolume;
    }
}