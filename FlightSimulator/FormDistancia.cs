using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightSimulator
{
    public partial class FormDistancia : Form
    {
        FlightPlan p1;
        FlightPlan p2;

        public FormDistancia(FlightPlan a, FlightPlan b)
        {
            InitializeComponent();
            p1 = a;
            p2 = b;
           
        }

        private void FormDistancia_Load(object sender, EventArgs e)
        {
            double d = p1.Distance(p2);

            lblDistancia.Text = "Distancia entre vuelos: " + d.ToString("F2");
        }
    }
}
