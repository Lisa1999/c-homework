using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Order;

namespace Orderform
{
    public partial class Form2 : Form
    {
        Order1 result = null;
        public Form2()
        {
            Customer customer1 = new Customer(1, "勾雨桐");
            Customer customer2 = new Customer(2, "陈朔怡");

            Goods apple = new Goods(3, "apple", 5.59);
            Goods egg = new Goods(2, "egg", 4.99);
            Goods milk = new Goods(1, "milk", 69.9);
            //customerBindingSource.Add(customer1);
            //customerBindingSource.Add(customer2);
            //goodsBindingSource.Add(apple);
            //goodsBindingSource.Add(milk);
            //goodsBindingSource.Add(egg);
            InitializeComponent();
        }
        public Form2(Order1 order) : this()
        {
            order1BindingSource.DataSource = order;
        }

        public Order1 getResult()
        {
            return result;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                if (dataGridView1.CurrentCell.Value != null)
                {
                    comboBox2.Text = dataGridView1.CurrentCell.Value.ToString();  //对combobox赋值 
                }

                Rectangle R = dataGridView1.GetCellDisplayRectangle(
                                    dataGridView1.CurrentCell.ColumnIndex,
                                    dataGridView1.CurrentCell.RowIndex, false);

                comboBox2.Location = new Point(dataGridView1.Location.X + R.X,
                    dataGridView1.Location.Y + R.Y);

                comboBox2.Width = R.Width;
                comboBox2.Height = R.Height;
                comboBox2.Visible = true;
            }
            else
            {
                comboBox2.Visible = false;
            }

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (orderDetailBindingSource.Current == null)
            {
                orderDetailBindingSource.Add(new OrderDetail());
            }
            ((OrderDetail)orderDetailBindingSource.Current).Goods = (Goods)comboBox2.SelectedItem;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result = (Order1)order1BindingSource.Current;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = ((Order1)order1BindingSource.Current).Customer;

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = ((Order1)order1BindingSource.Current).Customer;
        }
    }
}
