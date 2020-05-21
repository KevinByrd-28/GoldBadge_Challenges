using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge6_GreenPlan
{
    public class RealGreenCarRepository
    {
        private List<RealGreenCar> _realGreenDirectory = new List<RealGreenCar>();


        //CRUD - Create, Read, Update, Delete
        public bool AddRealGreenCarToDirectory(RealGreenCar item)
        {
            int startingCount = _realGreenDirectory.Count;
            _realGreenDirectory.Add(item);
            bool wasAdded = _realGreenDirectory.Count == startingCount + 1;
            return wasAdded;
        }

        public List<RealGreenCar> GetRealGreenContents()
        {
            return _realGreenDirectory;
        }

        public RealGreenCar GetRealGreenByName(string name)
        {
            foreach (RealGreenCar item in _realGreenDirectory)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;

        }

        public bool UpdateRealGreenByName(string name, RealGreenCar newCar)
        {
            RealGreenCar item = GetRealGreenByName(name);

            if (item == null)
            {
                return false;
            }
            else
            {
                item.Name = newCar.Name;
                item.GasMileage = newCar.GasMileage;
                item.Color = newCar.Color;
                return true;
            }
        }

        public bool RemoveRealGreenByName(string name)
        {
            RealGreenCar item = GetRealGreenByName(name);

            if (item == null)
            {
                Console.WriteLine("This is not the car you want");
                return false;
            }
            else
            {
                _realGreenDirectory.Remove(item);
                return true;
            }
        }
    }
}
