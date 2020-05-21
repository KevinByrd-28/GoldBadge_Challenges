using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge6_GreenPlan
{
    public class ElectricCar : GasCar
    {
        public decimal PriceDiscount { get; } = -50.00m;
        public ElectricCar()
        {

        }

        public ElectricCar(string aName, int aMileage)
        {
            Name = aName;
            GasMileage = aMileage;
        }



    }
}
