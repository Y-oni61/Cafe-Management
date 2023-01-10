using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafe
{
    public partial class dashboard : Form
    {
        public dashboard()
        {
            InitializeComponent();
        }
        public dashboard(String user)
        {
            InitializeComponent();

            if(user == "Guest")
            {
                btnAddItem.Hide();
                btnRemove.Hide(); 
                btnUpdate.Hide();
            }
            else if (user == "Admin")
            {
                btnAddItem.Show();
                btnRemove.Show();
                btnUpdate.Show();
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogOut_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form1 fm = new Form1();
            this.Hide();
            fm.Show();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            uC_AddItems1.Visible = true;
            uC_AddItems1.BringToFront();
        }

        private void dashboard_Load(object sender, EventArgs e)
        {
            uC_AddItems1.Visible = false;
            uC_PlaceOrder1.Visible = false;
            uC_Updateitem1.Visible = false;
            uC_Removeitem1.Visible = false;
        }

        private void uC_AddItems1_Load(object sender, EventArgs e)
        {

        }

        private void btnPlace_Click(object sender, EventArgs e)
        {
            uC_Welcome1.SendToBack();
            guna2Transition1.ShowSync(uC_PlaceOrder1);
            uC_PlaceOrder1.Visible = true;
            uC_PlaceOrder1.BringToFront();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            uC_Updateitem1.Visible = true;
            uC_Updateitem1.BringToFront();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            uC_Removeitem1.Visible = true;
            uC_Removeitem1.BringToFront();
        }
    }
}
