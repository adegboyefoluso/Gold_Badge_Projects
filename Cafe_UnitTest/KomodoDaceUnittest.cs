using Cafe_ClassProject;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Cafe_UnitTest
{
    [TestClass]
    public class KomodoDaceUnittest
    {
        public Menu _meal;
        public MenuRepository _repo = new MenuRepository();


        [TestInitialize]
        public void Arrange()
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
                Ingredients = new List<string> { "oil oil", "Tomato", "Peper","oka leaf", "Fish" },
                MealName = "Oka soup",
                MealNumber = 2,
                Description = "Fish soup that is made Oka leaf",
                Price = 80
            };
            _repo.AddMenu(meal2);
            _repo.AddMenu(meal1);
        }
        
        //=====================================================================//
        //Test add Menu Method
        [TestMethod]
        public void AddMethod()
        {
            var menu3 = new Menu(3, "acha", "Made from okro", new List<string> { "fish", "water" }, 50);
            Assert.IsNotNull(_repo.AddMenu(menu3));
        }
        //=====================================================================//
        //Test Update Method

        [TestMethod]
        public void UpdateMethod()
        {
            var menu4 = new Menu(4, "acha", "Made from okro", new List<string> { "fish", "water" }, 50);
            Assert.IsTrue(_repo.UpdateMeal(1, menu4));
            Assert.AreEqual("acha", _repo.GetMealByMealNumber(4).MealName);
            Assert.IsNull( _repo.GetMealByMealNumber(1));
        }
        //========================================================================//
        //Test Delete Method
        [TestMethod]
        public void DeleteMethod()
        {
            Assert.IsTrue(_repo.DeleteMeal(1));
            Assert.IsNull(_repo.GetMealByMealNumber(1));
        }
        //========================================================================//
        //Test Get All Menu
        [TestMethod]
        public void GetAllMenu()
        {
            Assert.AreEqual(2, _repo.ReadListOfMeal().Count);

        }
        //===========================================================================//
        //Test Menu By Menu Number
        [TestMethod]
        public void GetmealByNumber()
        {
            var menu4 = new Menu(4, "acha", "Made from okro", new List<string> { "fish", "water" }, 50);
            _repo.AddMenu(menu4);
            Assert.AreEqual(menu4, _repo.GetMealByMealNumber(4));
            Console.WriteLine(_repo.GetMealByMealNumber(4).MealName);
        }
    }
}
