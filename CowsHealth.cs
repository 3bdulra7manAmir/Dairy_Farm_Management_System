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

namespace Dairy_Farm_Management_System
{
    public partial class CowsHealth : Form
    {
        public CowsHealth()
        {
            InitializeComponent();
            FillCowId();
            populate();
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
            string query = "select * from HealthTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, COn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            HealthDGV.DataSource = ds.Tables[0];
            COn.Close();
        }

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
            }
            COn.Close();
        }

        private void bunifuMaterialTextbox5_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void CowIdCb_SelectionChangeCommitted(object sender, EventArgs e)
        {
            GetCowName();
        }

        private void Clear()
        {
            CowNameTb.Text = "";
            EventTb.Text = "";
            CostTb.Text = "";
            DiagnosisTb.Text = "";
            VetNameTb.Text = "";
            TreatmentTb.Text = "";
            key = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || EventTb.Text == "" || CostTb.Text == "" || VetNameTb.Text == "" || DiagnosisTb.Text == "" || TreatmentTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    COn.Open();
                    string Query = "insert into HealthTbl values ('" + CowIdCb.SelectedValue.ToString() + "','" + CowNameTb.Text + "','" + Date.Value.Date + "','" + EventTb.Text + "'," + DiagnosisTb.Text + "," + TreatmentTb.Text + ",'" + CostTb.Text + ",'"+VetNameTb.Text+"')";
                    SqlCommand cmd = new SqlCommand(Query, COn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Health issue Saved Successfully");
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

        private void VetNameTb_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Clear();
        }
        int key = 0;
        private void HealthDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            CowIdCb.SelectedValue = HealthDGV.SelectedRows[0].Cells[1].Value.ToString();
            CowNameTb.Text = HealthDGV.SelectedRows[0].Cells[2].Value.ToString();
            Date.Text = HealthDGV.SelectedRows[0].Cells[3].Value.ToString();
            EventTb.Text = HealthDGV.SelectedRows[0].Cells[4].Value.ToString();
            DiagnosisTb.Text = HealthDGV.SelectedRows[0].Cells[5].Value.ToString();
            TreatmentTb.Text = HealthDGV.SelectedRows[0].Cells[6].Value.ToString();
            CostTb.Text = HealthDGV.SelectedRows[0].Cells[7].Value.ToString();
            VetNameTb.Text = HealthDGV.SelectedRows[0].Cells[8].Value.ToString();
            if (CowNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(HealthDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (key == 0)
            {
                MessageBox.Show("Select The Report to Be Deleted!");
            }
            else
            {
                try
                {
                    COn.Open();
                    string Query = "delete from HealthTbl where RepId = " + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, COn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Report Deleted Successfully");
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
            if (CowIdCb.SelectedIndex == -1 || CowNameTb.Text == "" || EventTb.Text == "" || CostTb.Text == "" || VetNameTb.Text == "" || DiagnosisTb.Text == "" || TreatmentTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    COn.Open();
                    string Query = "update HealthTbl set CowId=" + CowIdCb.SelectedValue.ToString() + ",cowname='" + CowNameTb.Text + "',RepDate='" + Date.Value.Date + "',Event='" + EventTb.Text+ "',Diagnosis='"+DiagnosisTb.Text+"',Treatment='"+TreatmentTb.Text+"',Cost="+CostTb.Text+",VetName='"+VetNameTb.Text + "' where RepId= " + key + ";";
                    SqlCommand cmd = new SqlCommand(Query, COn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Product Updated Successfully");
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

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
