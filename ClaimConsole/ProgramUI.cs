using ClaimRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClaimConsole
{
    public class ProgramUI
    {

        private ClaimRepo _claimrepository = new ClaimRepo();
        public void Run()
        {
            SeedMenu();
            Menu();
        }
        //===================================================================================//
        //Seed Menu that fires off as soon as  the program start to run.
        public void SeedMenu()
        {
            var claim1 = new Claim
            {
                ClaimID = 100,
                ClaimAmount = 2800,
                ClaimType = TyPeOfClaim.Car,
                Description = "Car Accident on I 465",
                DateOfClaim = new DateTime(08 / 01 / 2021),
                DateOfIncident = new DateTime(07 / 14 / 2021)

            };

            var claim2 = new Claim
            {
                ClaimID = 200,
                ClaimAmount = 3800,
                ClaimType = TyPeOfClaim.Theft,
                Description = "Iphone 12 stolen from my car",
                DateOfClaim = new DateTime(08 / 01 / 2021),
                DateOfIncident = new DateTime(01 / 14 / 2021)
            };
            _claimrepository.AddQueue(claim1);
            _claimrepository.AddQueue(claim2);


        }

        private void Menu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n\t\t\t\tMenu");
                Console.WriteLine("\nSelect A Menu Option:\n\n" +
                    "1.Add Claim\n" +
                    "2.Claim List\n" +
                    "3.Display Next Claim\n" +
                    "4.Process Claim\n" +
                    "5.Exit");

                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        AddClaim();
                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "5":

                        break;
                    case "6":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a Number on The Menu List\n" +
                            "Press any key to continue......");
                        Console.ReadKey();
                        break;

                }
                Console.Clear();
                Console.WriteLine("Goodbye!");
                Thread.Sleep(2000);
                Console.Clear();

            }
        }
        //Claim ID
        public void AddClaim()
        {
            Console.Clear();
            var claim = new Claim();

            bool invalidClaimId = true;
            while (invalidClaimId)
            {
                Console.Write("Enter Claim Id: ");
                string stringClaimId = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(stringClaimId))
                {
                    Console.WriteLine("Please enter a valid ClaimId (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    int claimId = int.Parse(stringClaimId);
                    claim.ClaimID = claimId;
                    invalidClaimId = false;
                }
            }
            //ClaimType
            Console.WriteLine("1.Car\n" +
                "2.Theft\n" +
                "3.Accident");
            Console.Write("Type Of Claim (#): ");
            int response = int.Parse(Console.ReadLine());
            claim.ClaimType = (TyPeOfClaim)response;

            //Claim Amount  
            bool invalidAmount = true;
            while (invalidAmount)
            {
                Console.Write("Enter the Amount for the claim: ");
                string stingAmount = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(stingAmount))
                {
                    Console.WriteLine("Please enter a valid Amount: (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    double doubleClaimAmount = double.Parse(stingAmount);
                    claim.ClaimAmount = doubleClaimAmount;
                    invalidAmount = false;
                }

            }
            bool invalidClaimDescription = true;
            while (invalidClaimDescription)
            {
                Console.Write("Enter Claim Description: ");
                string description = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine("Please enter a valid Description (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    claim.Description = description;
                    invalidClaimDescription = false;
                }
            }

            bool invalidDateofClaim = true;
            while (invalidDateofClaim)
            {
                Console.Write("Enetr Date of this Claim in this format mm/dd/yyyy ");
                string date = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(date))
                {
                    Console.WriteLine("Please enter a valid Date (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    DateTime dateofclaim = DateTime.Parse(date);
                    claim.DateOfClaim = dateofclaim;
                    invalidDateofClaim = false;
                }

            }

            bool invalidDateofincident = true;
            while (invalidDateofincident)
            {
                Console.Write("Enter Date of this Incident in this format mm/dd/yyyy ");
                string date1 = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(date1))
                {
                    Console.WriteLine("Please enter a valid Date (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    DateTime dateofincident = DateTime.Parse(date1);
                    claim.DateOfIncident = dateofincident;
                    invalidDateofincident = false;
                }

            }

            if (claim.Isvalid)
            {
                _claimrepository.AddQueue(claim);
                Console.WriteLine("Claim is Added Successfuly");
                ContinueMessage();
            }
            else
            {
                Console.WriteLine("Claim is out of range it could noit be proccessed");
                ContinueMessage();
            }



        }
        public void ContinueMessage()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

       

    }

}

