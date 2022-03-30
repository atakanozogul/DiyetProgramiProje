﻿using BusinessLayer.Services;
using Model.Entities;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiyetProgramiProje
{
    public partial class UserForm : Form
    {
        FoodService foodService;
        CategoryService categoryService;
        UserService userService;
        UserRegisterInfo userRegisterInfo;
        UserMealService userMealService;
        UserMealsAndFoodsService userMealsAndFoodsService;
        
        public UserForm(UserRegisterInfo _userRegisterInfo)
        {
            InitializeComponent();
            foodService = new FoodService();
            userService = new UserService();
            categoryService = new CategoryService();
            userMealService = new UserMealService();
            userMealsAndFoodsService = new UserMealsAndFoodsService();
            userRegisterInfo = _userRegisterInfo;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            FillMealTimeCBox();
            FillFoodsListBox();
            FillLvMealTimeCBox();
            cboxMealTime.SelectedIndex=0;
            cboxLvMealTime.SelectedIndex = 0;
        }

        private void FillMealTimeCBox()
        {
            foreach (var item in Enum.GetValues(typeof(MealTimesEnum)))
            {
                cboxMealTime.Items.Add(item);
            }
        }

        private void FillLvMealTimeCBox()
        {
            foreach (var item in Enum.GetValues(typeof(MealTimesEnum)))
            {
                cboxLvMealTime.Items.Add(item);
            }
        }

        private void FillFoodsListBox()
        {
            lboxFoods.DisplayMember = "Name";
            lboxFoods.ValueMember = "Id";
            lboxFoods.DataSource = foodService.GetAll();

        }

        private void txtFoodFilter_TextChanged(object sender, EventArgs e)
        {
            
            lboxFoods.DisplayMember = "Name";
            lboxFoods.ValueMember = "Id";
            lboxFoods.DataSource = foodService.GetByFilter(txtFoodFilter.Text);
        }

        private void lboxFoods_Click(object sender, EventArgs e)
        {
            
            try
            {
                FoodName food = foodService.GetById((int)lboxFoods.SelectedValue);
                lblCaloriesByPortion.Text = food.Calorie.ToString();
                

                FoodCategory foodCategory = categoryService.GetById(food.FoodCategoryId);
                lblCategoyName.Text = foodCategory.CategoryName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void lboxFoods_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FoodName food = foodService.GetById((int)lboxFoods.SelectedValue);
            //lblCategoyName.Text = food.FoodCategory.CategoryName;
        }

        private void nudPortion_ValueChanged(object sender, EventArgs e)
        {
            
            lblTotalCalories.Text = (nudPortion.Value * Convert.ToDecimal(lblCaloriesByPortion.Text)).ToString();
        }

        private void btnAddMeal_Click(object sender, EventArgs e)
        {

            try
            {
                UserMeal userMeal = userMealService.CheckMeal(DateTime.Now.Date, (MealTimesEnum)cboxMealTime.SelectedItem);

                if (userMeal == null)
                {
                    userMeal = new UserMeal();
                    userMeal.MealDate = DateTime.Now.Date;
                    userMeal.MealTime = (MealTimesEnum)cboxMealTime.SelectedItem;
                    userMeal.UserInformationId = userRegisterInfo.Id;
                    userMealService.Add(userMeal);

                    FoodName foodName = foodService.GetById((int)lboxFoods.SelectedValue);

                    UserMealsAndFoods userMealsAndFoods = new UserMealsAndFoods();
                    userMealsAndFoods.UserMealID = userMeal.Id;
                    userMealsAndFoods.FoodNameID = foodName.Id;
                    userMealsAndFoods.Portion = nudPortion.Value;
                    userMealsAndFoods.Calorie = foodName.Calorie;

                    userMealsAndFoodsService.Add(userMealsAndFoods);
                }
                else
                {
                    FoodName foodName = foodService.GetById((int)lboxFoods.SelectedValue);

                    UserMealsAndFoods userMealsAndFoods = new UserMealsAndFoods();
                    userMealsAndFoods.UserMealID = userMeal.Id;
                    userMealsAndFoods.FoodNameID = foodName.Id;
                    userMealsAndFoods.Portion = nudPortion.Value;
                    userMealsAndFoods.Calorie = foodName.Calorie * nudPortion.Value;

                    userMealsAndFoodsService.Add(userMealsAndFoods);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
             
            }
            
        }

        private void FillListView()
        {

            UserMeal meal = userMealService.GetMeal(userRegisterInfo.Id, dtMealDate.Value.Date, (MealTimesEnum)cboxLvMealTime.SelectedItem);

            List<UserMealsAndFoods> meals = userMealsAndFoodsService.GetUserAndFoodByMealId(meal.Id);

            foreach (var item in meals)
            {
                FoodName food = foodService.GetById(item.FoodNameID);

                ListViewItem lvi = new ListViewItem();
                lvi.Text = food.Name;
                lvi.SubItems.Add(item.Portion.ToString());
                lvi.SubItems.Add(item.Calorie.ToString());
                lvi.Tag = item.UserMealID;

                lvMeals.Items.Add(lvi);
            }
        }

        private void btnShowMeal_Click(object sender, EventArgs e)
        {
            FillListView();
        }
    }
}
