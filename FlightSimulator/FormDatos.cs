using System;
using System.IO;
using System.Windows.Forms;
using FlightLib;

namespace FlightSimulator
{
    public partial class FormDatos : Form
    {
        private FlightPlanList data = new FlightPlanList();

        public FormDatos()
        {
            InitializeComponent();
        }

        public void SetData(FlightPlanList d)
        {
            this.data = d;
        }

        public FlightPlanList GetData()
        {
            return this.data;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                data.Reset();

                FlightPlan avion1 = new FlightPlan(
                    txtid_1.Text,
                    Convert.ToDouble(txtx0_1.Text),
                    Convert.ToDouble(txty0_1.Text),
                    Convert.ToDouble(txtx1_1.Text),
                    Convert.ToDouble(txty1_1.Text),
                    Convert.ToDouble(txtvelocidad_1.Text)
                );
                data.AddFlightPlan(avion1);

                FlightPlan avion2 = new FlightPlan(
                    txtid_2.Text,
                    Convert.ToDouble(txtx0_2.Text),
                    Convert.ToDouble(txty0_2.Text),
                    Convert.ToDouble(txtx1_2.Text),
                    Convert.ToDouble(txty1_2.Text),
                    Convert.ToDouble(txtvelocidad_2.Text)
                );
                data.AddFlightPlan(avion2);

                MessageBox.Show("Datos manuales guardados con éxito.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch
            {
                MessageBox.Show("Por favor, rellena todos los campos correctamente.", "Error de Formato");
            }
        }

        private void btnarchivo_Click(object sender, EventArgs e)
        {
            data.Reset();
            data.AddFlightPlan(new FlightPlan("AvionTest1", 100, 150, 800, 150, 120));
            data.AddFlightPlan(new FlightPlan("AvionTest2", 150, 400, 750, 100, 140));

            MessageBox.Show("Escenario de prueba cargado.");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        public void btnImportarArchivo_Click(object sender, EventArgs e)
        {
            OpenFileDialog buscador = new OpenFileDialog();
            buscador.Filter = "Archivos de texto (*.txt)|*.txt";
            buscador.Title = "Selecciona el archivo de vuelos";

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StreamReader r = new StreamReader(buscador.FileName);
                    string line;

                    data.Reset();

                    while ((line = r.ReadLine()) != null)
                    {
                        line = line.Trim();
                        if (string.IsNullOrEmpty(line)) continue;

                        string[] trozos = line.Split(' ');

                        if (trozos.Length >= 6)
                        {
                            string id = trozos[0];
                            double x0 = Convert.ToDouble(trozos[1]);
                            double y0 = Convert.ToDouble(trozos[2]);
                            double x1 = Convert.ToDouble(trozos[3]);
                            double y1 = Convert.ToDouble(trozos[4]);
                            double velocidad = Convert.ToDouble(trozos[5]);

                            FlightPlan temp = new FlightPlan(id, x0, y0, x1, y1, velocidad);
                            data.AddFlightPlan(temp);
                        }
                    }
                    r.Close();
                    MessageBox.Show("Escenario con rutas importado con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Error al leer el archivo .txt", "Error");
                }
            }
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}