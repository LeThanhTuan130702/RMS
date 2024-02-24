using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menudemo.CONNECT;
using Menudemo.DAO;

namespace Menudemo.View
{
    public partial class Addview : FAddSample
    {
        int type;
        string name;
        public Addview(int type,string name)
        {
            InitializeComponent();

            this.type = type;
            this.name = name;
            txt_cate.Text = name;
            
        }
        public Addview(int type)
        {
            this.type = type;
            InitializeComponent();
            
        }

        private void btn_Save_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (type == 0)
                {
                    if (txt_cate.Text.Trim() == "")
                    {
                        return;
                    }
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    int a = CategoryDAO.Instance.Insert_Cate(txt_cate.Text);
                    if (a != 0)
                    {
                        MessageBox.Show("Save Succeessfully", "RMS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Save Failure", "RMS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    }
                }
                else
                {
                    
                    if (txt_cate.Text.Trim() == "")
                    {
                        return;
                    }
                    guna2MessageDialog1.Icon = Guna.UI2.WinForms.MessageDialogIcon.None;
                    guna2MessageDialog1.Buttons = Guna.UI2.WinForms.MessageDialogButtons.OK;
                    int a = CategoryDAO.Instance.Update_Cate(txt_cate.Text,type);
                    if (a != 0)
                    {
                        MessageBox.Show("Save Succeessfully", "RMS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                    }
                    else
                    {
                        MessageBox.Show("Save Failure", "RMS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("lỗi cập nhật", "RMS", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);

            }

        }

        private void btn_Close_Click_1(object sender, EventArgs e)
        {
            this.Close();
            
        }
    }
}
