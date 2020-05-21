using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge6_GreenPlan
{
    public class GasCarRepository
    {
        private List<GasCar> _gasDirectory = new List<GasCar>();



        //CRUD - Create, Read, Update, Delete
        public bool AddGasCarToDirectory(GasCar item)
        {
            int startingCount = _gasDirectory.Count;
            _gasDirectory.Add(item);
            bool wasAdded = _gasDirectory.Count == startingCount + 1;
            return wasAdded;
        }

        public List<GasCar> GetGasContents()
        {
            return _gasDirectory;
        }

        public GasCar GetGasByName(string name)
        {
            foreach (GasCar item in _gasDirectory)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;

        }

        public bool UpdateGasByName(string name, GasCar newCar)
        {
            GasCar item = GetGasByName(name);

            if (item == null)
            {
                return false;
            }
            else
            {
                item.Name = newCar.Name;
                item.GasMileage = newCar.GasMileage;
                return true;
            }
        }

        public bool RemoveGasByName(string name)
        {
            GasCar item = GetGasByName(name);

            if (item == null)
            {
                Console.WriteLine("This is not the car you want");
                return false;
            }
            else
            {
                _gasDirectory.Remove(item);
                return true;
            }
        }




    }
}
