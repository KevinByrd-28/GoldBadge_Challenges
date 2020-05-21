using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2_Claims
{
    class ProgramUI
    {
        private ClaimRepository _repo = new ClaimRepository();
        private List<Claim> newList;
        public void Run()
        {
            SeedClaimList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of your selection: \n" +
                    "1. See All Claims\n" +
                    "2. Take Care Of Next Claim\n" +
                    "3. Enter A New Claim\n" +
                    "4. Exit"
                    );

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        //see all claims
                        PrintAllClaims();
                        Console.ReadKey();
                        break;
                    case "2":
                        //take care of next claim
                        NextClaim();
                        Console.ReadKey();
                        break;
                    case "3":
                        //Enter a new claim, add claim
                        CreateNewClaim();
                        Console.ReadKey();
                        break;
                    case "4":
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

        public void PrintAllClaims()
        {
            Console.Clear();
            List<Claim> listOfClaims = _repo.GetContents();

            Console.WriteLine($"\n {"ClaimID",-20}  {"Type",-30} {"Description",-30} {"Amount",-30} {"DateOfIncident",-30}{"DateOfClaim",-30} {"IsValid",-30}\n");
            foreach (Claim line in listOfClaims)
            {
                DisplayContent(line);
            }
        }
        public void DisplayContent(Claim item)
        {
            Console.WriteLine($"{item.ClaimID, -20} {item.Type,-30} {item.Description,-30} {item.ClaimAmount,-30}{item.DateOfIncident,-30}{item.DateOfClaim,-30}{item.IsValid,-30}\n");
        }

        //-----Option 2 on prompt------------------------------
        public void NextClaim()
        {
            newList = _repo.GetContents();

            Claim item1 = newList.FirstOrDefault();

            Console.WriteLine("Here are the details for the next claim to be handled: \n" +
                $"ClaimID: {item1.ClaimID} \n" +
                $"Incident Type: {item1.Type} \n" +
                $"Description: {item1.Description} \n" +
                $"Amount: {item1.ClaimAmount} \n" +
                $"DateOfAccident: {item1.DateOfIncident} \n" +
                $"DateOfClaim: {item1.DateOfClaim} \n" +
                $"IsValid: {item1.IsValid}\n");

            Console.Write("Do you want to deal with this claim now(y/n)? ");
            string answer = Console.ReadLine();
            if(answer == "y" || answer == "yes")
            {
                _repo.RemoveClaimByID(item1.ClaimID);
            }
            else
            {
                RunMenu();
            }

        }






        //-----Option 3 on prompt----------------------------

        public void CreateNewClaim()
        {
            Console.Clear();
            Console.Write("Enter ClaimID: ");
            string aClaimID = Console.ReadLine();

            Console.Write("Enter a Claim Type (CarAccident, CarTheft, HomeFire or HomeInjury: ");
            string type = Console.ReadLine();
            ClaimType aType = ClaimType.CarAccident;
            if(type == "CarAccident")
            {
                aType = ClaimType.CarAccident;
            }
            else if(type == "CarTheft")
            {
                aType = ClaimType.CarTheft;
            }
            else if(type == "HomeFire")
            {
                aType = ClaimType.HomeFire;
            }
            else if (type == "HomeInjury")
            {
                aType = ClaimType.HomeInjury;
            }
            else
            {
                Console.WriteLine("Not A Valid Entry");
                RunMenu();
            }

            Console.Write("Describe The Claim: ");
            string aDescription = Console.ReadLine();

            Console.Write("Amount Of Damage in $: ");
            decimal aClaimAmount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Date of Incident (Year, Month, Day): ");
            DateTime aDateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Date of Claim, Must Be Within 30Days of Incident(Year, Month, Day): ");
            DateTime aDateOfClaim = Convert.ToDateTime(Console.ReadLine());
            int dateTest = Convert.ToInt32((aDateOfClaim - aDateOfIncident).TotalDays);
            if (dateTest > 30)
            {
                Console.WriteLine("This is not a valid Claim, Komodo Insurance will not accept false claims or claims made outside of a 30day window - per company policy.");
                Console.ReadKey();
                RunMenu();
            }

            Console.Write("By Entering This Claim, You Beleive This Claim To Be Valid, Press Any Key To Continue...\n");
            Console.ReadKey();
            //TEST THIS PORTION
            Claim newClaim = new Claim(aClaimID, aType, aDescription, aClaimAmount, aDateOfIncident, aDateOfClaim, true);
            
            _repo.AddClaimToDirectory(newClaim);
            Console.WriteLine("New claim added!");
            Console.ReadLine();
            RunMenu();
        }

        private void SeedClaimList()
        {
            Claim kevin = new Claim("123KB", ClaimType.CarAccident, "hit by old woman", 5.00m, new DateTime(2018, 01, 23), new DateTime(2018, 01, 24), true);
            Claim steve = new Claim("456SD", ClaimType.CarAccident, "hit by bus", 1000.00m, new DateTime(2018, 01, 25), new DateTime(2018, 01, 26), true);

            _repo.AddClaimToDirectory(kevin);
            _repo.AddClaimToDirectory(steve);

        }



    }
}
