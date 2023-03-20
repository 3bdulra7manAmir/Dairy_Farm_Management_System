using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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
        SqlConnection COn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Projects\Visual Studio 2022\Dairy Farm Management System\DairyFarmManagementSystem.mdf"";Integrated Security=True;Connect Timeout=30");
        private void label7_Click(object sender, EventArgs e)
        {
            UnameTb.Text = "";
            PasswordTb.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(UnameTb.Text == "" || PasswordTb.Text == "")
            {
                MessageBox.Show("Enter The Username And Password");
            }
            else
            {
                if (RoleCb.SelectedIndex > -1)
                {
                    if (RoleCb.SelectedItem.ToString() == "Admin")
                    {
                        if (PasswordTb.Text == "Admin" && UnameTb.Text == "Admin")
                        {
                            Employees prod = new Employees();
                            prod.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("If You are the Admin Enter the Correct ID and Password");
                        }
                    }
                    else //here
                    {
                        COn.Open();
                        SqlDataAdapter sda = new SqlDataAdapter("Select Count(*) from EmployeeTbl where EmpName= '" + UnameTb.Text + "' and EmpPass='" + PasswordTb.Text + "'", COn);
                        DataTable dt = new DataTable();
                        sda.Fill(dt);
                        if (dt.Rows[0][0].ToString() == "1")
                        {
                            Cows Cow = new Cows();
                            Cow.Show();
                            this.Hide();
                            COn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Wrong UserName or Password");
                        }
                        COn.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Select a Role");
                }
            }

            
        }

        private void PasswordTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
