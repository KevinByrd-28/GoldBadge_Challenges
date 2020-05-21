using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge6_GreenPlan
{
    public class HybridCarRepository
    {

        private List<HybridCar> _hybridDirectory = new List<HybridCar>();


        //CRUD - Create, Read, Update, Delete
        public bool AddHybridCarToDirectory(HybridCar item)
        {
            int startingCount = _hybridDirectory.Count;
            _hybridDirectory.Add(item);
            bool wasAdded = _hybridDirectory.Count == startingCount + 1;
            return wasAdded;
        }

        public List<HybridCar> GetHybridContents()
        {
            return _hybridDirectory;
        }

        public HybridCar GetHybridByName(string name)
        {
            foreach (HybridCar item in _hybridDirectory)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;

        }

        public bool UpdateHybridByName(string name, HybridCar newCar)
        {
            HybridCar item = GetHybridByName(name);

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

        public bool RemoveHybridByName(string name)
        {
            HybridCar item = GetHybridByName(name);

            if (item == null)
            {
                Console.WriteLine("This is not the car you want");
                return false;
            }
            else
            {
                _hybridDirectory.Remove(item);
                return true;
            }
        }
    }
}
