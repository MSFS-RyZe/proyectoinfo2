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
    public partial class FormInfoAvion : Form
    {
        FlightPlan avion;
        private FlightPlanList data;
        public void SetData(FlightPlanList d)
        {
            data = d;
        }
        public FlightPlanList GetData()
        {
            return data;
        }

        public FormInfoAvion(FlightPlan a)
        {
            InitializeComponent();
            this.avion = a;
        }

        private void FormInfoAvion_Load(object sender, EventArgs e)
        {
            lblid.Text = "IDENTIFICADOR: " + avion.GetId();
            lblvelocidad.Text = "VELOCIDAD: " + avion.GetVelocidad();

            double x = avion.GetCurrentPosition().GetX();
            double y = avion.GetCurrentPosition().GetY();

            lblposicion.Text = "POSICIÓN: (" + x + "," + y + ")";

        }
    }
}
