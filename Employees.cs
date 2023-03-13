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
    public partial class Employees : Form
    {
        public Employees()
        {
            InitializeComponent();
            populate();
        }

        SqlConnection COn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Projects\Visual Studio 2022\Dairy Farm Management System\DairyFarmManagementSystem.mdf"";Integrated Security=True;Connect Timeout=30");
        
        private void populate()
        {
            //P Here
            COn.Open();
            string query = "select * from EmployeeTbl";
            SqlDataAdapter sda = new SqlDataAdapter(query, COn);
            SqlCommandBuilder builder = new SqlCommandBuilder(sda);
            var ds = new DataSet();
            sda.Fill(ds);
            EmployeesDGV.DataSource = ds.Tables[0];
            COn.Close();
        }

        private void Clear()
        {
            PhoneTb.Text = "";
            EmployeesNameTb.Text = "";
            AddressTb.Text = "";
            GenCb.SelectedIndex = -1;
            key = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (EmployeesNameTb.Text == "" || GenCb.SelectedIndex == -1 || PhoneTb.Text == "" || AddressTb.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else
            {
                try
                {
                    COn.Open();
                    string Query = "insert into EmployeeTbl values ('" + EmployeesNameTb.Text + "','" + DOB.Value.Date +  "','" + GenCb.SelectedItem.ToString() + "','"  +  PhoneTb.Text + "','" + AddressTb.Text + "')";
                    SqlCommand cmd = new SqlCommand(Query, COn);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Employee Saved Successfully");
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
        int key = 0;
        private void EmployeesDGV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            EmployeesNameTb.Text = EmployeesDGV.SelectedRows[0].Cells[1].Value.ToString();
            DOB.Text = EmployeesDGV.SelectedRows[0].Cells[2].Value.ToString();
            GenCb.SelectedItem = EmployeesDGV.SelectedRows[0].Cells[3].Value.ToString();
            PhoneTb.Text = EmployeesDGV.SelectedRows[0].Cells[4].Value.ToString();
            AddressTb.Text = EmployeesDGV.SelectedRows[0].Cells[5].Value.ToString();
            if (EmployeesNameTb.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(EmployeesDGV.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
    }
}
