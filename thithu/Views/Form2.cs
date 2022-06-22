using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thithu.BLL;
using thithu.Models;

namespace thithu.Views
{
    public partial class Form2 : Form
    {
        private string ID;
        private int DishID;
        public delegate void del();
        public del phucdz { get; set; }
        public Form2(string id,int DishID)
        {
            InitializeComponent();

            ID = id;
            this.DishID = DishID;
            comboBox1.Items.AddRange(Ingredient_BLL.Instance.GetAllIngredientName());
            comboBox2.Items.AddRange(Dish_Ingredient_BLL.Instance.GetAllUnit());
            comboBox3.Items.AddRange(new string[]{
                "Nhap khau",
                "Chua nhap khau",
            });
            GUI();
        }

        public void GUI()
        {
            Dish_Ingredient a = Dish_Ingredient_BLL.Instance.GetD_IFromID(ID);
            if (a != null)
            {
                comboBox1.Text = a.Ingredientes.IngredientName;
                textBox1.Text = a.Amount.ToString();
                comboBox2.Text = a.Unit;
                comboBox3.Text = (a.Ingredientes.NhapKhau) ? "Nhap khau" : "Chua nhap khau";
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Dish_Ingredient di = new Dish_Ingredient();
            di.IngredientID = Ingredient_BLL.Instance.GetIngredientID(comboBox1.Text);
            di.Amount = Convert.ToInt32(textBox1.Text);
            di.Unit = comboBox2.Text;
            di.DishID = DishID;
            di.ID = ID;

            if (ID == "") Dish_Ingredient_BLL.Instance.Add_DI(di);
            else Dish_Ingredient_BLL.Instance.Edit_DI(di);

            phucdz();
            Close();
        }
    }
}
