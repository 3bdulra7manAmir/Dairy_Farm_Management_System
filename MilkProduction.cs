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
    public partial class MilkProduction : Form
    {
        public MilkProduction()
        {
            InitializeComponent();
            FillCowId();
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
        private void FillCowId()
        {
            COn.Open();
            SqlCommand cmd = new SqlCommand("select CowId from CowTbl", COn);
            SqlDataReader Rdr;
            Rdr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("CowId", typeof(int));
            dt.Load(Rdr);
            CowIdCb.ValueMember = "CowId";
            CowIdCb.DataSource = dt;
            COn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowsNameTb.Text == "" || AmTb.Text == "" || PmTb.Text == "" || NoonTb.Text == "" || TotalTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    COn.Open();
                    string Query = "insert into MilkTbl values ('" + CowIdCb.SelectedValue.ToString() + "','" + CowsNameTb.Text + "','" + AmTb.Text + "','" + NoonTb.Text + "'," + PmTb.Text + "," + TotalTb.Text + ",'" + Date.Value.Date + "')";
                    SqlCommand cmd = new SqlCommand(Query, COn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Saved Successfully");
                    COn.Close();
                    //populate();
                    //Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
