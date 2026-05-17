using FlightLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightSimulator
{
    public partial class btnguardar : Form
    {
        private FlightPlanList data;
        private Stack<List<Position>> historial = new Stack<List<Position>>();
        

        public void SetData(FlightPlanList d)
        {
            data = d;
        }
        public FlightPlanList GetData()
        {
            return data;
        }
        public btnguardar()
        {
            InitializeComponent();
        }

        private void btnMover_Click(object sender, EventArgs e)//Mueve la simulación paso por paso//
        {
            List<Position> estado = new List<Position>();

            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan p = data.GetFlightPlan(i);

                Position pos = p.GetCurrentPosition();

                estado.Add(new Position(pos.GetX(), pos.GetY()));
            }
            historial.Push(estado);

            data.Mover(data.GetCiclo());
            PanelSimulacion.Invalidate();
        }
        private void btndeshacer_Click(object sender, EventArgs e)//Retrocede la simulación paso por paso//
        {
            if (historial.Count > 0)
            {
                List<Position> estado = historial.Pop();

                for (int i = 0; i < data.GetNumber(); i++)
                {
                    FlightPlan p = data.GetFlightPlan(i);

                    p.SetCurrentPosition(estado[i]);
                }

                PanelSimulacion.Invalidate();
            }
            if (historial.Count == 0)
            {
                MessageBox.Show("No se puede deshacer más");
            }
        }

        private void timer1_Tick(object sender, EventArgs e)//detecta si hay conflicto al momento//
        {
            List<Position> estado = new List<Position>();
            bool hayMovimiento = false;

            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan p = data.GetFlightPlan(i);

                if (!p.EstaEnDestino())
                {
                    p.Mover(data.GetCiclo());
                    Position pos = p.GetCurrentPosition();
                    estado.Add(new Position(pos.GetX(), pos.GetY()));
                    historial.Push(estado);
                    if (p.EstaEnDestino())
                    {
                        p.SetCurrentPosition(p.GetFinalPosition());
                    }
                    hayMovimiento = true;
                }
            }

            if (hayMovimiento)
            {
                PanelSimulacion.Invalidate();
            }
            else
            {
                timer1.Stop();
            }
        }

        private void btnIniciar_Click(object sender, EventArgs e)//inicia la simulación//
        {
            timer1.Start();
        }

        private void btnDetener_Click(object sender, EventArgs e)//para la simulación//
        {
            timer1.Stop();
        }

        private void btnDatos_Click(object sender, EventArgs e)//abre el form con los datos de cada avión en la simulación//
        {
            FormListaVuelos form = new FormListaVuelos();
            form.SetData(this.data);
            form.ShowDialog();
        }

        private void btnComprobar_Click(object sender, EventArgs e)//te avisa si hay un futuro conflicto//
        {
            FlightPlan p1 = data.GetFlightPlan(0);
            FlightPlan p2 = data.GetFlightPlan(1);

            double d = data.GetDistanciaSeguridad();

            if (p1.HabraConflicto(p2, d))
            {
                MessageBox.Show("Habrá conflicto durante el vuelo");
            }
            else
            {
                MessageBox.Show("No habrá conflicto");
            }
        }
        private void CargarTabla()//muestra la tabla con las velocidades//
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan p = data.GetFlightPlan(i);

                dataGridView1.Rows.Add(
                    p.GetId(),
                    p.GetVelocidad()
                );
            }
        }

        private void FormSimulacion_Load(object sender, EventArgs e)
        {
            FlightPlan p1 = data.GetFlightPlan(0);
            FlightPlan p2 = data.GetFlightPlan(1);

            double d = data.GetDistanciaSeguridad();

            if (data.HabraMultipleConflicto(d))//detecta si hay futuro conflicto//
            {
                DialogResult result = MessageBox.Show(
                    "Habrá conflicto. ¿Quieres resolverlo automáticamente?",
                    "Conflicto detectado",
                    MessageBoxButtons.YesNo
                );

                if (result == DialogResult.Yes)
                {
                    bool resuelto = p1.ReducirVelocidad(p2, d);

                    if (resuelto)
                    {
                        MessageBox.Show("Conflicto resuelto modificando velocidades");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo resolver el conflicto automáticamente");
                    }
                }
            }
            CargarTabla();
        }
        private void ReiniciarSimulacion()//reinicia la simulación//
        {
            timer1.Stop();

            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan p = data.GetFlightPlan(i);

                double x = p.GetInitialPosition().GetX();
                double y = p.GetInitialPosition().GetY();

                p.SetCurrentPosition(new Position(x, y));
            }

            PanelSimulacion.Invalidate();

        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)//tabla para editar las velocidades//
        {
            int fila = e.RowIndex;

            if (fila < 0) return;

            FlightPlan p = data.GetFlightPlan(fila);

            try
            {
                double nuevaVelocidad = Convert.ToDouble(
                    dataGridView1.Rows[fila].Cells[1].Value
                );

                p.SetVelocidad(nuevaVelocidad);

                ReiniciarSimulacion();
            }
            catch
            {
                MessageBox.Show("Valor inválido");
            }
        }

        private void button1_Click(object sender, EventArgs e)//botón para guardar en un archivo//
        {
            StreamWriter w = new StreamWriter("situación.txt");
            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan p = data.GetFlightPlan(i);
                string id = p.GetId();
                double x = p.GetCurrentPosition().GetX();
                double y = p.GetCurrentPosition().GetY();
                double velocidad = p.GetVelocidad();
                w.WriteLine(id + " " + x + " " + y + " " + velocidad);

            }
            w.Close();
            MessageBox.Show("Situación guardada");
        }

        private void PanelSimulacion_Paint(object sender, PaintEventArgs e)//panel para delimitar la zona de la simulación//
        {
            Graphics g = e.Graphics;
            double d = data.GetDistanciaSeguridad();

            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan p = data.GetFlightPlan(i);

                // Línea trayectoria
                float x0 = (float)(p.GetInitialPosition().GetX() % PanelSimulacion.Width);
                float y0 = (float)(p.GetInitialPosition().GetY() % PanelSimulacion.Height);

                float x1 = (float)(p.GetFinalPosition().GetX() % PanelSimulacion.Width);
                float y1 = (float)(p.GetFinalPosition().GetY() % PanelSimulacion.Height);



                // Avión actual
                float x = (float)(p.GetCurrentPosition().GetX() % PanelSimulacion.Width);
                float y = (float)(p.GetCurrentPosition().GetY() % PanelSimulacion.Height);



                //Distancia de seguridad
                float centroX = x + 5;
                float centroY = y + 5;

                float radio = (float)data.GetDistanciaSeguridad();
                float diametro = radio * 2;



                g.DrawLine(Pens.Black, x0, y0, x1, y1);

                g.FillEllipse(Brushes.Blue, x, y, 10, 10);

                g.DrawEllipse(Pens.Green, centroX - radio, centroY - radio, diametro, diametro);
                bool enConflicto = false;

                for (int j = 0; j < data.GetNumber(); j++)//bucle para solamente pintar los aviones que están en conflicto//
                {
                    if (i != j)
                    {
                        FlightPlan otro = data.GetFlightPlan(j);

                        double dx = p.GetCurrentPosition().GetX() - otro.GetCurrentPosition().GetX();
                        double dy = p.GetCurrentPosition().GetY() - otro.GetCurrentPosition().GetY();

                        double distancia = Math.Sqrt(dx * dx + dy * dy);

                        if (distancia < d)
                        {
                            enConflicto = true;
                            break;
                        }
                    }
                }
                if (enConflicto)
                {
                    g.DrawEllipse(Pens.Red, centroX - radio, centroY - radio, diametro, diametro);
                }
            }
        }

        private void btnreiniciar_Click(object sender, EventArgs e)//botón para reiniciar la simulación//
        {
            ReiniciarSimulacion();
        }

        private void PanelSimulacion_MouseClick(object sender, MouseEventArgs e)//abre el formulario con los datos del avión seleccionado//
        {
            int mouseX = e.X;
            int mouseY = e.Y;

            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan a = data.GetFlightPlan(i);

                float x = (float)(a.GetCurrentPosition().GetX() % PanelSimulacion.Width);
                float y = (float)(a.GetCurrentPosition().GetY() % PanelSimulacion.Height);

                // Detectar si clic está cerca del avión
                int size = 20;

                if (mouseX >= x && mouseX <= x + size &&
                    mouseY >= y && mouseY <= y + size)
                {
                    // Abrir formulario
                    FormInfoAvion form = new FormInfoAvion(a);
                    form.SetData(this.data);
                    form.ShowDialog();
                }
            }
        }
    }
}
