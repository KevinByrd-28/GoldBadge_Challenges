using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge6_GreenPlan
{
    public class HybridCar : GasCar
    {
        public decimal PriceDiscount { get; } = -25.00m;
        public HybridCar()
        {

        }

        public HybridCar(string aName, int aMileage)
        {
            Name = aName;
            GasMileage = aMileage;
        }

    }
}
