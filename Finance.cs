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
    public partial class Finance : Form
    {
        public Finance()
        {
            InitializeComponent();
            populateExp();
            populateInc();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Cows obj = new Cows();
            obj.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            MilkProduction obj = new MilkProduction();
            obj.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            CowsHealth obj = new CowsHealth();
            obj.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Breeing obj = new Breeing();
            obj.Show();
            this.Hide();
        }

        private void label14_Click(object sender, EventArgs e)
        {
            MilkSales obj = new MilkSales();
            obj.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            Finance obj = new Finance();
            obj.Show();
            this.Hide();
        }

        private void label16_Click(object sender, EventArgs e)
        {
            DashBoard obj = new DashBoard();
            obj.Show();
            this.Hide();
        }
        SqlConnection COn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Projects\Visual Studio 2022\Dairy Farm Management System\DairyFarmManagementSystem.mdf"";Integrated Security=True;Connect Timeout=30");

        private void populateExp()
        {
            //P Here
            COn.Open();
            string query = "select * from ExpenditrueTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, COn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            ExpDGV.DataSource = ds.Tables[0];
            COn.Close();
        }

        private void populateInc()
        {
            //P Here
            COn.Open();
            string query = "select * from IncomeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, COn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            COn.Close();
        }

        private void FilterIncome()
        {
            COn.Open();
            string query = "select * from IncomeTbl where IncDate = '"+IncomeDateFilter.Value.Date+"'";
            SqlDataAdapter sda = new SqlDataAdapter(query, COn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            IncDGV.DataSource = ds.Tables[0];
            COn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Exp
            if (PurpCb.SelectedIndex == -1 || AmountTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    COn.Open();
                    string Query = "insert into ExpenditrueTbl values ('" + ExpDate.Value.Date + "','" + PurpCb.SelectedItem.ToString() + "','" + AmountTb.Text + "','" + EmpIdLbl.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, COn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Expenditure Saved Successfully");
                    COn.Close();
                    populateExp();
                    //Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void ClearInc()
        {
            IncAmount.Text = "";
            IncPurpCb.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Income
            if (IncPurpCb.SelectedIndex == -1 || IncAmount.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    COn.Open();
                    string Query = "insert into IncomeTbl values ('" + IncDate.Value.Date + "','" + IncPurpCb.SelectedItem.ToString() + "','" + IncAmount.Text + "','" + EmpIdLbl.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, COn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Income Saved Successfully");
                    COn.Close();
                    populateInc();
                    ClearInc();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            FilterIncome();
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            populateInc();
        }
    }
}
