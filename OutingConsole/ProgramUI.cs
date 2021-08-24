using OutingRepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutingConsole
{
    public class ProgramUI
    {
      
        OutingRepository _OutingRepo = new OutingRepository();
        public void Run()
        {
            Seed();
            Menu();

        }

        private void Menu()
        {
            bool keeprunning = true;
            while (keeprunning)
            {
                Console.WriteLine("Select A Menu Option:\n" +
                    "1.Display A List of All Outings.\n" +
                    "2.Add Individual Outing to A List.\n" +
                    "3.Display Total Cost for All Outing.\n" +
                    "4.Display Total Outing Cost By Type.\n" +
                    "5.Exit.");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                       DisplayListOfOuting();
                        break;
                    case "2":
                        AddIndividualOutingToAList();
                        break;
                    case "3":
                        DisplayTotalCostForAllOuting();
                        break;
                    case "4":
                        DsipalyTotalOutingCostByType();
                        break;
                    case "5":
                        keeprunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a Valid Menu Option");
                        break;

                }
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                Console.Clear();

            }

        }

        private void AddIndividualOutingToAList()
        {
            // Event Type
            Console.WriteLine("Select the Event type\n" +
                "1.Golf\n" +
                "2.Bowling\n" +
                "3.Amusement_paark\n" +
                "4. Concert");
            string typeOfEventAsString = Console.ReadLine();
            int intasTypeofEvent = int.Parse(typeOfEventAsString);
            Outing firstOuting = new Outing();
            firstOuting.EventType = (TypeOfEvent)intasTypeofEvent;

            //Event ID
            bool invalidEventId = true;
            while (invalidEventId)
            {
                Console.Write("Enter Event Id: ");
                string stringEventId = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(stringEventId))
                {
                    Console.WriteLine("Please enter a valid Event (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    int eventId = int.Parse(stringEventId);
                    firstOuting.EventId=eventId ;
                    invalidEventId = false;
                }
            }

            //Number of Attendee
            bool invalidNumber = true;
            while (invalidNumber)
            {
                Console.Write("Enter the Number of Attendee: ");
                string numberOfAttendee = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(numberOfAttendee))
                {
                    Console.WriteLine("Please enter a valid Number: (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {

                    int attendees = int.Parse(numberOfAttendee);
                    firstOuting.NumberOfPeople = attendees;
                    invalidNumber = false;
                }

            }
            //Cost Per Person

            bool invalidAmount = true;
            while (invalidAmount)
            {
                Console.Write("Enter the Cost per person : ");
                string stingAmount = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(stingAmount))
                {
                    Console.WriteLine("Please enter a valid Amount: (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {

                    double doubleCostPerPerson = double.Parse(stingAmount);
                    firstOuting.CostPerPerson = doubleCostPerPerson;
                    invalidAmount = false;
                }

            }


            //Date of Event
            bool invalidDateofEvent = true;
            while (invalidDateofEvent)
            {
                Console.Write("Enter Date of this Event in this format mm/dd/yyyy ");
                string date1 = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(date1))
                {
                    Console.WriteLine("Please enter a valid Date (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    DateTime dateofEvent = DateTime.Parse(date1);
                    firstOuting.DateOfEvent = dateofEvent;
                    invalidDateofEvent = false;
                }

            }
           
           if(_OutingRepo.AddOuting(firstOuting))
            {
                Console.WriteLine("Outing Added Succesfully");
            }

            else
            {
                Console.WriteLine("Add Operation failed");
            }

        }
        //Display all Event 
        private void DisplayListOfOuting()
        {
            Console.Clear();
            //Call the Display Method from _OutingRepo
            List<Outing> OutingList = _OutingRepo.GetAllOuting();
            Console.WriteLine($"{"Event Id",-15}{"Number of Attendee",-30}{"Cost Per Person",-25}{"Total cost Of event",-25}{"Event Type",-20}{"Date of event"}");


            foreach (Outing outing in OutingList)
            {
               
                Console.WriteLine($"{outing.EventId,-15}{outing.NumberOfPeople,-30}${outing.CostPerPerson,-25}${outing.TotalCost,-25}{outing.EventType,-20}{outing.DateOfEvent.ToString("d")}");
            }

        }
        // Total cost of  Outing for the Year
        private void DisplayTotalCostForAllOuting()
        {
            // Call Calculate All Outingcost Method from __OutingRepo
            double totaloutingcost = _OutingRepo.TotalcostOFAllEvent();
            Console.WriteLine($"Combined Cost of Outing for the Year is :${totaloutingcost}");

        }
        private void DsipalyTotalOutingCostByType()
        {
            Console.Clear();
            Console.WriteLine("Select the Event type #\n" +
              "1.Golf\n" +
              "2.Bowling\n" +
              "3.Amusement_paark\n" +
              "4. Concert");

            int inputEventType = int.Parse(Console.ReadLine());
            TypeOfEvent typeofEvent = (TypeOfEvent)inputEventType;

            double combinedCosts = _OutingRepo.TotalCostByEventType(typeofEvent);
            Console.WriteLine($"The Total Cost for {typeofEvent}: ${combinedCosts}");
        }

        private void Seed()
        {
            Outing outing1 = new Outing(100, 50, new DateTime(2021, 05, 7),20, TypeOfEvent.Bowling);
            Outing outing2 = new Outing(200, 58, new DateTime(2021, 08, 7), 20, TypeOfEvent.Golf);
            Outing outing3 = new Outing(300, 14, new DateTime(2021, 07, 7),80, TypeOfEvent.AmusementPark);

            _OutingRepo.AddOuting(outing1);
            _OutingRepo.AddOuting(outing2);
            _OutingRepo.AddOuting(outing3);
        }

    }
}
