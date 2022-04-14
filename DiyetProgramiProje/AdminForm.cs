using BusinessLayer.Services;
using Model.Entities;
using Model.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiyetProgramiProje
{
    public partial class AdminForm : Form
    {
        UserService userService;
        CategoryService categoryService;
        FoodService foodService;
        UserRegisterInfo userRegisterInfo;
        FoodName foodForUpdate;
        FoodCategory foodCategory;
        DieticianRegisterInfo dietician = null;
        public AdminForm(UserRegisterInfo _user)
        {
            InitializeComponent();
            userService = new UserService();
            categoryService = new CategoryService();
            foodService = new FoodService();
            userRegisterInfo = _user;
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            try
            {
                FillClients();
                FillAllCategories();
                FillAllFoods();
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen seçimini kontrol et.");
            }
            this.BackColor = ColorTranslator.FromHtml("#cad2c5");
            this.labelFilter.BackColor = ColorTranslator.FromHtml("#293241");
            this.rbCatActive.ForeColor = ColorTranslator.FromHtml("#293241");
            this.rbCatActivePassive.ForeColor = ColorTranslator.FromHtml("#293241");
            this.rbCatPassive.ForeColor = ColorTranslator.FromHtml("#293241");
            this.rbUserActives.ForeColor = ColorTranslator.FromHtml("#293241");
            this.rbUserPassives.ForeColor = ColorTranslator.FromHtml("#293241");
            this.rbUserGetAll.ForeColor = ColorTranslator.FromHtml("#293241");
            this.rbFoodActives.ForeColor = ColorTranslator.FromHtml("#293241");
            this.rbFoodPassives.ForeColor = ColorTranslator.FromHtml("#293241");
            this.rbFoodsAll.ForeColor = ColorTranslator.FromHtml("#293241");
            this.btnAddCatAndFood.BackColor = ColorTranslator.FromHtml("#293241");
            this.btnUpdateCatAndFood.BackColor = ColorTranslator.FromHtml("#293241");
            this.labelTip1.BackColor = ColorTranslator.FromHtml("#e63946");
            this.labelTip2.BackColor = ColorTranslator.FromHtml("#e63946");
        }

        private void activeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInformation user = userService.GetById(Convert.ToInt32(lvUserInf.FocusedItem.Text));

            if (user.Status == StatusEnum.Passive)
            {
                userService.Active(user);
                MessageBox.Show("Kullanıcı statüsü aktif olarak değiştirildi.");
            }
            else
            {
                MessageBox.Show("Kullanıcı statüsü zaten aktif.");
            }

            FillClients();
        }

        private void passiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserInformation user = userService.GetById(Convert.ToInt32(lvUserInf.FocusedItem.Text));

            if (user.Status == StatusEnum.Active)
            {
                userService.Passive(user);
                MessageBox.Show("Kullanıcı statüsü pasif olarak değiştirildi.");
            }
            else
            {
                MessageBox.Show("Kullanıcı statüsü zaten pasif.");
            }

            FillClients();
        }

        private void FillClients()
        {
            lvUserInf.Items.Clear();

            List<UserInformation> users = userService.GetAllClients();

            foreach (var item in users)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = item.Id.ToString();
                lvItem.SubItems.Add(item.FirstName);
                lvItem.SubItems.Add(item.LastName);
                lvItem.SubItems.Add(item.Height.ToString());
                lvItem.SubItems.Add(item.Weight.ToString());
                lvItem.SubItems.Add(item.BirthDate.ToString());
                lvItem.SubItems.Add(item.UserRequest.ToString());
                lvItem.SubItems.Add(item.Status.ToString());
                lvItem.SubItems.Add(item.Gender.ToString());

                lvUserInf.Items.Add(lvItem);
            }
        }

        private void FillAllCategories()
        {
            List<FoodCategory> categories = categoryService.GetAll();
            foreach (var item in categories)
            {
                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = item.Id.ToString();
                lvItem.SubItems.Add(item.CategoryName);

                lvCategory.Items.Add(lvItem);
            }
        }

        private void FillAllFoods()
        {
            List<FoodName> allFoods = foodService.GetAll();
            foreach (var item in allFoods)
            {
                FoodCategory category = categoryService.GetById(item.FoodCategoryId);

                ListViewItem lvItem = new ListViewItem();
                lvItem.Text = item.Id.ToString();
                lvItem.SubItems.Add(item.Name);
                lvItem.SubItems.Add(category.CategoryName);
                lvItem.SubItems.Add(item.Calorie.ToString());

                lvFood.Items.Add(lvItem);
            }
        }

        private void FillCategories(string categoryType)
        {
            lvCategory.Items.Clear();

            switch (categoryType)
            {
                case "Aktifler":
                    List<FoodCategory> activeCategories = categoryService.GetActives();
                    foreach (var item in activeCategories)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = item.Id.ToString();
                        lvItem.SubItems.Add(item.CategoryName);

                        lvCategory.Items.Add(lvItem);
                    }
                    break;

                case "Pasifler":
                    List<FoodCategory> passiveCategories = categoryService.GetPassives();
                    foreach (var item in passiveCategories)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = item.Id.ToString();
                        lvItem.SubItems.Add(item.CategoryName);

                        lvCategory.Items.Add(lvItem);
                    }
                    break;

                case "Tüm Kategoriler":
                    FillAllCategories();
                    break;

                default:
                    throw new Exception("Lütfen bir filtre seçin.");
            }
        }

        private void FillFoods(string statusType)
        {
            lvFood.Items.Clear();

            switch (statusType)
            {
                case "Aktifler":
                    List<FoodName> activeFoods = foodService.GetActives();
                    foreach (var item in activeFoods)
                    {
                        FoodCategory category = categoryService.GetById(item.FoodCategoryId);

                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = item.Id.ToString();
                        lvItem.SubItems.Add(item.Name);
                        lvItem.SubItems.Add(category.CategoryName);
                        lvItem.SubItems.Add(item.Calorie.ToString());

                        lvFood.Items.Add(lvItem);
                    }
                    break;

                case "Pasifler":
                    List<FoodName> passiveFoods = foodService.GetPassives();
                    foreach (var item in passiveFoods)
                    {
                        FoodCategory category = categoryService.GetById(item.FoodCategoryId);

                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = item.Id.ToString();
                        lvItem.SubItems.Add(item.Name);
                        lvItem.SubItems.Add(category.CategoryName);
                        lvItem.SubItems.Add(item.Calorie.ToString());

                        lvFood.Items.Add(lvItem);
                    }
                    break;

                case "Tüm Yemekler":
                    FillAllFoods();
                    break;

                default:
                    throw new Exception("Lütfen bir filtre seçin.");
            }
        }

        private Image ConvertByteToPicture(FoodName food)
        {
                using (var ms = new MemoryStream(food.FoodPicture))
                {
                    return Image.FromStream(ms);
                }

        }

        private void lvFood_SelectedIndexChanged(object sender, EventArgs e)
        {
            pboxFoodPic.Visible = true;
            FoodName food = foodService.GetById(Convert.ToInt32(lvFood.FocusedItem.Text));
            pboxFoodPic.Image = ConvertByteToPicture(food);
            foodForUpdate = foodService.GetById(Convert.ToInt32(lvFood.FocusedItem.Text));

            foodCategory = null;
        }

        private void FillClientByFilter(string statusType)
        {
            lvUserInf.Items.Clear();

            switch (statusType)
            {
                case "Aktifler":
                    List<UserInformation> activeUsers = userService.GetAllActives();
                    foreach (var item in activeUsers)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = item.Id.ToString();
                        lvItem.SubItems.Add(item.FirstName);
                        lvItem.SubItems.Add(item.LastName);
                        lvItem.SubItems.Add(item.Height.ToString());
                        lvItem.SubItems.Add(item.Weight.ToString());
                        lvItem.SubItems.Add(item.BirthDate.ToString());
                        lvItem.SubItems.Add(item.UserRequest.ToString());
                        lvItem.SubItems.Add(item.Status.ToString());
                        lvItem.SubItems.Add(item.Gender.ToString());

                        lvUserInf.Items.Add(lvItem);
                    }
                    break;

                case "Pasifler":
                    List<UserInformation> passiveUsers = userService.GetAllPassives();
                    foreach (var item in passiveUsers)
                    {
                        ListViewItem lvItem = new ListViewItem();
                        lvItem.Text = item.Id.ToString();
                        lvItem.SubItems.Add(item.FirstName);
                        lvItem.SubItems.Add(item.LastName);
                        lvItem.SubItems.Add(item.Height.ToString());
                        lvItem.SubItems.Add(item.Weight.ToString());
                        lvItem.SubItems.Add(item.BirthDate.ToString());
                        lvItem.SubItems.Add(item.UserRequest.ToString());
                        lvItem.SubItems.Add(item.Status.ToString());
                        lvItem.SubItems.Add(item.Gender.ToString());

                        lvUserInf.Items.Add(lvItem);
                    }
                    break;

                case "Tüm Müşterileri Göster":
                    FillClients();
                    break;

                default:
                    throw new Exception("Lütfen bir filtre seçin.");
            }
        }

        private void btnAddCatAndFood_Click(object sender, EventArgs e)
        {
            Form frm = Application.OpenForms["FoodAddForm"];
            if (frm == null)
            {
                CloseAll();
                var MainForm = Application.OpenForms.OfType<MainForm>().Single();
                MainForm.LoadForm(new FoodAddForm(userRegisterInfo), dietician, userRegisterInfo);
            }
            else
            {
                return;
            }

            var MainForm1 = Application.OpenForms.OfType<MainForm>().Single();        
            MainForm1.LoadForm(new FoodAddForm(userRegisterInfo), dietician, userRegisterInfo);
        }

        private void lvCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            foodCategory = categoryService.GetById(Convert.ToInt32(lvCategory.FocusedItem.Text));
            foodForUpdate = null;
        }

        private void btnUpdateCatAndFood_Click(object sender, EventArgs e)
        {
            if (foodForUpdate == null && foodCategory == null)
            {
                MessageBox.Show("Lütfen bir kategori yada yemek seçin.");
            }
            else
            {
                Form frm = Application.OpenForms["FoodAddForm"];
                if (frm == null)
                {
                    CloseAll();
                    var MainForm = Application.OpenForms.OfType<MainForm>().Single();
                    MainForm.LoadForm(new FoodAddForm(userRegisterInfo,foodForUpdate,foodCategory), dietician, userRegisterInfo);
                }
                else
                {
                    return;
                }
            }
            
        }

        private void CloseAll()
        {
            var formForClose = Application.OpenForms.OfType<Form>().ToList();
            foreach (var item in formForClose)
            {
                if (item.Name != "MainForm")
                {
                    item.Close();
                }
            }
        }

        private void rbUserActives_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FillClientByFilter(rbUserActives.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen seçimini kontrol et.");
            }
        }

        private void rbUserPassives_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FillClientByFilter(rbUserPassives.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen seçimini kontrol et.");
            }
        }

        private void rbUserGetAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                FillClientByFilter(rbUserGetAll.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen seçimini kontrol et.");
            }
        }

        private void rbFoodActives_CheckedChanged(object sender, EventArgs e)
        {
            pboxFoodPic.Visible = false;
            try
            {
                if (rbFoodActives.Checked) FillFoods(rbFoodActives.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen seçimini kontrol et.");
            }
        }

        private void rbFoodPassives_CheckedChanged(object sender, EventArgs e)
        {
            pboxFoodPic.Visible = false;
            try
            {
                if (rbFoodPassives.Checked) FillFoods(rbFoodPassives.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen seçimini kontrol et.");
            }
        }

        private void rbFoodsAll_CheckedChanged(object sender, EventArgs e)
        {
            pboxFoodPic.Visible = false;
            try
            {
                if (rbFoodsAll.Checked) FillFoods(rbFoodsAll.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen seçimini kontrol et.");
            }
        }

        private void rbCatActive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbCatActive.Checked) FillCategories(rbCatActive.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen seçimini kontrol et.");
            }
        }

        private void rbCatPassive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbCatPassive.Checked) FillCategories(rbCatPassive.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen seçimini kontrol et.");
            }
        }

        private void rbCatActivePassive_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (rbCatActivePassive.Checked) FillCategories(rbCatActivePassive.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Lütfen seçimini kontrol et.");
            }
        }

        private void activeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lvCategory.FocusedItem == null)
            {
                MessageBox.Show("Lütfen bir kategori seçin.");
            }
            else
            {
                FoodCategory category = categoryService.GetById(Convert.ToInt32(lvCategory.FocusedItem.Text));

                if (category.Status == StatusEnum.Passive)
                {
                    categoryService.Active(category);
                    MessageBox.Show("Kategori statüsü aktif olarak değiştirildi.");
                }
                else
                {
                    MessageBox.Show("Kategori zaten aktif.");
                }
            }
        }

        private void passiveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (lvCategory.FocusedItem == null)
            {
                MessageBox.Show("Lütfen bir kategori seçin.");
            }
            else
            {
                FoodCategory category = categoryService.GetById(Convert.ToInt32(lvCategory.FocusedItem.Text));

                if (category.Status == StatusEnum.Active)
                {
                    categoryService.Passive(category);
                    MessageBox.Show("Kategori statüsü pasif olarak değiştirildi.");
                }
                else
                {
                    MessageBox.Show("Kategori zaten pasif.");
                }
            }
        }

        private void activeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (lvFood.FocusedItem == null)
            {
                MessageBox.Show("Lütfen bir yemek seçin.");
            }
            else
            {
                FoodName food = foodService.GetById(Convert.ToInt32(lvFood.FocusedItem.Text));

                if (food.Status == StatusEnum.Passive)
                {
                    foodService.Active(food);
                    MessageBox.Show("Kategori statüsü aktif olarak değiştirildi.");
                }
                else
                {
                    MessageBox.Show("Yemek zaten aktif.");
                }
            }
        }

        private void passiveToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (lvFood.FocusedItem == null)
            {
                MessageBox.Show("Lütfen bir yemek seçin.");
            }
            else
            {
                FoodName food = foodService.GetById(Convert.ToInt32(lvFood.FocusedItem.Text));

                if (food.Status == StatusEnum.Active)
                {
                    foodService.Passive(food);
                    MessageBox.Show("Yemek statüsü pasif olarak değiştirildi.");
                }
                else
                {
                    MessageBox.Show("Yemek zaten pasif.");
                }
            }
        }

        private void DrawGroupBox(GroupBox box, Graphics g, Color textColor, Color borderColor)
        {
            if (box != null)
            {
                Brush textBrush = new SolidBrush(textColor);
                Brush borderBrush = new SolidBrush(borderColor);
                Pen borderPen = new Pen(borderBrush);
                SizeF strSize = g.MeasureString(box.Text, box.Font);
                Rectangle rect = new Rectangle(box.ClientRectangle.X,
                                               box.ClientRectangle.Y + (int)(strSize.Height / 2),
                                               box.ClientRectangle.Width - 1,
                                               box.ClientRectangle.Height - (int)(strSize.Height / 2) - 1);

                // Clear text and border
                g.Clear(this.BackColor);

                // Draw text
                g.DrawString(box.Text, box.Font, textBrush, box.Padding.Left, 0);

                // Drawing Border
                //Left
                g.DrawLine(borderPen, rect.Location, new Point(rect.X, rect.Y + rect.Height));
                //Right
                g.DrawLine(borderPen, new Point(rect.X + rect.Width, rect.Y), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Bottom
                g.DrawLine(borderPen, new Point(rect.X, rect.Y + rect.Height), new Point(rect.X + rect.Width, rect.Y + rect.Height));
                //Top1
                g.DrawLine(borderPen, new Point(rect.X, rect.Y), new Point(rect.X + box.Padding.Left, rect.Y));
                //Top2
                g.DrawLine(borderPen, new Point(rect.X + box.Padding.Left + (int)(strSize.Width), rect.Y), new Point(rect.X + rect.Width, rect.Y));

            }
        }

        private void grpboxClients_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, ColorTranslator.FromHtml("#293241"), ColorTranslator.FromHtml("#293241"));
        }

        private void groupBoxCatFood_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, ColorTranslator.FromHtml("#293241"), ColorTranslator.FromHtml("#293241"));
        }

        private void groupBoxCatFilter_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, ColorTranslator.FromHtml("#293241"), ColorTranslator.FromHtml("#293241"));
        }

        private void groupBoxFoodFilter_Paint(object sender, PaintEventArgs e)
        {
            GroupBox box = sender as GroupBox;
            DrawGroupBox(box, e.Graphics, ColorTranslator.FromHtml("#293241"), ColorTranslator.FromHtml("#293241"));
        }
    }
}
