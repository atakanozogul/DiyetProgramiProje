﻿using Model.Abstract;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class UserInformation : IEntity
    {
        public UserInformation()
        {
            UserMeals = new HashSet<UserMeal>();
            Messages = new HashSet<Message>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }
        public DateTime BirthDate { get; set; }
        public GenderEnum Gender { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public UserRequestsEnum UserRequest { get; set; }
        public ExerciseEnum DailyExercise { get; set; }
        public decimal DailyCalorie { get; set; }
        public decimal RequireCalorie { get; set; }
        public StatusEnum Status { get; set; } = StatusEnum.Passive;

        public virtual UserRegisterInfo UserRegisterInfo { get; set; }

        public int DieticianId { get; set; }
        public virtual Dietician Dietician { get; set; }

        public virtual ICollection<UserMeal> UserMeals { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
    }
}
