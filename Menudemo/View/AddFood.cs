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
using Guna.UI2.WinForms;
using Menudemo.CONNECT;
using Menudemo.DAO;
using Menudemo.DTO;

namespace Menudemo.View
{
    public partial class AddFood : FAddSample
    {
        int type;
        float Price;
        int idCate;
        string name;
        public AddFood(int type)
        {
            InitializeComponent();
            this.type = type; 
            LoadCB();
        }
        public AddFood(int type, object Price,int idCate,
        
        string name)
        {
            InitializeComponent();
            LoadCB();
            this.type = type;
       
           
            txtname.Text = name;
            txtPrice.Text = Convert.ToString(Price);
            
            
            
        }
        
       
       public void LoadCB()

        {
            string query = "select id,name from FoodCate";
            cbCateid.DisplayMember= "name";
            cbCateid.ValueMember= "id";
           
            cbCateid.DataSource = DataProvider.Instance.ExecuteQuery(query);
            cbCateid.SelectedIndex=-1;
          
        }

        private void btn_Save_Click_1(object sender, EventArgs e)
        {
            try
            {


                float price = float.Parse(txtPrice.Text.ToString());
                int idCate = (int)cbCateid.SelectedValue;
                string name = txtname.Text.ToString();
                if (type == 0)
                {


                    int a = FoodDAO.Instance.Insert_Food(name, idCate, price);
                    if (a != 0)
                    {
                        MessageBox.Show("Save Succeessfully", "RMS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Save Failure", "RMS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

                    }
                }
                else
                {

                    int a = FoodDAO.Instance.Update_Food(name, idCate, price, type);

                    if (a != 0)
                    {
                        MessageBox.Show("Save Succeessfully", "RMS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    }
                    else
                    {
                        MessageBox.Show("Save Failure", "RMS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);


                    }
                }
            }
            catch(Exception ex )
            { 
                        MessageBox.Show("Lỗi cập nhật ", "RMS", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            }
        }

        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
