using DGVPrinterHelper;
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
    public partial class UC_PlaceOrder : UserControl
    {
        function fn = new function();
        String query;

        public UC_PlaceOrder()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void combocategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            String category = combocategory.Text;
            query = "select name from restroManagement where category ='" + category + "'";
            showItemList(query);
        }

        private void txtsearch_TextChanged(object sender, EventArgs e)
        {
            String category = combocategory.Text;
            query = "select name from restroManagement where category ='" + category + "'and name like '"+txtsearch.Text+"%'";
            showItemList(query);
        }
        private void showItemList(String query)
        {
            listBox1.Items.Clear();
            DataSet ds = fn.getData(query);
            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
            {
                listBox1.Items.Add(ds.Tables[0].Rows[i][0].ToString());
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtquantity.ResetText();
            txttotal.Clear();

            String text = listBox1.GetItemText(listBox1.SelectedItem);
            txtitemname.Text = text;
            query = "select price from restroManagement where name = '" + text + "'";
            DataSet ds = fn.getData(query);

            try
            {
                txtpricee.Text = ds.Tables[0].Rows[0][0].ToString();
            }
            catch { }
            
        }

        private void txtquantity_ValueChanged(object sender, EventArgs e)
        {
            Int64 quan = Int64.Parse(txtquantity.Value.ToString());
            Int64 price = Int64.Parse(txtpricee.Text);
            txttotal.Text = (quan * price).ToString();
        }

        int amount;
        private void guna2DataGridView5_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                amount = int.Parse(guna2DataGridView5.Rows[e.RowIndex].Cells[3].Value.ToString());

            }
            catch { }

        }
        protected int n, total = 0;

        private void txtremove_Click(object sender, EventArgs e)
        {
            try
            {
                guna2DataGridView5.Rows.RemoveAt(this.guna2DataGridView5.SelectedRows[0].Index);

            }
            catch { }
            total -= amount;
            labelTotalAmount.Text = "Birr. " + total;
        }

        private void txtprint_Click(object sender, EventArgs e)
        {
            DGVPrinter printer = new DGVPrinter();
            printer.Title = "Customer Bill";
            printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoWrap;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer = "Total payable Amount : " + labelTotalAmount.Text;
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(guna2DataGridView5);

            total = 0;
            guna2DataGridView5.Rows.Clear();
            labelTotalAmount.Text = "Birr. " + total;
        }

        private void btnaddtocart_Click(object sender, EventArgs e)
        {
            if (txttotal.Text != "0" && txttotal.Text != "")
            {



                n = guna2DataGridView5.Rows.Add();
                guna2DataGridView5.Rows[n].Cells[0].Value = txtitemname.Text;
                guna2DataGridView5.Rows[n].Cells[1].Value = txtpricee.Text;
                guna2DataGridView5.Rows[n].Cells[2].Value = txtquantity.Text;
                guna2DataGridView5.Rows[n].Cells[3].Value = txttotal.Text;

                total += total + int.Parse(txttotal.Text);
                labelTotalAmount.Text = "Birr. " + total;
            }
            else
            {
                MessageBox.Show("Minimum Quantity to be 1", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
