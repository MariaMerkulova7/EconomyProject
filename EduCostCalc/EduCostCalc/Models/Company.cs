using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EduCostCalc.Models
{
    public class Company
    {
        public ProductionParameters Production { get; set; }
        public VariableCosts VariableCosts { get; set; }
        public FixedCosts FixedCosts { get; set; }
        public TaxSettings TaxSettings { get; set; }

        // Новая детальная структура
        public DirectCosts DirectCosts { get; set; }
        public ProductionOverheadCosts ProductionOverhead { get; set; }
        public AdministrativeCosts AdministrativeCosts { get; set; }
        public OperatingCosts OperatingCosts { get; set; }
        public CommercialCosts CommercialCosts { get; set; }
        public ImplicitCosts ImplicitCosts { get; set; }

        public Company()
        {
            Production = new ProductionParameters();
            VariableCosts = new VariableCosts();
            FixedCosts = new FixedCosts();
            TaxSettings = new TaxSettings();
            DirectCosts = new DirectCosts();
            ProductionOverhead = new ProductionOverheadCosts();
            AdministrativeCosts = new AdministrativeCosts();
            OperatingCosts = new OperatingCosts();
            CommercialCosts = new CommercialCosts();
            ImplicitCosts = new ImplicitCosts();
        }
    }
}