﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace Dairy_Farm_Management_System
{
    public partial class Breeing : Form
    {
        public Breeing()
        {
            InitializeComponent();
            populate();
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

        private void populate()
        {
            //P Here
            COn.Open();
            string query = "select * from BreedTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, COn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            BreedDGV.DataSource = ds.Tables[0];
            COn.Close();
        }
        //string Cow_Age;
        private void GetCowName()
        {
            COn.Open();
            string query = "select * from CowTbl where CowId =" + CowIdCb.SelectedValue.ToString() + "";
            SqlCommand cmd = new SqlCommand(query, COn);
            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                CowNameTb.Text = dr["CowName"].ToString();
                CowAge.Text = dr["Age"].ToString();
            }
            COn.Close();
        }

        private void Breeing_Load(object sender, EventArgs e)
        {

        }

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void Clear()
        {
            CowNameTb.Text = "";
            RemarksTb.Text = "";
            CowAge.Text = "";
            key = 0;
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || RemarksTb.Text == "" || CowAge.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    COn.Open();
                    string Query = "insert into BreedTbl values ('" + HeatDate.Value.Date + "','" + BreedDate.Value.Date + "','" + CowIdCb.SelectedValue.ToString() + "','" + CowNameTb.Text + "'," + PregDate.Value.Date + "," + ExpDate.Value.Date+ ",'" + DateCalved.Value.Date + ",'" + CowAge.Text + ",'" + RemarksTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, COn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breeding Report Saved Successfully");
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

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }
        int key = 0;
        private void BreedDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            HeatDate.Text = BreedDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNameTb.Text = BreedDGV.SelectedRows[0].Cells[2].Value.ToString();
            CowIdCb.SelectedValue = BreedDGV.SelectedRows[0].Cells[3].Value.ToString();
            CowNameTb.Text = BreedDGV.SelectedRows[0].Cells[4].Value.ToString();
            PregDate.Text = BreedDGV.SelectedRows[0].Cells[5].Value.ToString();
            ExpDate.Text = BreedDGV.SelectedRows[0].Cells[6].Value.ToString();
            DateCalved.Text = BreedDGV.SelectedRows[0].Cells[7].Value.ToString();
            CowAge.Text = BreedDGV.SelectedRows[0].Cells[8].Value.ToString();
            RemarksTb.Text = BreedDGV.SelectedRows[0].Cells[9].Value.ToString();
            if (CowNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(BreedDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Breed Report Be Deleted!");
            }
            else
            {
                try
                {
                    COn.Open();
                    string Query = "delete from BreedTbl where BrId = " + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, COn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breed Deleted Successfully");
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
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || RemarksTb.Text == "" || CowAge.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    COn.Open();
                    string Query = "update BreedTbl set HeatDate=" + HeatDate.Value.Date + "',BreedDate='" + BreedDate.Value.Date + "',CowId='" + CowIdCb.SelectedValue.ToString() + ",CowName='" + CowNameTb.Text + "',PregDate='" + PregDate.Value.Date + "',ExpDateCalve='" + ExpDate.Value.Date + "',DateCalved='" + DateCalved.Value.Date + ",CowAge='" + CowAge.Text + ",Remarks='" + RemarksTb.Text + "' where BrId= " + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, COn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Breeding Updated Successfully");
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

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
