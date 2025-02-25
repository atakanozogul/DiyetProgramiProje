﻿using DataAccessLayer.EntityConfiguration;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{
    public class DietProgramContext : DbContext
    {
        public DietProgramContext() 
            : base(@"Server=DESKTOP-U45D5S4\SQLEXPRESS;Database=DietTrackerDB2;Trusted_Connection=True;")
        {
            //DESKTOP-MLA1I95
            //DESKTOP-U45D5S4
        }

        public DbSet<Dietician> Dieticians { get; set; }
        public DbSet<DieticianRegisterInfo> DieticianRegisterInfos { get; set; }
        public DbSet<FoodCategory> FoodCategories { get; set; }
        public DbSet<FoodName> FoodNames { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<UserInformation> UserInformations { get; set; }
        public DbSet<UserMeal> UserMeals { get; set; }
        public DbSet<UserRegisterInfo> UserRegisterInfos { get; set; }
        public DbSet<UserMealsAndFoods> UserMealsAndFoods { get; set; }
        public DbSet<DieticianMessage> DieticianMessages { get; set; }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DieticianConfiguration());
            modelBuilder.Configurations.Add(new DieticianRegisterInfoConfiguration());
            modelBuilder.Configurations.Add(new FoodCategoryConfiguration());
            modelBuilder.Configurations.Add(new FoodNameConfiguration());
            modelBuilder.Configurations.Add(new MessageConfiguration());
            modelBuilder.Configurations.Add(new UserInformationConfiguration());
            modelBuilder.Configurations.Add(new UserMealConfiguration());
            modelBuilder.Configurations.Add(new UserRegisterInfoConfiguration());
            modelBuilder.Configurations.Add(new UserMealsAndFoodsConfiguration());
            modelBuilder.Configurations.Add(new DieticianMessageConfiguration());
        }

    }
}
