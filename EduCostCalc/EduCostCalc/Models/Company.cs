using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCostCalc.Models
{
    /// <summary>
    /// Основная сущность компании со всеми параметрами
    /// </summary>
    public class Company
    {
        public ProductionParameters Production { get; set; }
        public VariableCosts VariableCosts { get; set; }
        public FixedCosts FixedCosts { get; set; }
        public TaxSettings TaxSettings { get; set; }

        public Company()
        {
            Production = new ProductionParameters();
            VariableCosts = new VariableCosts();
            FixedCosts = new FixedCosts();
            TaxSettings = new TaxSettings();
        }
    }
}
