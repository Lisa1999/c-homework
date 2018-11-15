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
    public partial class Form1 : Form
    {
        OrderService orderService;

        public Form1()
        {
            InitializeComponent();
            init();
        }
        public void init()
        {
            Customer customer1 = new Customer(1, "陈朔怡");
            Customer customer2 = new Customer(2, "勾雨桐");
            Goods apple = new Goods(3, "apple", 5.59);
            Goods egg = new Goods(2, "egg", 4.99);
            Goods milk = new Goods(1, "milk", 69.9);
            OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, egg, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

            Order1 order1 = new Order1(1, customer1);
            Order1 order2 = new Order1(2, customer2);
            Order1 order3 = new Order1(3, customer2);

            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);
            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails3);

            orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);
            order1BindingSource.DataSource = orderService.QueryAllOrders();



        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                string fileName = openFileDialog1.FileName;
                orderService.Import(fileName);
                order1BindingSource.DataSource = orderService.QueryAllOrders();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                string fileName = saveFileDialog1.FileName;
                orderService.Export(fileName);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Order1 o = (Order1)order1BindingSource.Current;
            if (o != null)
            {
                orderService.RemoveOrder(o.Id);
                order1BindingSource.DataSource = orderService.QueryAllOrders();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(new Order1());
            form2.ShowDialog();
            Order1 newOrder = form2.getResult();
            if (newOrder != null)
            {
                orderService.AddOrder(newOrder);
                order1BindingSource.DataSource = orderService.QueryAllOrders();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (cbField.SelectedIndex)
            {
                case 0:
                    order1BindingSource.DataSource =
                        orderService.QueryAllOrders();
                    break;
                case 1:
                    uint id = 0;
                    uint.TryParse(txtValue.Text, out id);
                    order1BindingSource.DataSource = orderService.GetById(id);
                    break;
                case 2:
                    order1BindingSource.DataSource =
                            orderService.QueryByCustomerName(txtValue.Text);
                    break;
                case 3:
                    order1BindingSource.DataSource =
                            orderService.QueryByGoodsName(txtValue.Text);
                    break;
                case 4:
                    double price = 0;
                    double.TryParse(txtValue.Text, out price);
                    order1BindingSource.DataSource =
                           orderService.QueryByPrice(price);
                    break;
            }
        }
    }
}