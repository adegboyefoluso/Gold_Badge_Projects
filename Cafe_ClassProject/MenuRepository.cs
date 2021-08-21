using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe_ClassProject
{
    public class MenuRepository
    {
        private readonly List<Menu> _menuDataBase = new List<Menu>();
        //=============================================================================//
        //Add Menu to   Menu Database
        public bool AddMenu(Menu model)
        {
           int count = _menuDataBase.Count;
            _menuDataBase.Add(model);
            if (_menuDataBase.Count > count) return true;
            else return false;
        }
        //=============================================================================//
        //Read List of Meal 
        public List<Menu> ReadListOfMeal()
        {
            return _menuDataBase;
        }
        //============================================================================//
        //Add Ingredient to Ingredient List
        public List<string> AddIngredientToIngredientList(string ingredient)
        {
            var menu = new Menu();
            menu.Ingredients.Add(ingredient);
            return menu.Ingredients;
        }
        //===========================================================================//
        //Get Meal by Meal Number
        public Menu GetMealByMealNumber(int mealNumber)
        {
            return _menuDataBase.SingleOrDefault(m => m.MealNumber == mealNumber);
        }
        //============================================================================//
        //Delete Meal From DataBase
        public bool DeleteMeal(int mealNumber)
        {
            if (GetMealByMealNumber(mealNumber) is null)
            {
                return false;
            }
            else
            {
                int count = _menuDataBase.Count;
                _menuDataBase.Remove(GetMealByMealNumber(mealNumber));
                if (count > _menuDataBase.Count) return true;
                return false;
            }
        }
        //================================================================================//
        //Update Meal
        public bool UpdateMeal(int mealNumber, Menu newMeal)
        {
            Menu oldMeal = GetMealByMealNumber(mealNumber);
            if (oldMeal is null) return false;
            else
            {
                oldMeal.MealNumber = newMeal.MealNumber;
                oldMeal.MealName = newMeal.MealName;
                oldMeal.Description = newMeal.Description;
                oldMeal.Price = newMeal.Price;
                oldMeal.Ingredients = newMeal.Ingredients;
                return true;
            }
        }
    }
}
