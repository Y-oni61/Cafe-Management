using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cafe.user_control
{
    public partial class UC_Updateitem : UserControl
    {
        function fn = new function();
        string query;
        public UC_Updateitem()
        {
            InitializeComponent();
        }

        private void UC_Updateitem_Load(object sender, EventArgs e)
        {
            
            loadData();
        }

        public void loadData()
        {
            query = "select * from restroManagement";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];
        }

        private void txtSearchItem_TextChanged(object sender, EventArgs e)
        {
            query = "select * from restroManagement where name like '"+txtSearchItem.Text+"%' ";
            DataSet ds = fn.getData(query);
            guna2DataGridView1.DataSource = ds.Tables[0];

        }
        int id;
        private void guna2DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            id = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            String category = guna2DataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            String name = guna2DataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            int price = int.Parse(guna2DataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());

            txtcategory.Text = category;
            txtName.Text = name;
            txtprice.Text = price.ToString();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            query = "update restroManagement set name = '" + txtName.Text + "', category = '" + txtcategory.Text + "', price= '" + txtprice.Text + "' where iid = " + id + " ";
            fn.setData(query);
            loadData();

            txtName.Clear();
            txtcategory.Clear();
            txtprice.Clear();
        }
    }
}
