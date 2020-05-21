using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Cafe
{
    public class Menu
    {
        public int MealNumber { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredient { get; set; }
        public double Price { get; set; }

        public Menu()
        {

        }

        public Menu(int aMealNumber, string aName, string aDescription, List<Ingredient> aIngredient, double aPrice)
        {
            MealNumber = aMealNumber;
            Name = aName;
            Description = aDescription;
            Ingredient = aIngredient;
            Price = aPrice;
        }

    }
}
