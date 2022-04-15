using BusinessLayer.Abstract;
using DataAccessLayer.Repositories;
using Model.Entities;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class UserMealsAndFoodsService : IUserMealsAndFoodsService<UserMealsAndFoods>
    {
        UserMealsAndFoodsRepository userMealsAndFoodsRepository;
        public UserMealsAndFoodsService()
        {
            userMealsAndFoodsRepository = new UserMealsAndFoodsRepository();
        }
        public bool Add(UserMealsAndFoods meal)
        {
            if (string.IsNullOrWhiteSpace(meal.Calorie.ToString()) || string.IsNullOrWhiteSpace(meal.FoodNameID.ToString()) || string.IsNullOrWhiteSpace(meal.Portion.ToString()) || string.IsNullOrWhiteSpace(meal.UserMealID.ToString()))
            {
                throw new Exception("Lütfen bütün boşlukları doldurun.");
            }
            else
            {
                return userMealsAndFoodsRepository.Add(meal);
            }
        }

        public bool Delete(int mealId, int foodId)
        {
            if (mealId==0 || foodId==0)
            {
                throw new Exception("Lütfen silme işleminden önce bir yemek seçin.");
            }
            else
            {
                return userMealsAndFoodsRepository.Delete(mealId, foodId);
            }
               
        }

        public decimal GetCalorieByMeal(int userId, DateTime mealDate, MealTimesEnum mealTime)
        {
            if (userId < 1 || string.IsNullOrWhiteSpace(mealDate.ToString()) || string.IsNullOrWhiteSpace(mealTime.ToString()))
            {
                throw new Exception("Hatalı giriş");
            }
            else
            {
                return userMealsAndFoodsRepository.GetCalorieByMeal(userId, mealDate, mealTime);
            }
        }

        public decimal GetTotalCalorieById(int userId, DateTime mealDate)
        {
            if (userId < 1 || string.IsNullOrWhiteSpace(mealDate.ToString()))
            {
                throw new Exception("Htalı giriş");
            }
            else
            {
                return userMealsAndFoodsRepository.GetTotalCalorieById(userId, mealDate);
            }
        }

        public bool UpdateMealAndFood(UserMealsAndFoods _meal)
        {
            if (string.IsNullOrWhiteSpace(_meal.Portion.ToString()))
            {
                throw new Exception("Lütfen bütün boşlukları doldurun.");
            }
            else
            {
                return userMealsAndFoodsRepository.UpdateMealAndFood(_meal);
            }
        }

        public List<UserMealsAndFoods> GetUserAndFoodByMealId(int mealId)
        {
            return userMealsAndFoodsRepository.GetUserAndFoodByMealId(mealId);
        }

        public bool CheckMealAndFoods(int foodId, int mealId)
        {
            return userMealsAndFoodsRepository.CheckMealAndFoods(foodId,mealId);
        }

        public UserMealsAndFoods GetMealsAndFoods(int foodId, int mealId)
        {
            return userMealsAndFoodsRepository.GetMealsAndFoods(foodId, mealId);
        }
        public List<int> GetFoodIdbyUserMeal(UserMeal userMeal)
        {
            return userMealsAndFoodsRepository.GetFoodIdbyUserMeal(userMeal);
        }
    }
}
