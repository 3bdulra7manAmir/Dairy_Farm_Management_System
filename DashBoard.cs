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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
            Finance();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            Cows obj = new Cows();
            obj.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            MilkProduction obj = new MilkProduction();
            obj.Show();
            this.Hide();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            CowsHealth obj = new CowsHealth();
            obj.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {
            Breeing obj = new Breeing();
            obj.Show();
            this.Hide();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
            MilkSales obj = new MilkSales();
            obj.Show();
            this.Hide();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            Finance obj = new Finance();
            obj.Show();
            this.Hide();
        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            DashBoard obj = new DashBoard();
            obj.Show();
            this.Hide();
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

        SqlConnection COn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""D:\Projects\Visual Studio 2022\Dairy Farm Management System\DairyFarmManagementSystem.mdf"";Integrated Security=True;Connect Timeout=30");
        private void Finance()
        {
            //
            COn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select sum(IncAmt) from IncomeTbl", COn);
            SqlDataAdapter sda1 = new SqlDataAdapter("select sum(ExpAmount) from ExpenditrueTbl", COn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            int inc, exp;
            double bal;
            inc = Convert.ToInt32(dt.Rows[0][0].ToString());
            IncLbl.Text = "Rs" + dt.Rows[0][0].ToString();
            DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            exp = Convert.ToInt32(dt1.Rows[0][0].ToString());
            bal = inc - exp;
            ExpLbl.Text = "Rs" + dt1.Rows[0][0].ToString();
            BalLbl.Text = "Rs" + bal;
            COn.Close();
        }

        private void Logistic()
        {
            //
            COn.Open();
            SqlDataAdapter sda = new SqlDataAdapter("select Count(*) from CowTbl", COn);
            //SqlDataAdapter sda1 = new SqlDataAdapter("select sum(ExpAmount) from ExpenditrueTbl", COn);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            CowNumLbl.Text = dt.Rows[0][0].ToString();
            //int inc, exp;
            //double bal;
            //inc = Convert.ToInt32(dt.Rows[0][0].ToString());
            //IncLbl.Text = "Rs" + dt.Rows[0][0].ToString();
            /*DataTable dt1 = new DataTable();
            sda1.Fill(dt1);
            exp = Convert.ToInt32(dt1.Rows[0][0].ToString());
            bal = inc - exp;
            ExpLbl.Text = "Rs" + dt1.Rows[0][0].ToString();
            BalLbl.Text = "Rs" + bal;*/
            COn.Close();
        }

        private void DashBoard_Load(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }
    }
}
