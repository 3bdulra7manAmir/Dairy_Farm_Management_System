using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Dairy_Farm_Management_System
{
    public partial class Cows : Form
    {
        public Cows()
        {
            InitializeComponent();
            populate();
        }
        SqlConnection COn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Projects\Visual Studio 2022\Dairy Farm Management System\DairyFarmManagementSystem.mdf"";Integrated Security=True;Connect Timeout=30");
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
        int age = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if(CowNameTb.Text == "" || EarTagTb.Text == "" || ColorTb.Text == "" || BreedTb.Text == "" || WeigthTb.Text == "" || AgeTb.Text == "" || PastureTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    COn.Open();
                    string Query = "insert into CowTbl values ('" + CowNameTb.Text + "','" + EarTagTb.Text + "','" + ColorTb.Text + "','" + BreedTb.Text + "'," + age + "," + WeigthTb.Text + ",'" + PastureTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, COn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Saved Successfully");
                    COn.Close();
                    populate();
                    Clear();
                }
                catch(Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void DOBDate_ValueChanged(object sender, EventArgs e)
        {
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days) / 365;
        }

        private void DOBDate_MouseLeave(object sender, EventArgs e)
        {
            AgeTb.Text = "" + age;
            age = Convert.ToInt32((DateTime.Today.Date - DOBDate.Value.Date).Days) / 365;
        }

        private void populate()
        {
            //P Here
            COn.Open();
            string query = "select * from CowTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, COn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            CowsDGV.DataSource = ds.Tables[0];
            COn.Close();
        }
        private void Clear()
        {
            CowNameTb.Text = "";
            EarTagTb.Text = "";
            ColorTb.Text = "";
            BreedTb.Text = "";
            WeigthTb.Text = "";
            AgeTb.Text = "";
            PastureTb.Text = "";
            key = 0;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }
        int key = 0;
        private void CowsDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowNameTb.Text = CowsDGV.SelectedRows[0].Cells[1].Value.ToString();
            EarTagTb.Text = CowsDGV.SelectedRows[0].Cells[2].Value.ToString();
            ColorTb.Text = CowsDGV.SelectedRows[0].Cells[3].Value.ToString();
            BreedTb.Text = CowsDGV.SelectedRows[0].Cells[4].Value.ToString();
            WeigthTb.Text = CowsDGV.SelectedRows[0].Cells[5].Value.ToString();
            AgeTb.Text = CowsDGV.SelectedRows[0].Cells[6].Value.ToString();
            PastureTb.Text = CowsDGV.SelectedRows[0].Cells[7].Value.ToString();
            if(CowNameTb.Text == "")
            {
                key = 0;
                age = 0;
            }
            else
            {
                key = Convert.ToInt32(CowsDGV.SelectedRows[0].Cells[0].Value.ToString());
                age = Convert.ToInt32(CowsDGV.SelectedRows[0].Cells[5].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Cow To Be Deleted!");
            }
            else
            {
                try
                {
                    COn.Open();
                    string Query = "delete from CowTbl where CowId = " + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, COn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Saved Successfully");
                    COn.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (CowNameTb.Text == "" || EarTagTb.Text == "" || ColorTb.Text == "" || BreedTb.Text == "" || WeigthTb.Text == "" || AgeTb.Text == "" || PastureTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    COn.Open();
                    string Query = "update CowTbl set CowName='"+CowNameTb.Text+"',EarTag='"+EarTagTb.Text+"',Color='"+ColorTb.Text+"',Breed='"+BreedTb.Text+"',Age=" + age + ",weigthatbirth=" + WeigthTb.Text + ",Pasture='" + PastureTb.Text + "' where CowId = "+ key + ";";
                    SqlCommand cmd = new SqlCommand(Query, COn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Cow Updated Successfully");
                    COn.Close();
                    populate();
                    Clear();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
    }
}
