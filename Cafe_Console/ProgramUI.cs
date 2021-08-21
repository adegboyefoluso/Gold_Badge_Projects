using Cafe_ClassProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cafe_Console
{
    public class ProgramUI
    {
        private MenuRepository _MenuRepo = new MenuRepository();
        public void Run()
        {
            SeedMenu();
            Menu();
        }
        //===================================================================================//
        //Seed Menu that fires off as soon as  the program start to run.
        public void SeedMenu()
        {
            var meal1 = new Menu
            {
                Ingredients = new List<string> { "Coconut oil", "Tomato", "Peper", "Fish" },
                MealName = "Chakama",
                MealNumber = 1,
                Description = "Fish soup that is made from coconut oil",
                Price = 35.78
            };

            var meal2 = new Menu
            {
                Ingredients = new List<string> { "oil oil", "Tomato", "Peper", "oka leaf", "Fish" },
                MealName = "Oka soup",
                MealNumber = 2,
                Description = "Fish soup that is made Oka leaf",
                Price = 80
            };
            _MenuRepo.AddMenu(meal2);
            _MenuRepo.AddMenu(meal1);
        }


        private void Menu()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\t\t\t\tMenu");
                Console.WriteLine("Select A Menu Option:\n" +
                    "1.Add Meal\n" +
                    "2.Menu List\n" +
                    "3.Update Meal\n" +
                    "4.Delete Meal\n" +
                    "5.Get A Meal\n" +
                    "6.Exit");

                string response = Console.ReadLine();
                switch (response)
                {
                    case "1":
                        AddMeal();
                        break;
                    case "2":
                        GetAllMenu();
                        break;
                    case "3":
                       // UpdateMeal();
                        break;
                    case "4":
                      //  DeleteMeal();
                        break;
                    case "5":
                      //  GetAMeal();
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

            }
        }

        public void ContinueMessage()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
        //==================================================================//
        //Add Menu Method
        public void AddMeal()
        {
            Console.Clear();
            var menu = new Menu();

            bool invalidName = true;
            while (invalidName)
            {
                Console.Write("Meal Name: ");
                string mealName = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(mealName))
                {
                    Console.WriteLine("Please enter a valid Meal (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    menu.MealName = mealName;
                    invalidName = false;
                }
              
            }
            bool invalidIngrdeient = true;
            while (invalidIngrdeient)
            {
                Console.Write("Enter the Meal Ingredients for the Meal and Enter No  to  exit: ");
                string ingredient = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ingredient))
                {
                    Console.WriteLine("Please enter a valid ingredient: (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    bool checking = true;
                    while (checking)
                    {
                        if (ingredient == "n" || ingredient == "no")
                        {
                            invalidIngrdeient = false;
                            break;
                        }
                        else
                        {
                            menu.Ingredients.Add(ingredient);
                            checking = false;
                        }
                    }
                }
              
            }
            bool InvalidMealId = true;
            while (InvalidMealId)
            {
                Console.Write("Enter Meal Id: ");
                string stringMealId = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(stringMealId))
                {
                    Console.WriteLine("Please enter a valid MealId (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    int mealId = int.Parse(stringMealId);
                    menu.MealNumber = mealId;
                    InvalidMealId = false;
                }
            }

            bool invalidDescription = true;
            while (invalidDescription)
            {
                Console.Write("Description: ");
                string description = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(description))
                {
                    Console.WriteLine("Please enter a valid Meal (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    menu.Description = description;
                    invalidDescription = false;
                }

            }

            bool invalidPrice = true;
            while (invalidPrice)
            {
                Console.Write("Meal Price: ");
                string price = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(price))
                {
                    Console.WriteLine("Please enter a valid Meal Price (press any key to continue)");
                    Console.ReadKey();
                }
                else
                {
                    double pdrice = double.Parse(price);
                    menu.Price = pdrice;

                    invalidPrice = false;
                }

            }
            if (_MenuRepo.AddMenu(menu))
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine("\n\nMenu Succesfuly Added\n\n");
                Console.ResetColor();
                Console.WriteLine("press any Key to continue..............");
                Console.ReadKey();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Menu failed");
                Console.ResetColor();
                Console.WriteLine("press any Key to continue");
                Console.ReadKey();
            }

            
        }
        private void GetAllMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine($"{"Meal Number",-10}| {"Meal Name",-10}|{"Meal Description",-40}|{"Meal Price"}");
            Console.WriteLine("...................................................................................");

            foreach (var item in _MenuRepo.ReadListOfMeal())
            {
                Console.WriteLine($"{item.MealNumber,-10} | {item.MealName,-10}|{item.Description,-40}|{item.Price}");
               
            }
            Console.ResetColor();
            Console.ReadKey();
        }

    }

}
