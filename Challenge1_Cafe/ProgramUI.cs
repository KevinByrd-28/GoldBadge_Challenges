using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge1_Cafe
{
    class ProgramUI
    {
        private MenuRepository _repo = new MenuRepository();

        public void Run()
        {
            SeedMenuList();
            RunMenu();//calling the runmenu method
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of your selection: \n" +
                    "1. Create New Menu Item\n" +
                    "2. Delete Menu Item\n" +
                    "3. Print Full Menu List\n" +
                    "4. Exit"
                    );

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        //create new menu item
                        CreateNewMenuItem();
                        Console.ReadKey();//pauses the screen line readline, but without taking in data
                        break;
                    case "2":
                        //delete menu item
                        RemoveItemFromMenu();
                        Console.ReadKey();
                        break;
                    case "3":
                        //print full menu
                        PrintMenu();
                        Console.ReadKey();
                        break;
                    case "4":
                        continueToRun = false;
                        Console.WriteLine("Goodbye!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Incorrect Entry");
                        Console.ReadKey();//pauses the screen line readline, but wihtout taking in data
                        break;
                }
            }
        }

        //--for option 1 on prompt -----------------------------------

        public void CreateNewMenuItem()
        {
            Console.Clear();
            Console.Write("Enter A Meal Number: ");
            int aMealNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("What Do You Want To Call It? ");
            string aName = Console.ReadLine();

            Console.Write("Describe It: ");
            string aDescription = Console.ReadLine();

            Console.Write("List The Ingredients: ");
            string list = Console.ReadLine();
            string[] words = list.Split(',');

            List<Ingredient> _ingredientList = new List<Ingredient>();
            foreach (string ingredientItem in words)
            {
                Ingredient i = new Ingredient(ingredientItem);
                _ingredientList.Add(i);
            }

            Console.Write("How Much Will It Cost? ");

            double aPrice = Convert.ToDouble(Console.ReadLine());


            Menu newItem = new Menu(aMealNumber, aName, aDescription, _ingredientList, aPrice);

            _repo.AddItemToMenuList(newItem);
            Console.WriteLine("New item added!");
            Console.ReadLine();
        }

        //-----Option 2 on prompt------------------------------
        private void RemoveItemFromMenu()
        {
            Console.Write("Enter a menu item to remove: ");
            string nameEntry = Console.ReadLine();

            _repo.RemoveItemByName(nameEntry);
            Console.WriteLine("This item is off the menu!");
        }



        //-----Option 3 on prompt----------------------------
        public void PrintMenu()
        {
            Console.Clear();
            List<Menu> listOfItems = _repo.GetMenuList();

            foreach (Menu menuItem in listOfItems)
            {
                DisplayContent(menuItem);
            }
        }
        public void DisplayContent(Menu item)
        {
            Console.WriteLine($"{item.Name}, a delicious {item.Description} is {item.Price}");
        }



        private void SeedMenuList()
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
            _repo.AddItemToMenuList(chickenSandwich);
            _repo.AddItemToMenuList(spicyChickSandwich);

        }

        

        

    }
}
