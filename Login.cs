using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dairy_Farm_Management_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            PasswordTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(RoleCb.SelectedIndex == -1)
            {
                MessageBox.Show("Selecte a Role");
            }
            if(PasswordTb.Text == "" || UnameTb.Text == "")
            {
                MessageBox.Show("Enter Admin Name and Password");
            }
            if(RoleCb.SelectedItem.ToString() == "Admin")
            {
                Employees emp = new Employees();
                emp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Wrong Admin name and Password");
            }
            if(RoleCb.SelectedItem.ToString() == "Employee")
            {

            }
        }
    }
}
