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
    public partial class FormListaVuelos : Form
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
        public FormListaVuelos()
        {
            InitializeComponent();
        }

        private void FormListaVuelos_Load(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan p = data.GetFlightPlan(i);

                dataGridView1.Rows.Add(
                    p.GetId(),
                    p.GetVelocidad(),
                    p.GetInitialPosition().GetX(),
                    p.GetInitialPosition().GetY(),
                    p.GetFinalPosition().GetX(),
                    p.GetFinalPosition().GetY(),
                    p.GetCurrentPosition().GetX(),
                    p.GetCurrentPosition().GetY()
                );
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int fila = e.RowIndex;

            if (fila < 0) return; // evita error en cabecera

            FlightPlan seleccionado = data.GetFlightPlan(fila);

            // Obtener el otro vuelo
            FlightPlan otro;

            if (fila == 0)
                otro = data.GetFlightPlan(1);
            else
                otro = data.GetFlightPlan(0);

            FormDistancia form = new FormDistancia(seleccionado, otro);
            form.ShowDialog();
        }
    }
}
