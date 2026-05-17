using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightLib;

namespace FlightSimulator
{
    public partial class FormDatos : Form
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
        public FormDatos()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //Avión1
                string id_1 = txtid_1.Text;

                double x0_1 = Convert.ToDouble(txtx0_1.Text);
                double y0_1 = Convert.ToDouble(txty0_1.Text);
                double x1_1 = Convert.ToDouble(txtx1_1.Text);
                double y1_1 = Convert.ToDouble(txty1_1.Text);
                double velocidad_1 = Convert.ToDouble(txtvelocidad_1.Text);

                FlightPlan avion1 = new FlightPlan(id_1, x0_1, y0_1, x1_1, y1_1, velocidad_1);

                // AVION 2
                string id_2 = txtid_2.Text;

                double x0_2 = Convert.ToDouble(txtx0_2.Text);
                double y0_2 = Convert.ToDouble(txty0_2.Text);
                double x1_2 = Convert.ToDouble(txtx1_2.Text);
                double y1_2 = Convert.ToDouble(txty1_2.Text);
                double velocidad_2 = Convert.ToDouble(txtvelocidad_2.Text);

                FlightPlan avion2 = new FlightPlan(id_2, x0_2, y0_2, x1_2, y1_2, velocidad_2);


                data.Reset();
                data.AddFlightPlan(avion1);
                data.AddFlightPlan(avion2);

                MessageBox.Show("Datos guardados correctamente");
                this.Close();
            }
            catch(FormatException)
            {
                MessageBox.Show("Error en el formato de los datos");
            }
        
        }

        private void btnarchivo_Click(object sender, EventArgs e) //Carga los datos desde el archivo planesdevuelo.txt//
        {
            StreamReader r = new StreamReader("planesdevuelo.txt");
            string line;
            try
            {
                while((line = r.ReadLine()) != null)
                {
                    string [] trozos = line.Split(' ');
                    string id = trozos[0];
                    double x0 = Convert.ToDouble(trozos[1]);
                    double y0 = Convert.ToDouble(trozos[2]);
                    double x1 = Convert.ToDouble(trozos[3]);
                    double y1 = Convert.ToDouble(trozos[4]);
                    double velocidad = Convert.ToDouble(trozos[5]);
                    FlightPlan temp = new FlightPlan(id, x0, y0, x1, y1, velocidad);
                    data.AddFlightPlan(temp);
                }
                r.Close();
                MessageBox.Show("Datos cargados correctamente");
                this.Close();
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("No se ha encontrado el archivo");
            }
            catch(FormatException)
            {
                MessageBox.Show("Error en el formato de los datos");
            }
            
        }
    }
}
