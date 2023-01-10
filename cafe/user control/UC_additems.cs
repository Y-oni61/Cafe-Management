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
    public partial class UC_AddItems : UserControl
    {
        function fn = new function();
        String query;

        public UC_AddItems()
        {
            InitializeComponent();
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            query = "insert into restroManagement (name,category,price) values ('" + txtItem.Text+"','"+txtCategory.Text+"','"+txtPrice.Text+"' )";
            fn.setData(query);
            clearAll();
        }
        public void clearAll()
        {
            txtCategory.SelectedIndex = -1;
            txtItem.Clear();
            txtPrice.Clear();

        }
    }
}
