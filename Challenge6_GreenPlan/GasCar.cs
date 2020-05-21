using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge6_GreenPlan
{
    public class GasCar
    {
        public string Name { get; set;}
        public int GasMileage { get; set; }

        public GasCar()
        {

        }

        public GasCar(string aName, int aMileage)
        {
            Name = aName;
            GasMileage = aMileage;
        }
    }
}
