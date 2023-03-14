using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace laba2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double rateEuro, rateDollar; 
        const double k = 0.1; 
        Random random = new Random();
        bool NewModel = true; 

        private void timer1_Tick(object sender, EventArgs e)
        {
            rateEuro = rateEuro * (1 + k * (random.NextDouble() - 0.5)); 
            rateDollar = rateDollar * (1 + k * (random.NextDouble() - 0.5)); 
            chart1.Series[0].Points.AddXY(0, rateEuro);
            chart1.Series[1].Points.AddXY(0, rateDollar);
        }

        private void btClear_Click_1(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            NewModel = true;
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            if (NewModel)
            {
                rateEuro = (double)inputPrice2.Value; 
                rateDollar = (double)inputPrice1.Value; 

                chart1.Series[0].Points.Clear(); 
                chart1.Series[1].Points.Clear(); 
                chart1.Series[0].Points.AddXY(0, rateEuro); 
                chart1.Series[1].Points.AddXY(0, rateDollar); 
            }
            NewModel = false;
            if (btStart.Text == "Старт")
            {
                btStart.Text = "Стоп";
                timer1.Start(); 
            }
            else
            {
                btStart.Text = "Старт";
                timer1.Stop();
            }
        }
    }
}
