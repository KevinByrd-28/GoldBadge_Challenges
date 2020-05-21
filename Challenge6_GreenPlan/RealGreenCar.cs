using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge6_GreenPlan
{
    public enum Color { Green, LimeGreen, DarkGreen, BrightGreen, NeonGreen, ArmyGreen }
    public class RealGreenCar : GasCar
    {
        public decimal PriceDiscount { get; } = -100.00m;
        public Color Color { get; set; }
        public RealGreenCar()
        {

        }

        public RealGreenCar(string aName, int aMileage, Color aColor)
        {
            Name = aName;
            GasMileage = aMileage;
            Color = aColor;
        }
    }
}
