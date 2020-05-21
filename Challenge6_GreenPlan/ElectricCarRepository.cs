using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge6_GreenPlan
{
    public class ElectricCarRepository
    {
        private List<ElectricCar> _electricDirectory = new List<ElectricCar>();


        //CRUD - Create, Read, Update, Delete
        public bool AddElectricCarToDirectory(ElectricCar item)
        {
            int startingCount = _electricDirectory.Count;
            _electricDirectory.Add(item);
            bool wasAdded = _electricDirectory.Count == startingCount + 1;
            return wasAdded;
        }

        public List<ElectricCar> GetElectricContents()
        {
            return _electricDirectory;
        }

        public ElectricCar GetElectricByName(string name)
        {
            foreach (ElectricCar item in _electricDirectory)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;

        }

        public bool UpdateElectricByName(string name, ElectricCar newCar)
        {
            ElectricCar item = GetElectricByName(name);

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

        public bool RemoveElectricByName(string name)
        {
            ElectricCar item = GetElectricByName(name);

            if (item == null)
            {
                Console.WriteLine("This is not the car you want");
                return false;
            }
            else
            {
                _electricDirectory.Remove(item);
                return true;
            }
        }
    }
}
