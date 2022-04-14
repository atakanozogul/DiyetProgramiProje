namespace DataAccessLayer.Migrations
{
    using Model.Entities;
    using Model.Enums;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Drawing;
    using System.IO;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataAccessLayer.Context.DietProgramContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataAccessLayer.Context.DietProgramContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            string d1 = Path.GetFullPath("d1.jpeg");
            Image img = new Bitmap(d1);
            byte[] arr1;
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr1 = ms.ToArray();
            }

            Dietician dietician1 = new Dietician()
            {
                FirstName = "diyetisyen1",
                LastName = "diyetisyen1",
                Graduation = "A university",
                Status = StatusEnum.Active,
                Picture = arr1
            };

            context.Dieticians.Add(dietician1);
            context.SaveChanges();


            DieticianRegisterInfo dieticianRegisterInfo1 = new DieticianRegisterInfo()
            {
                Id = dietician1.Id,
                Email = "dietician1@diet.com",
                Password = "12345D!",
                UserType = MembershipTypeEnum.Dietician
            };

            context.DieticianRegisterInfos.Add(dieticianRegisterInfo1);
            context.SaveChanges();

            string d2 = Path.GetFullPath("d2.jpeg");
            Image imgD = new Bitmap(d2);
            byte[] arrD;
            using (MemoryStream ms = new MemoryStream())
            {
                imgD.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arrD = ms.ToArray();
            }

            Dietician dietician2 = new Dietician()
            {
                FirstName = "diyetisyen2",
                LastName = "diyetisyen2",
                Graduation = "B university",
                Status = StatusEnum.Active,
                Picture = arrD
            };

            context.Dieticians.Add(dietician2);
            context.SaveChanges();


            DieticianRegisterInfo dieticianRegisterInfo2 = new DieticianRegisterInfo()
            {
                Id = dietician2.Id,
                Email = "dietician2@diet.com",
                Password = "12345D!",
                UserType = MembershipTypeEnum.Dietician
            };

            context.DieticianRegisterInfos.Add(dieticianRegisterInfo2);
            context.SaveChanges();


            UserInformation adminInfo = new UserInformation()
            {
                FirstName = "admin",
                LastName = "admin",
                BirthDate = DateTime.Parse("01-01-1970"),
                Gender = GenderEnum.Male,
                Height = 1,
                Weight = 1,
                Status = StatusEnum.Active,
                UserRequest = UserRequestsEnum.MaintainWeight,
                DailyExercise = ExerciseEnum.LightlyActive,
                DailyCalorie = 2000,
                RequireCalorie = 1,
                DieticianId = 1
            };
            context.UserInformations.Add(adminInfo);
            context.SaveChanges();

            UserRegisterInfo admin = new UserRegisterInfo();
            admin.Id = adminInfo.Id;
            admin.Email = "admin@diet.com";
            admin.Password = "A1111!";
            admin.UserType = MembershipTypeEnum.Admin;

            context.UserRegisterInfos.Add(admin);
            context.SaveChanges();


            UserInformation user1Info = new UserInformation()
            {
                FirstName = "kullanıcı1",
                LastName = "kullanıcı1",
                BirthDate = DateTime.Parse("01-01-1999"),
                Gender = GenderEnum.Male,
                Height = 178,
                Weight = 72,
                Status = StatusEnum.Active,
                UserRequest = UserRequestsEnum.MaintainWeight,
                DailyExercise = ExerciseEnum.LightlyActive,
                DailyCalorie = 2000,
                RequireCalorie = 2200,
                DieticianId = 1
            };
            context.UserInformations.Add(user1Info);
            context.SaveChanges();

            UserRegisterInfo user1 = new UserRegisterInfo();
            user1.Id = user1Info.Id;
            user1.Email = "user1@gmail.com";
            user1.Password = "12345B!";
            user1.UserType = MembershipTypeEnum.Client;

            context.UserRegisterInfos.Add(user1);
            context.SaveChanges();

            UserInformation user2Info = new UserInformation()
            {
                FirstName = "kullanıcı2",
                LastName = "kullanıcı2",
                BirthDate = DateTime.Parse("01-01-2001"),
                Gender = GenderEnum.Female,
                Height = 165,
                Weight = 53,
                Status = StatusEnum.Active,
                UserRequest = UserRequestsEnum.MaintainWeight,
                DailyExercise = ExerciseEnum.LightlyActive,
                DailyCalorie = 2000,
                RequireCalorie = 2200,
                DieticianId = 2
            };
            context.UserInformations.Add(user2Info);
            context.SaveChanges();

            UserRegisterInfo user2 = new UserRegisterInfo();
            user2.Id = user2Info.Id;
            user2.Email = "user2@gmail.com";
            user2.Password = "12345A!";
            user2.UserType = MembershipTypeEnum.Client;

            context.UserRegisterInfos.Add(user2);
            context.SaveChanges();


            FoodCategory category1 = new FoodCategory()
            {
                CategoryName = "Et",
                Status = StatusEnum.Active
            };

            context.FoodCategories.Add(category1);
            context.SaveChanges();


            FoodCategory category2 = new FoodCategory()
            {
                CategoryName = "Sebzeler",
                Status = StatusEnum.Active
            };

            context.FoodCategories.Add(category2);
            context.SaveChanges();

            FoodCategory category3 = new FoodCategory()
            {
                CategoryName = "Meyveler",
                Status = StatusEnum.Active
            };

            context.FoodCategories.Add(category3);
            context.SaveChanges();

            FoodCategory category4 = new FoodCategory()
            {
                CategoryName = "Süt Ürünleri",
                Status = StatusEnum.Active
            };

            context.FoodCategories.Add(category4);
            context.SaveChanges();

            FoodCategory category5 = new FoodCategory()
            {
                CategoryName = "Yağ ve Şekerler",
                Status = StatusEnum.Active
            };

            context.FoodCategories.Add(category5);
            context.SaveChanges();

            string beef = Path.GetFullPath("beef.jpeg");
            Image food1Img = new Bitmap(beef);
            byte[] arr2;
            using (MemoryStream ms = new MemoryStream())
            {
                food1Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr2 = ms.ToArray();
            }

            FoodName food1 = new FoodName()
            {
                Name = "Biftek",
                Calorie = 300,
                Status = StatusEnum.Active,
                FoodPicture = arr2,
                FoodCategoryId = 1
            };

            context.FoodNames.Add(food1);
            context.SaveChanges();

            string chicken = Path.GetFullPath("chicken.jpeg");
            Image food2Img = new Bitmap(chicken);
            byte[] arr3;
            using (MemoryStream ms = new MemoryStream())
            {
                food2Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr3 = ms.ToArray();
            }

            FoodName food2 = new FoodName()
            {
                Name = "Tavuk",
                Calorie = 220,
                Status = StatusEnum.Active,
                FoodPicture = arr3,
                FoodCategoryId = 1
            };

            context.FoodNames.Add(food2);
            context.SaveChanges();

            string bean = Path.GetFullPath("bean.jpeg");
            Image food3Img = new Bitmap(bean);
            byte[] arr4;
            using (MemoryStream ms = new MemoryStream())
            {
                food3Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr4 = ms.ToArray();
            }

            FoodName food3 = new FoodName()
            {
                Name = "Fasulye",
                Calorie = 50,
                Status = StatusEnum.Active,
                FoodPicture = arr4,
                FoodCategoryId = 2
            };

            context.FoodNames.Add(food3);
            context.SaveChanges();

            string broccoli = Path.GetFullPath("broccoli.jpeg");
            Image food4Img = new Bitmap(broccoli);
            byte[] arr5;
            using (MemoryStream ms = new MemoryStream())
            {
                food4Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr5 = ms.ToArray();
            }

            FoodName food4 = new FoodName()
            {
                Name = "Brokoli",
                Calorie = 32,
                Status = StatusEnum.Active,
                FoodPicture = arr5,
                FoodCategoryId = 2
            };

            context.FoodNames.Add(food4);
            context.SaveChanges();

            string lettuce = Path.GetFullPath("lettuce.jpeg");
            Image food5Img = new Bitmap(lettuce);
            byte[] arr6;
            using (MemoryStream ms = new MemoryStream())
            {
                food5Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr6 = ms.ToArray();
            }

            FoodName food5 = new FoodName()
            {
                Name = "Marul",
                Calorie = 15,
                Status = StatusEnum.Active,
                FoodPicture = arr6,
                FoodCategoryId = 2
            };

            context.FoodNames.Add(food5);
            context.SaveChanges();

            string ham = Path.GetFullPath("ham.jpeg");
            Image food6Img = new Bitmap(ham);
            byte[] arr7;
            using (MemoryStream ms = new MemoryStream())
            {
                food6Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr7 = ms.ToArray();
            }

            FoodName food6 = new FoodName()
            {
                Name = "Jambon",
                Calorie = 240,
                Status = StatusEnum.Active,
                FoodPicture = arr7,
                FoodCategoryId = 1
            };

            context.FoodNames.Add(food6);
            context.SaveChanges();

            string carrot = Path.GetFullPath("carrot.jpeg");
            Image food7Img = new Bitmap(carrot);
            byte[] arr8;
            using (MemoryStream ms = new MemoryStream())
            {
                food7Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr8 = ms.ToArray();
            }

            FoodName food7 = new FoodName()
            {
                Name = "Havuç",
                Calorie = 25,
                Status = StatusEnum.Active,
                FoodPicture = arr8,
                FoodCategoryId = 2
            };

            context.FoodNames.Add(food7);
            context.SaveChanges();

            string cheese = Path.GetFullPath("cheese.jpeg");
            Image food8Img = new Bitmap(cheese);
            byte[] arr9;
            using (MemoryStream ms = new MemoryStream())
            {
                food8Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr9 = ms.ToArray();
            }

            FoodName food8 = new FoodName()
            {
                Name = "Peynir",
                Calorie = 110,
                Status = StatusEnum.Active,
                FoodPicture = arr9,
                FoodCategoryId = 4
            };

            context.FoodNames.Add(food8);
            context.SaveChanges();

            string milk = Path.GetFullPath("milk.jpeg");
            Image food9Img = new Bitmap(milk);
            byte[] arr10;
            using (MemoryStream ms = new MemoryStream())
            {
                food9Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr10 = ms.ToArray();
            }

            FoodName food9 = new FoodName()
            {
                Name = "Süt",
                Calorie = 125,
                Status = StatusEnum.Active,
                FoodPicture = arr10,
                FoodCategoryId = 4
            };

            context.FoodNames.Add(food9);
            context.SaveChanges();

            string yoghurt = Path.GetFullPath("yoghurt.jpeg");
            Image food10Img = new Bitmap(yoghurt);
            byte[] arr11;
            using (MemoryStream ms = new MemoryStream())
            {
                food10Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr11 = ms.ToArray();
            }

            FoodName food10 = new FoodName()
            {
                Name = "Yoğurt",
                Calorie = 90,
                Status = StatusEnum.Active,
                FoodPicture = arr11,
                FoodCategoryId = 4
            };

            context.FoodNames.Add(food10);
            context.SaveChanges();

            string chocolate = Path.GetFullPath("chocolate.jpeg");
            Image food11Img = new Bitmap(chocolate);
            byte[] arr12;
            using (MemoryStream ms = new MemoryStream())
            {
                food11Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr12 = ms.ToArray();
            }

            FoodName food11 = new FoodName()
            {
                Name = "Çikolota",
                Calorie = 200,
                Status = StatusEnum.Active,
                FoodPicture = arr12,
                FoodCategoryId = 5
            };

            context.FoodNames.Add(food11);
            context.SaveChanges();

            string jam = Path.GetFullPath("jam.jpeg");
            Image food12Img = new Bitmap(jam);
            byte[] arr13;
            using (MemoryStream ms = new MemoryStream())
            {
                food12Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr13 = ms.ToArray();
            }

            FoodName food12 = new FoodName()
            {
                Name = "Reçel",
                Calorie = 38,
                Status = StatusEnum.Active,
                FoodPicture = arr13,
                FoodCategoryId = 5
            };

            context.FoodNames.Add(food12);
            context.SaveChanges();

            string grapes = Path.GetFullPath("grapes.jpeg");
            Image food13Img = new Bitmap(grapes);
            byte[] arr14;
            using (MemoryStream ms = new MemoryStream())
            {
                food13Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr14 = ms.ToArray();
            }

            FoodName food13 = new FoodName()
            {
                Name = "Üzüm",
                Calorie = 55,
                Status = StatusEnum.Active,
                FoodPicture = arr14,
                FoodCategoryId = 3
            };

            context.FoodNames.Add(food13);
            context.SaveChanges();

            string olive = Path.GetFullPath("olive.jpeg");
            Image food14Img = new Bitmap(olive);
            byte[] arr15;
            using (MemoryStream ms = new MemoryStream())
            {
                food14Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr15 = ms.ToArray();
            }

            FoodName food14 = new FoodName()
            {
                Name = "Zeytin",
                Calorie = 50,
                Status = StatusEnum.Active,
                FoodPicture = arr15,
                FoodCategoryId = 3
            };

            context.FoodNames.Add(food14);
            context.SaveChanges();

            string tomato = Path.GetFullPath("tomato.jpeg");
            Image food15Img = new Bitmap(tomato);
            byte[] arr16;
            using (MemoryStream ms = new MemoryStream())
            {
                food15Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr16 = ms.ToArray();
            }

            FoodName food15 = new FoodName()
            {
                Name = "Domates",
                Calorie = 30,
                Status = StatusEnum.Active,
                FoodPicture = arr16,
                FoodCategoryId = 3
            };

            context.FoodNames.Add(food15);
            context.SaveChanges();

            string spinach = Path.GetFullPath("spinach.jpeg");
            Image food16Img = new Bitmap(spinach);
            byte[] arr17;
            using (MemoryStream ms = new MemoryStream())
            {
                food16Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr17 = ms.ToArray();
            }

            FoodName food16 = new FoodName()
            {
                Name = "Ispanak",
                Calorie = 8,
                Status = StatusEnum.Active,
                FoodPicture = arr17,
                FoodCategoryId = 2
            };

            context.FoodNames.Add(food16);
            context.SaveChanges();

            string cabbage = Path.GetFullPath("cabbage.jpeg");
            Image food17Img = new Bitmap(cabbage);
            byte[] arr18;
            using (MemoryStream ms = new MemoryStream())
            {
                food17Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr18 = ms.ToArray();
            }

            FoodName food17 = new FoodName()
            {
                Name = "Lahana",
                Calorie = 15,
                Status = StatusEnum.Active,
                FoodPicture = arr18,
                FoodCategoryId = 2
            };

            context.FoodNames.Add(food17);
            context.SaveChanges();

            string cauliflower = Path.GetFullPath("cauliflower.jpeg");
            Image food18Img = new Bitmap(cauliflower);
            byte[] arr19;
            using (MemoryStream ms = new MemoryStream())
            {
                food18Img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                arr19 = ms.ToArray();
            }

            FoodName food18 = new FoodName()
            {
                Name = "Karnabahar",
                Calorie = 20,
                Status = StatusEnum.Active,
                FoodPicture = arr18,
                FoodCategoryId = 2
            };

            context.FoodNames.Add(food18);
            context.SaveChanges();
        }
    }
}
