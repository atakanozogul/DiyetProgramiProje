﻿using Model.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class FoodCategory : IEntity
    {
        public FoodCategory()
        {
            FoodNames = new HashSet<FoodName>();
        }
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string Status { get; set; } = "Passive";

        public virtual ICollection<FoodName> FoodNames { get; set; }
    }
}
