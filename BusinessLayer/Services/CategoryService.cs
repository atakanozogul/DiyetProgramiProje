﻿using BusinessLayer.Abstract;
using DataAccessLayer.Repositories;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class CategoryService : ICategoryService<FoodCategory>
    {
        CategoryRepository categoryRepository;
        public CategoryService()
        {
            categoryRepository = new CategoryRepository();
        }
        public bool Active(FoodCategory entity)
        {
            return categoryRepository.Active(entity);
        }

        public bool Add(FoodCategory category)
        {
            if (String.IsNullOrWhiteSpace(category.CategoryName))
            {
                throw new Exception("Please type a category name");
            }
            else
            {
                return categoryRepository.Add(category);
            }
        }

        public List<FoodCategory> GetActives()
        {
            return categoryRepository.GetActives();
        }

        public List<FoodCategory> GetPassives()
        {
            return categoryRepository.GetPassives();
        }

        public List<FoodCategory> GetAll()
        {
            return categoryRepository.GetAll();
        }

        public FoodCategory GetById(int id)
        {
            if (id < 1)
            {
                throw new Exception("Invalid Category");
            }
            else
            {
                return categoryRepository.GetById(id);
            }
        }

        

        public bool Passive(FoodCategory entity)
        {
            return categoryRepository.Passive(entity);
        }

        public bool Update(FoodCategory category)
        {
            if (String.IsNullOrWhiteSpace(category.CategoryName))
            {
                throw new Exception("Please fill all blanks");
            }
            else
            {
                return categoryRepository.Update(category);
            }
        }

        public List<FoodCategory> GetByFilter(string filter)
        {
            return categoryRepository.GetByFilter(filter);
        }
    }
}
