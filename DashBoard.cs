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
    public partial class DashBoard : Form
    {
        public DashBoard()
        {
            InitializeComponent();
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
    }
}
