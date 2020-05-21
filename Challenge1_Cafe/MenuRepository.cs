using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Cafe
{
    public class MenuRepository
    {
        private List<Menu> _menuList = new List<Menu>(); 


        //CRUD - Create, Read, Update, Delete - Don't need Update for this challenge
        public bool AddItemToMenuList(Menu item)
        {
            int startingCount = _menuList.Count;
            _menuList.Add(item);
            bool wasAdded = _menuList.Count == startingCount + 1;
            return wasAdded;
        }

        public List<Menu> GetMenuList()
        {
            return _menuList;
        }

        public Menu GetItemByName(string name)
        {
            foreach (Menu item in _menuList)
            {
                if (item.Name.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;

        }

        public bool RemoveItemByName(string name)
        {
            Menu item = GetItemByName(name);

            if (item == null)
            {
                Console.WriteLine("This is not the item you want");
                return false;
            }
            else
            {
                _menuList.Remove(item);
                return true;
            }
        }


         public void MenuSeed()//to easily add some data to a new method later on, since we were copying this in so many times, this saves us a step
         {

            List<Ingredient> _chickSandIngred = new List<Ingredient>();
            Ingredient chicken = new Ingredient("chicken");
            Ingredient bread = new Ingredient("bread");

            //Act or performed an action
            _chickSandIngred.Add(chicken);
            _chickSandIngred.Add(bread);

            //Arranged Data
            Menu chickenSandwich = new Menu(1, "Chicken Sandwich", "Chicken on a bun", _chickSandIngred, 5.99);
            Menu spicyChickSandwich = new Menu(2, "Spicy Chicken Sandwich", "Spicy Chicken on a bun", _chickSandIngred, 6.99);

             //Act or performed an action
            AddItemToMenuList(chickenSandwich);
            AddItemToMenuList(spicyChickSandwich);
            
         }


    }
}
