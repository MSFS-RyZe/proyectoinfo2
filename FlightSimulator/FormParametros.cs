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

namespace FlightSimulator
{
    public partial class FormParametros : Form
    {
        private FlightPlanList data;
        public void SetData(FlightPlanList d)
        {
            data = d;
        }
        public FlightPlanList GetData()
        {
            return data;
        }

        public FormParametros()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                double distancia = Convert.ToDouble(txtdistancia.Text);
                double tiempo = Convert.ToDouble(txtciclo.Text);

                data.SetDistanciaSeguridad(distancia);
                data.SetCiclo(tiempo);

                MessageBox.Show("Parámetros guardados");
                this.Close();
            }
            catch
            {
                MessageBox.Show("Error en los datos");
            }
        }
    }
}
