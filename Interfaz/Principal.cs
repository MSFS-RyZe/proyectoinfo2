using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;

namespace Interfaz
{
    public partial class Principal : Form
    {
        FlightPlanList lista = new FlightPlanList();
        string id1;
        string id2;
        double velocidad1;
        double velocidad2;
        double xi1;
        double xi2;
        double xf1;
        double xf2;
        double yi1;
        double yi2;
        double yf1;
        double yf2;

        public Principal()
        {
            InitializeComponent();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void planesDeVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 F = new Form1();
            F.ShowDialog();


        }

        private void FormDatosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void opcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
