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
        private void AddABadge()
        {
            Console.Clear();
            Badge mybadge = new Badge();
            Console.Write("What is the number on the badge?:");
            mybadge.BadgeID = int.Parse(Console.ReadLine());

            bool keeprunning = true;
            while (keeprunning)
            {
                Console.Write("List a door that it needs accsess to:");

                string response2 = Console.ReadLine();
                mybadge.DoorNameList.Add(response2);

                Console.Write("Any other door(Y/N):");
                string response3 = Console.ReadLine().ToUpper();
                if (response3 == "N")
                {
                    keeprunning = false;
                }
            }
            _badgeRepository.AddBadgetoDic(mybadge);



        }
        private void EditABadge()
        {
            Console.Clear();
            Console.Write("What is the Badge Numnber To Update?:");


            int response = int.Parse(Console.ReadLine());
            // Badge mybadge = new Badge();
            KeyValuePair<int, List<string>> mybadge = new KeyValuePair<int, List<string>>();
            mybadge = _badgeRepository.GetBadgeFrommDIcByBadgeID(response);
            string response1 = string.Join("&", mybadge.Value);

            Console.WriteLine($"{mybadge.Key} has access to doors {response1}\n" +
                "\n");
            Console.WriteLine("What Would You Like to do? Select the right option \n" +
                "\t\t\t1.Remove a Door\n" +
                "\t\t\t2.Add a door");
            string response2 = Console.ReadLine();
            switch (response2)
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

        //This Method display all items in the Dictionary
        private void ListAllBadges()


        {
            Console.Clear();
            Dictionary<int, List<string>> badges = _badgeRepository.ReadBadgefromDIC();       // Call ReadBadgefromDIc method from Badgerepository and assign the reuurn value to a newe instance the dictionary
            Console.WriteLine($"{"Badge#",-15}{"Door Access"}");                             //Formating the heading
            foreach (KeyValuePair<int, List<string>> badge in badges)                        //iterate over the dictionary using (keyvaluepair which returs bioth the key  and the value
            {
                string response = string.Join(",", badge.Value);                             //string.Join  format the item in Doorlist by listing them and separtaing them with comma  (,)
                Console.WriteLine($"{badge.Key,-15}{response}");
            }
        }

        private void RelplaceADoor()
        {
            Console.WriteLine("What Badge  Number do you want to update?");
            int response1 = int.Parse(Console.ReadLine());

            Console.WriteLine("what door are you removing from the Badge?");
            string response2 = Console.ReadLine();
            Console.WriteLine("What door are you adding to the Badge?");
            string response3 = Console.ReadLine();
            _badgeRepository.ReplaceADoor(response1, response2, response3);
            KeyValuePair<int, List<string>> mybadge = _badgeRepository.GetBadgeFrommDIcByBadgeID(response1);

            string reponse4 = string.Join("&", mybadge.Value);
            Console.WriteLine($"Badge{mybadge.Key} has access to doors {reponse4}");



        }
    }
}
