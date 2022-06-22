using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thithu.Models;
using thithu.BLL;

namespace thithu.Views
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Showdgv();
        }

        public void Showdgv()
        {
            CbbDishName.Items.Clear();
            foreach (Dish d in Dish_BLL.Instance.GetAllDish()) // phai override tostring()
                CbbDishName.Items.Add(d);
            if(CbbDishName.SelectedItem!=null)
            dataGridView1.DataSource = Dish_Ingredient_BLL.Instance.GetAllSP_View(((Dish)CbbDishName.SelectedItem).DishID);
        }
        private void Addbut_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2("", ((Dish)CbbDishName.SelectedItem).DishID);
            f2.phucdz = new Form2.del(Showdgv);
            f2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Cells["stt"].Value != null)
            {
                Form2 f2 = new Form2(Dish_Ingredient_BLL.Instance.GetID(((Dish)CbbDishName.SelectedItem).DishID, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["stt"].Value)).ID, ((Dish)CbbDishName.SelectedItem).DishID); // vl luon :D
                f2.phucdz = new Form2.del(Showdgv);
                f2.Show();
            }
            else MessageBox.Show("Error");
        }

        private void CbbDishName_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = Dish_Ingredient_BLL.Instance.GetAllSP_View(((Dish)CbbDishName.SelectedItem).DishID);
        }
    }
}
