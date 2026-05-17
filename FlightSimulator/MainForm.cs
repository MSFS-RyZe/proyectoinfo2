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
    public partial class MainForm : Form
    {
        private FlightPlanList data = new FlightPlanList();

        public MainForm()
        {
            InitializeComponent();
        }

        private void datosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void introducirPlanesDeVueloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDatos form = new FormDatos();
            form.SetData(data);
            form.ShowDialog();
        }

        private void parámetrosDeSimulaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormParametros form = new FormParametros();
            form.SetData(data);
            form.ShowDialog();
        }

        private void iniciarSimulaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnguardar form = new btnguardar();
            form.SetData(data);
            form.ShowDialog();
        }
    }
}