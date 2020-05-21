using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge6_GreenPlan
{
    class ProgramUI
    {
        private ElectricCarRepository _repoElectric = new ElectricCarRepository();
        private GasCarRepository _repoGas = new GasCarRepository();
        private HybridCarRepository _repoHybrid = new HybridCarRepository();
        private RealGreenCarRepository _repoRealGreen = new RealGreenCarRepository();

        public void Run()
        {
            SeedElectric();
            SeedGas();
            SeedHybrid();
            SeedRealGreen();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of your selection: \n" +
                    "1. See All Gas Cars\n" +
                    "2. See All Hybrid Cars\n" +
                    "3. See All Electric Cars\n" +
                    "4. See All Cars That Are Truely Green\n" +
                    "5. Add A Car To A List\n" +
                    "6. Remove A Car From A List\n" +
                    "7. Update Fuel Economy On A Car\n" +
                    "8. Exit"
                    );

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        //see all Gas Cars
                        PrintAllGas();
                        Console.ReadKey();
                        break;
                    case "2":
                        //see all Hybrid Cars
                        PrintAllHybrid();
                        Console.ReadKey();
                        break;
                    case "3":
                        //see all Electric Cars
                        PrintAllElectric();
                        Console.ReadKey();
                        break;
                    case "4":
                        //see all Cars that are actually Green
                        PrintAllRealGreen();
                        Console.ReadKey();
                        break;
                    case "5":
                        //add car to list
                        AddCar();
                        Console.ReadKey();
                        break;
                    case "6":
                        //remove car from list
                        RemoveCar();
                        Console.ReadKey();
                        break;
                    case "7":
                        //update car
                        UpdateCar();
                        Console.ReadKey();
                        break;
                    case "8":
                        continueToRun = false;
                        Console.WriteLine("Goodbye!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Incorrect Entry");
                        Console.ReadKey();
                        break;
                }
            }
        }

        //--for option 1 on prompt -----------------------------------

        public void PrintAllGas()
        {
            Console.Clear();
            List<GasCar> listOfCars = _repoGas.GetGasContents();
            
            Console.WriteLine($"\n {"Car",-20}  {"Gas Mileage",-30}\n");
            foreach (GasCar line in listOfCars)
            {
                DisplayContent(line);
            }
        }
        public void DisplayContent(GasCar item)
        {
            Console.WriteLine($"{item.Name,-20} {item.GasMileage,-30}\n");
        }

        public void PrintAllHybrid()
        {
            Console.Clear();
            List<HybridCar> listOfCars = _repoHybrid.GetHybridContents();

            Console.WriteLine($"\n {"Car",-20}  {"Gas Mileage",-30}\n");
            foreach (HybridCar line in listOfCars)
            {
                DisplayContent(line);
            }
        }
        public void DisplayContent(HybridCar item)
        {
            Console.WriteLine($"{item.Name,-20} {item.GasMileage,-30}\n");
        }

        public void PrintAllElectric()
        {
            Console.Clear();
            List<ElectricCar> listOfCars = _repoElectric.GetElectricContents();

            Console.WriteLine($"\n {"Car",-20}  {"Gas Mileage",-30}\n");
            foreach (ElectricCar line in listOfCars)
            {
                DisplayContent(line);
            }
        }
        public void DisplayContent(ElectricCar item)
        {
            Console.WriteLine($"{item.Name,-20} {item.GasMileage,-30}\n");
        }

        public void PrintAllRealGreen()
        {
            Console.Clear();
            List<RealGreenCar> listOfCars = _repoRealGreen.GetRealGreenContents();

            Console.WriteLine($"\n {"Car",-20}  {"Gas Mileage",-30} {"Color", -30}\n");
            foreach (RealGreenCar line in listOfCars)
            {
                DisplayContent(line);
            }
        }
        public void DisplayContent(RealGreenCar item)
        {
            Console.WriteLine($"{item.Name,-20} {item.GasMileage,-30} {item.Color, -30}\n");
        }


        //-----Option 2 on prompt------------------------------
        public void AddCar()
        {
            Console.Clear();

            string aDescription = Console.ReadLine();
            Console.Write("Enter Car Name (Make + Model): ");
            string aCarName = Console.ReadLine();

            Console.Write("How Many Miles Will It Drive On 1 Gallon Of Gasoline? ");
            int aGasMileage = Convert.ToInt32(Console.ReadLine());

            Console.Write("What Type Of Car Is This?\n" +
                "1. Gasoline Powered!\n" +
                "2. Hybrid Boring?\n" +
                "3. Electric Interesting?\n" +
                "4. True Green Cars That Save The World!");
            string selection = Console.ReadLine();
            switch (selection)
            {
                case "1":
                    //gas
                    GasCar newGas = new GasCar(aCarName, aGasMileage);
                    _repoGas.AddGasCarToDirectory(newGas);
                    Console.ReadKey();
                    break;
                case "2":
                    //hybrid
                    HybridCar newHybrid = new HybridCar(aCarName, aGasMileage);
                    _repoHybrid.AddHybridCarToDirectory(newHybrid);
                    Console.ReadKey();
                    break;
                case "3":
                    //electric
                    ElectricCar newElectric = new ElectricCar(aCarName, aGasMileage);
                    _repoElectric.AddElectricCarToDirectory(newElectric);
                    Console.ReadKey();
                    break;
                case "4":
                    //green
                    Console.Write("What Beautiful Shade Of Green? (Green, LimeGreen, DarkGreen, BrightGreen, NeonGreen, ArmyGreen) ");
                    string color = Console.ReadLine();
                    if(color == "Green")
                    {
                        RealGreenCar newRealGreen = new RealGreenCar(aCarName, aGasMileage, Color.Green);
                        _repoRealGreen.AddRealGreenCarToDirectory(newRealGreen);
                    }else if (color == "LimeGreen")
                    {
                        RealGreenCar newRealGreen = new RealGreenCar(aCarName, aGasMileage, Color.LimeGreen);
                        _repoRealGreen.AddRealGreenCarToDirectory(newRealGreen);
                    }
                    else if (color == "DarkGreen")
                    {
                        RealGreenCar newRealGreen = new RealGreenCar(aCarName, aGasMileage, Color.DarkGreen);
                        _repoRealGreen.AddRealGreenCarToDirectory(newRealGreen);
                    }
                    else if (color == "BrightGreen")
                    {
                        RealGreenCar newRealGreen = new RealGreenCar(aCarName, aGasMileage, Color.BrightGreen);
                        _repoRealGreen.AddRealGreenCarToDirectory(newRealGreen);
                    }
                    else if (color == "NeonGreen")
                    {
                        RealGreenCar newRealGreen = new RealGreenCar(aCarName, aGasMileage, Color.NeonGreen);
                        _repoRealGreen.AddRealGreenCarToDirectory(newRealGreen);
                    }
                    else if (color == "ArmyGreen")
                    {
                        RealGreenCar newRealGreen = new RealGreenCar(aCarName, aGasMileage, Color.ArmyGreen);
                        _repoRealGreen.AddRealGreenCarToDirectory(newRealGreen);
                    }
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Incorrect Entry");
                    Console.ReadKey();
                    break;
            }
            Console.WriteLine("New car added!");
            Console.ReadLine();
            RunMenu();

        }

        //-----Option 3 on prompt----------------------------
        public void RemoveCar()
        {
            Console.Write("What Car Do You Want To Remove?\n" +
                "1.Gas Car\n" +
                "2.Hybrid Car\n" +
                "3.Electric Car\n" +
                "4.World Saving Green Car *Captain Planet Will Not Be Happy With You*");
            string car = Console.ReadLine();

            switch (car)
            {
                case "1":
                    //gas
                    Console.Write("Car To Remove: ");
                    string removal = Console.ReadLine();
                    _repoGas.RemoveGasByName(removal);
                    Console.ReadKey();
                    break;
                case "2":
                    //hybrid
                    Console.Write("Car To Remove: ");
                    string removal1 = Console.ReadLine();
                    _repoHybrid.RemoveHybridByName(removal1);
                    Console.ReadKey();
                    break;
                case "3":
                    //electric
                    Console.Write("Car To Remove: ");
                    string removal2 = Console.ReadLine();
                    _repoElectric.RemoveElectricByName(removal2);
                    Console.ReadKey();
                    break;
                case "4":
                    //green
                    Console.Write("..Ok, It's Your Funeral...Car To Remove: ");
                    string removal3 = Console.ReadLine();
                    _repoRealGreen.RemoveRealGreenByName(removal3);
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Incorrect Entry");
                    Console.ReadKey();
                    break;
            }
            Console.WriteLine("Car Has Been Removed");
            Console.ReadKey();
            RunMenu();
        }

        //-----Option 4 on prompt----------------------------

        public void UpdateCar()
        {
            Console.Write("What Car Do You Want To Update?\n" +
                "1.Gas Car\n" +
                "2.Hybrid Car\n" +
                "3.Electric Car\n" +
                "4.World Saving Green Car");
            string car = Console.ReadLine();

            switch (car)
            {
                case "1":
                    //gas
                    Console.WriteLine("What Car Do You Want To Update: ");
                    string gas = Console.ReadLine();
                    Console.WriteLine("What Is The New Fuel Economy: ");
                    int fuel = Convert.ToInt32(Console.ReadLine());
                    GasCar newCar = new GasCar(gas, fuel);
                    _repoGas.UpdateGasByName(gas, newCar);
                    Console.ReadKey();
                    break;
                case "2":
                    //hybrid
                    Console.WriteLine("What Car Do You Want To Update: ");
                    string hybrid = Console.ReadLine();
                    Console.WriteLine("What Is The New Fuel Economy: ");
                    int fuel1 = Convert.ToInt32(Console.ReadLine());
                    HybridCar newCar1 = new HybridCar(hybrid, fuel1);
                    _repoHybrid.UpdateHybridByName(hybrid, newCar1);
                    Console.ReadKey();
                    break;
                case "3":
                    //electric
                    Console.WriteLine("What Car Do You Want To Update: ");
                    string electric = Console.ReadLine();
                    Console.WriteLine("What Is The New Fuel Economy: ");
                    int fuel2 = Convert.ToInt32(Console.ReadLine());
                    ElectricCar newCar2 = new ElectricCar(electric, fuel2);
                    _repoElectric.UpdateElectricByName(electric, newCar2);
                    Console.ReadKey();
                    break;
                case "4":
                    //green
                    Console.WriteLine("What Car Do You Want To Update: ");
                    string green = Console.ReadLine();
                    Console.Write("What Is The New Fuel Economy: ");
                    int fuel3 = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Green? I Shure Hope So, So Which Is It? (Green, LimeGreen, DarkGreen, BrightGreen, NeonGreen, ArmyGreen) ");
                    string color = Console.ReadLine();
                    if (color == "Green")
                    {
                        RealGreenCar newCar3 = new RealGreenCar(green, fuel3, Color.Green);
                        _repoRealGreen.UpdateRealGreenByName(green, newCar3);
                    }
                    else if (color == "LimeGreen")
                    {
                        RealGreenCar newCar3 = new RealGreenCar(green, fuel3, Color.LimeGreen);
                        _repoRealGreen.UpdateRealGreenByName(green, newCar3);
                    }
                    else if (color == "DarkGreen")
                    {
                        RealGreenCar newCar3 = new RealGreenCar(green, fuel3, Color.DarkGreen);
                        _repoRealGreen.UpdateRealGreenByName(green, newCar3);
                    }
                    else if (color == "BrightGreen")
                    {
                        RealGreenCar newCar3 = new RealGreenCar(green, fuel3, Color.BrightGreen);
                        _repoRealGreen.UpdateRealGreenByName(green, newCar3);
                    }
                    else if (color == "NeonGreen")
                    {
                        RealGreenCar newCar3 = new RealGreenCar(green, fuel3, Color.NeonGreen);
                        _repoRealGreen.UpdateRealGreenByName(green, newCar3);
                    }
                    else if (color == "ArmyGreen")
                    {
                        RealGreenCar newCar3 = new RealGreenCar(green, fuel3, Color.ArmyGreen);
                        _repoRealGreen.UpdateRealGreenByName(green, newCar3);
                    }
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Incorrect Entry");
                    Console.ReadKey();
                    break;
            }
            Console.WriteLine("Car Has Been Updated!");
            Console.ReadKey();
            RunMenu();
        }

        private void SeedElectric()
        {
            ElectricCar modelX = new ElectricCar("Tesla Model X", 1000);
            ElectricCar modelS = new ElectricCar("Tesla Model Y", 1000);

            _repoElectric.AddElectricCarToDirectory(modelX);
            _repoElectric.AddElectricCarToDirectory(modelS);

        }
        private void SeedGas()
        {
            GasCar f150 = new GasCar("Ford F-150", 16);
            GasCar fiestaST = new GasCar("Ford Fiesta ST", 25);

            _repoGas.AddGasCarToDirectory(f150);
            _repoGas.AddGasCarToDirectory(fiestaST);

        }
        private void SeedHybrid()
        {
            HybridCar spyder = new HybridCar("Porsche 918 Spyder", 81);
            HybridCar prius = new HybridCar("Toyota Prius", 45);
           
            _repoHybrid.AddHybridCarToDirectory(spyder);
            _repoHybrid.AddHybridCarToDirectory(prius);

        }
        private void SeedRealGreen()
        {
            RealGreenCar gt3rs = new RealGreenCar("Porsche GT3 RS", 19, Color.NeonGreen);
            RealGreenCar hummer = new RealGreenCar("AMC Hummer H1", 10, Color.DarkGreen);

            _repoRealGreen.AddRealGreenCarToDirectory(gt3rs);
            _repoRealGreen.AddRealGreenCarToDirectory(hummer);

        }






    }
}
