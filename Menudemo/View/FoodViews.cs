using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Menudemo.CONNECT;
using Menudemo.DAO;
using Menudemo.DTO;

namespace Menudemo.View
{
    public partial class FoodViews : FSample

    {
        private Account Account;

        public Account Account1 { get => Account; set => Account = value; }
        MenuForm mn;
        
        public FoodViews(Account acc)
        {
            InitializeComponent();
            Loaddata();
            DataGridViewImageColumn cDelete = new DataGridViewImageColumn();
            DataGridViewImageColumn cEdit = new DataGridViewImageColumn();
            cEdit.Image = Properties.Resources.edit;
            cDelete.Image = Properties.Resources.delete;
            Account1 = acc;
            mn = new MenuForm(Account1);
            dataGridView1.Columns.AddRange(cEdit, cDelete);
        }
        public void Loaddata()
        {
           

            dataGridView1.DataSource = FoodDAO.Instance.GetFoodList(textBox1.Text);

        }
        public void effec(Form model)
        {
            Form Backround = new Form();
            using (model)
            {
                Backround.StartPosition = FormStartPosition.Manual;
                Backround.FormBorderStyle = FormBorderStyle.None;
                Backround.Opacity = 0.5;
                Backround.BackColor = Color.Black;
                Backround.Size = mn.Size;
                Backround.Location = mn.Location;
                Backround.ShowInTaskbar = false;
                Backround.Show();
                model.Owner = Backround;
                model.ShowDialog(Backround);
                Backround.Dispose();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.OwningColumn.DisplayIndex == 5)
            {
                DialogResult dialog = MessageBox.Show("Are you sure you want to Delete", "RMS", MessageBoxButtons.YesNo, MessageBoxIcon.Question);



                if (dialog == DialogResult.Yes)
                {
                    int id = (int)(dataGridView1.CurrentRow.Cells["id"].Value);
                    int rs = FoodDAO.Instance.Delete_Food(id);

                    if (rs != 0)
                    {
                      
                        MessageBox.Show("Delete Successfully","RMS",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        Loaddata();
                    }
                }


            }
            if (dataGridView1.CurrentCell.OwningColumn.DisplayIndex == 4)
            {
                int id = (int)(dataGridView1.CurrentRow.Cells["id"].Value);
                object Price =dataGridView1.CurrentRow.Cells["Price"].Value;
                int idCate= (int)dataGridView1.CurrentRow.Cells["idCate"].Value;
                string name = (string)dataGridView1.CurrentRow.Cells["name"].Value;
                

                //Addview v = new Addview(id);
                //v.ShowDialog();
                effec(new AddFood(id,Price,idCate,name));
                Loaddata();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            effec(new AddFood(0));
            Loaddata();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = FoodDAO.Instance.GetFoodList(textBox1.Text);
        }

      
    }
}
