using BadgeRepositoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgeConsole
{
    public class ProgramUI
    {
        BadgeRepository _badgeRepository = new BadgeRepository();

        public void Run()
        {
            Menu();
        }

        private void Menu()
        {
            bool keeprunning = true;
            while (keeprunning)
            {
                Console.WriteLine("Select A menu Option:\n" +
                    "1.Add a Badge\n" +
                    "\n" +
                    "2.Edit a Badge\n" +
                    "\n" +
                    "3.List All Badges\n" +
                    "\n" +
                    "4.Replace A Door\n" +
                     "\n" +
                    "5.Exit");
                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        AddABadge();
                        break;
                    case "2":
                        EditABadge();
                        break;
                    case "3":
                        ListAllBadges();
                        break;
                    case "4":
                        RelplaceADoor();
                        break;
                    case "5":
                        keeprunning = false;
                        break;
                    default:
                        Console.WriteLine("Please Enter a valid option on the Menu");
                        break;

                }
                Console.WriteLine("Please Press any key to continue........");
                Console.ReadKey();
                Console.Clear();
            }

        }
        // Add Method  for Addning door toa Badge and storing the Badge in the data Base
        private void AddABadge()
        {
            Console.Clear();
            Badge mybadge = new Badge();
            //===========================This block ensure that an white sopace is not eneted or a null badge;======================
            bool invalidBadgeId = true;
            while (invalidBadgeId)
            {
                Console.Write("What is the number on the badge?:"); ;
                string stringBadgelId = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(stringBadgelId))
                {
                    Console.WriteLine("Please enter a valid BadgeId (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    int badgeId = int.Parse(stringBadgelId);
                    mybadge.BadgeID = badgeId;
                    invalidBadgeId = false;
                }
            }
            //=====================================This block ensure that at least a door is assigned to a badge================
            bool keeprunning = true;
            while (keeprunning)
            {
                
                string door = " ";
                bool invalidDoorId = true;
                while (invalidDoorId)
                {
                    Console.Write("List a door that it needs accsess to:");
                     door = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(door))
                    {
                        Console.WriteLine("Please enter a valid Door (press any key to continue)");
                        Console.ReadKey();
                    }
                    else
                    {
                        invalidDoorId = false;
                    }
                }

                if (mybadge.DoorNameList.Contains(door))
                {
                    Console.WriteLine("This door has already been added to the Badge");
                }
                else
                {
                    mybadge.DoorNameList.Add(door);

                    Console.Write("Any other door(Y/N):");
                    string response3 = Console.ReadLine().ToUpper();
                    if (response3 == "N")
                    {
                        keeprunning = false;
                    }

                }
            }
            _badgeRepository.AddBadgetoDic(mybadge);



        }
        //==================================adding and removing a door from a badge=========================
        private void EditABadge()
        {
            Console.Clear();
            int response1 = 0;
            bool invalidBadgeId = true;
            while (invalidBadgeId)
            {
                Console.WriteLine("What Badge  Number do you want to update?");
                string stringBadgeld = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(stringBadgeld))
                {
                    Console.WriteLine("Please enter a valid BadgeID (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    response1 = int.Parse(stringBadgeld);

                    invalidBadgeId = false;
                }
            }

            KeyValuePair<int, List<string>> mybadge = new KeyValuePair<int, List<string>>();
            mybadge = _badgeRepository.GetBadgeFrommDIcByBadgeID(response1);
            if (mybadge.Key != response1)
            {
                Console.WriteLine("Invalid Id");
            }
            else
            {

            string response2 = string.Join("&", mybadge.Value);

            Console.WriteLine($"{mybadge.Key} has access to doors {response2}\n" +
                "\n");
            Console.WriteLine("What Would You Like to do? Select the right option \n" +
                "\t\t\t1.Remove a Door\n" +
                "\t\t\t2.Add a door");
            string response3 = Console.ReadLine();
            switch (response3)
            {
                case "1":

                    Console.Write("What Door would you like to remove?");
                    string response4 = Console.ReadLine();
                    if (mybadge.Value.Contains(response4))
                    {
                        mybadge.Value.Remove(response4);
                        Console.WriteLine("Door Removed");
                        string reponse6 = string.Join("&", mybadge.Value);
                        int response9 = mybadge.Value.Count();
                        if (response9 == 0)
                        {
                            Console.WriteLine($"Badge Number {mybadge.Key} do not have access to any door");
                        }
                        else
                        {
                            Console.WriteLine($"Badge Number {mybadge.Key} has access to doors {reponse6}");
                        }

                    }
                    else
                    {
                        Console.WriteLine("Door Does not Exist");
                    }


                    break;
                case "2":
                    Console.Write("What door Would you like to Add?");
                    string response5 = Console.ReadLine();
                    mybadge.Value.Add(response5);
                    Console.WriteLine("Door added succesfully\n" +
                        "\n");
                    string reponse7 = string.Join("&", mybadge.Value);
                    Console.WriteLine($"Badge Number {mybadge.Key} has access to doors {reponse7}");
                    break;
                default:
                    Console.WriteLine("Please Enter a valid Menu option");
                    break;

            }
            }
            

        }

        //This Method display all items in the Dictionary
        private void ListAllBadges()


        {
            Console.Clear();
            Dictionary<int, List<string>> badges = _badgeRepository.ReadBadgefromDIC();       // Call ReadBadgefromDIc method from Badgerepository and assign the reuurn value to a newe instance the dictionary
            Console.WriteLine($"{"Badge#",-15}{"Door Access"}");                             //Formating the heading
            foreach (KeyValuePair<int, List<string>> badge in badges)                        //iterate over the dictionary using (keyvaluepair which returs bioth the key  and the value
            {
                
                string response = string.Join(",", badge.Value);                             //string.Join  format the item in Doorlist by listing them and separtaing them with comma  (,)
                if (badge.Value == null)
                {
                    response= "This is an empty Badge yet to be assigned a door";
                }
               
                Console.WriteLine($"{badge.Key,-15}{response}");
            }
            
        }

        private void RelplaceADoor()
        {
            int response1=0;
            bool invalidBadgeId = true;
            while (invalidBadgeId)
            {
                Console.WriteLine("What Badge  Number do you want to update?");
                string stringBadgeld = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(stringBadgeld))
                {
                    Console.WriteLine("Please enter a valid BadgeID (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                     response1 = int.Parse(stringBadgeld);

                    invalidBadgeId = false;
                }
            }

            KeyValuePair<int, List<string>> mybadge = _badgeRepository.GetBadgeFrommDIcByBadgeID(response1);
            if (mybadge.Key != response1)
            {
                Console.WriteLine($"{response1}  is not a valid Badge");
            }
            else
            {

            Console.WriteLine("what door are you removing from the Badge?");
            string response2 = Console.ReadLine();
            Console.WriteLine("What door are you adding to the Badge?");
            string response3 = Console.ReadLine();
            _badgeRepository.ReplaceADoor(response1, response2, response3);
            

            string reponse4 = string.Join("&", mybadge.Value);
            Console.WriteLine($"Badge{mybadge.Key} has access to doors {reponse4}");
            }




        }
    }
}
