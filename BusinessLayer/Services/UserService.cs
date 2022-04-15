using BusinessLayer.Abstract;
using DataAccessLayer.Repositories;
using Model.Entities;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BusinessLayer.Services
{
    public class UserService : IUserService<UserRegisterInfo, UserInformation>
    {
        UserRepository userRepository;
        public UserService()
        {
            userRepository = new UserRepository();
        }

        public bool Active(UserInformation user)
        {
            return userRepository.Active(user);
        }

        public UserRegisterInfo CheckLogin(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) || userRepository.CheckUserStatus(email) == StatusEnum.Pasif.ToString())
            {
                return null;
            }
            else
            {
                return userRepository.CheckLogin(email, password);
            }
        }

        public List<UserInformation> GetAll()
        {
            return userRepository.GetAll();
        }

        public UserInformation GetById(int id)
        {
            if (id < 1)
            {
                throw new Exception("Hatalı Kullanıcı");
            }
            else
            {
                return userRepository.GetById(id);
            }
        }

        public List<UserInformation> GetCustomers(Dietician dietician)
        {
            return userRepository.GetCustomers(dietician);
        }

        public List<UserInformation> GetPassives()
        {
            return userRepository.GetAllPassives();
        }

       
        public bool AddInformation(UserInformation userInfo)
        {
            if (string.IsNullOrWhiteSpace(userInfo.FirstName) || string.IsNullOrWhiteSpace(userInfo.LastName) || string.IsNullOrWhiteSpace(userInfo.BirthDate.ToString()) || string.IsNullOrWhiteSpace(userInfo.Gender.ToString()) || string.IsNullOrWhiteSpace(userInfo.Height.ToString()) || string.IsNullOrWhiteSpace(userInfo.Weight.ToString()) || string.IsNullOrWhiteSpace(userInfo.DailyExercise.ToString()) || string.IsNullOrWhiteSpace(userInfo.UserRequest.ToString()) || string.IsNullOrWhiteSpace(userInfo.DieticianId.ToString()) || string.IsNullOrWhiteSpace(userInfo.DailyCalorie.ToString()) || string.IsNullOrWhiteSpace(userInfo.RequireCalorie.ToString()))
            {
                throw new Exception("Lütfen bütün boşlukları doldurun.");
            }
            else if (userInfo.BirthDate.Date.AddYears(13) > DateTime.Now.Date)
            {
                throw new Exception("Kayıt olmak için en az 13 yaşında olmalısınız.");
            }
            else
            {
                return userRepository.AddInformation(userInfo);
            }
            
        }

        public bool AddRegister(UserRegisterInfo userRegister)
        {
            if (string.IsNullOrWhiteSpace(userRegister.Email) || string.IsNullOrWhiteSpace(userRegister.Password))
            {
                throw new Exception("Lütfen bütün boşlukları doldurun.");
            }
            else
            {
                return userRepository.AddRegister(userRegister);
            }
        }

        public bool Passive(UserInformation user)
        {
            return userRepository.Passive(user);
        }

        public List<UserInformation> GetAllClients()
        {
            return userRepository.GetAllClients();
        }

        public List<UserInformation> GetAllPassives()
        {
            return userRepository.GetAllPassives();
        }

        public List<UserInformation> GetAllActives()
        {
            return userRepository.GetAllActives();
        }

        public UserRegisterInfo GetUserByEmail(string email)
        {
            return userRepository.GetUserByEmail(email);
        }
    }
}
