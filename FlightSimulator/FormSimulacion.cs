using FlightLib;
using Gestor;
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

namespace FlightSimulator
{
    public partial class btnguardar : Form
    {
        private FlightPlanList data;
        private Stack<List<Position>> historial = new Stack<List<Position>>();
        private CompanyDatabase companyDb = new CompanyDatabase();
        private StringBuilder reporteCambiosCompanias = new StringBuilder();

        private Button btnAnadirAvionManual;
        private Button btnBorrarAvion;
        private Button btnComprobarIncidencias;
        private Button btnVerDatosCompletos;

        private bool modoBorradoPorClic = false;

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
            companyDb.Iniciar();
            CrearBotonesDinamicos();
            ConfigurarAnclajesDinamicos();
        }

        // Ajustar componentes al cambiar tamaño de ventana
        private void ConfigurarAnclajesDinamicos()
        {
            this.PanelSimulacion.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;

            this.btnMover.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btndeshacer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnIniciar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnDetener.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnreiniciar.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            this.btnEditarParametros.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;

            this.Resize += (s, e) => { this.PanelSimulacion.Invalidate(); };
        }

        private void CrearBotonesDinamicos()
        {
            btnAnadirAvionManual = new Button() { Text = "AÑADIR AVIÓN", Font = new Font("Segoe UI", 9F, FontStyle.Bold), BackColor = Color.LightSkyBlue, Size = new Size(120, 40), Location = new Point(12, 12) };
            btnAnadirAvionManual.Click += new EventHandler(btnAnadirAvionManual_Click);
            this.Controls.Add(btnAnadirAvionManual);

            btnBorrarAvion = new Button() { Text = "BORRAR AVIÓN", Font = new Font("Segoe UI", 9F, FontStyle.Bold), BackColor = Color.LightCoral, Size = new Size(120, 40), Location = new Point(138, 12) };
            btnBorrarAvion.Click += new EventHandler(btnBorrarAvion_Click);
            this.Controls.Add(btnBorrarAvion);

            btnComprobarIncidencias = new Button() { Text = "COMPROBAR INCIDENCIAS", Font = new Font("Segoe UI", 9F, FontStyle.Bold), BackColor = Color.MediumPurple, ForeColor = Color.White, Size = new Size(200, 40), Location = new Point(264, 12) };
            btnComprobarIncidencias.Click += new EventHandler(btnComprobarIncidencias_Click);
            this.Controls.Add(btnComprobarIncidencias);

            btnVerDatosCompletos = new Button() { Text = "VER DATOS AVIONES", Font = new Font("Segoe UI", 9F, FontStyle.Bold), BackColor = Color.LightSeaGreen, ForeColor = Color.White, Size = new Size(180, 40), Location = new Point(470, 12) };
            btnVerDatosCompletos.Click += new EventHandler(btnVerDatosCompletos_Click);
            this.Controls.Add(btnVerDatosCompletos);

            btnAnadirAvionManual.BringToFront(); btnBorrarAvion.BringToFront(); btnComprobarIncidencias.BringToFront(); btnVerDatosCompletos.BringToFront();
        }

        // Simulacion virtual paso a paso para comprobar rutas
        private bool EvaluarConflictoSimulado(FlightPlan p1, FlightPlan p2, double distanciaSeguridad)
        {
            double x1 = p1.GetInitialPosition().GetX(); double y1 = p1.GetInitialPosition().GetY();
            double destX1 = p1.GetFinalPosition().GetX(); double destY1 = p1.GetFinalPosition().GetY();
            double v1 = p1.GetVelocidad();

            double x2 = p2.GetInitialPosition().GetX(); double y2 = p2.GetInitialPosition().GetY();
            double destX2 = p2.GetFinalPosition().GetX(); double destY2 = p2.GetFinalPosition().GetY();
            double v2 = p2.GetVelocidad();

            double dx1 = destX1 - x1; double dy1 = destY1 - y1; double d1 = Math.Sqrt(dx1 * dx1 + dy1 * dy1);
            double ux1 = d1 > 0 ? dx1 / d1 : 0; double uy1 = d1 > 0 ? dy1 / d1 : 0;

            double dx2 = destX2 - x2; double dy2 = destY2 - y2; double d2 = Math.Sqrt(dx2 * dx2 + dy2 * dy2);
            double ux2 = d2 > 0 ? dx2 / d2 : 0; double uy2 = d2 > 0 ? dy2 / d2 : 0;

            double cicloTime = data.GetCiclo();
            for (int paso = 0; paso < 150; paso++)
            {
                if (Math.Sqrt((x1 - p1.GetInitialPosition().GetX()) * (x1 - p1.GetInitialPosition().GetX()) + (y1 - p1.GetInitialPosition().GetY()) * (y1 - p1.GetInitialPosition().GetY())) < d1)
                { x1 += ux1 * v1 * (cicloTime / 60.0); y1 += uy1 * v1 * (cicloTime / 60.0); }

                if (Math.Sqrt((x2 - p2.GetInitialPosition().GetX()) * (x2 - p2.GetInitialPosition().GetX()) + (y2 - p2.GetInitialPosition().GetY()) * (y2 - p2.GetInitialPosition().GetY())) < d2)
                { x2 += ux2 * v2 * (cicloTime / 60.0); y2 += uy2 * v2 * (cicloTime / 60.0); }

                if (Math.Sqrt((x1 - x2) * (x1 - x2) + (y1 - y2) * (y1 - y2)) < distanciaSeguridad) return true;
            }
            return false;
        }

        // Comprobacion inicial de conflictos al cargar la ventana
        private void FormSimulacion_Load(object sender, EventArgs e)
        {
            if (data == null || data.GetNumber() == 0) return;

            double d = data.GetDistanciaSeguridad();
            List<int> indicesAEvitar = new List<int>();

            reporteCambiosCompanias.Clear();
            reporteCambiosCompanias.AppendLine("==========================================================================");
            reporteCambiosCompanias.AppendLine("     REPORTE DE MODIFICACIONES DE VELOCIDAD Y PLANES DE SEGURIDAD V2     ");
            reporteCambiosCompanias.AppendLine($"     Generado el: {DateTime.Now.ToString("dd/MM/yyyy a las HH:mm:ss")}");
            reporteCambiosCompanias.AppendLine("==========================================================================");
            reporteCambiosCompanias.AppendLine();

            bool huboModificaciones = false;

            for (int i = 0; i < data.GetNumber(); i++)
            {
                for (int j = i + 1; j < data.GetNumber(); j++)
                {
                    FlightPlan p1 = data.GetFlightPlan(i);
                    FlightPlan p2 = data.GetFlightPlan(j);

                    if (p1.GetCurrentPosition().GetX() < -1000 || p2.GetCurrentPosition().GetX() < -1000)
                        continue;

                    if (EvaluarConflictoSimulado(p1, p2, d))
                    {
                        bool solucionado = false;
                        double velOriginalP2 = p2.GetVelocidad();
                        double pruebaVel = velOriginalP2;

                        Company compaAfectada = companyDb.BuscarPorPrefijo(p2.GetId());

                        // Disminuir velocidad hasta el limite de 50
                        while (pruebaVel > 50)
                        {
                            pruebaVel -= 10;
                            if (pruebaVel < 50) pruebaVel = 50;
                            p2.SetVelocidad(pruebaVel);

                            if (!EvaluarConflictoSimulado(p1, p2, d))
                            {
                                solucionado = true;
                                huboModificaciones = true;

                                reporteCambiosCompanias.AppendLine($"📝 MODIFICACIÓN DE VELOCIDAD DE CRUCERO:");
                                reporteCambiosCompanias.AppendLine($"   • Avión: {p2.GetId()} | Ajuste: {velOriginalP2} km/h -> Reducido a {pruebaVel} km/h");
                                reporteCambiosCompanias.AppendLine($"   • Motivo: Evitar cruce crítico en ruta con [{p1.GetId()}]");
                                reporteCambiosCompanias.AppendLine($"   • COMPAÑÍA: {compaAfectada.Name} | Teléfono: {compaAfectada.Phone} | Email: {compaAfectada.Email}");
                                reporteCambiosCompanias.AppendLine("--------------------------------------------------------------------------");
                                break;
                            }
                        }

                        // Si disminuyendo no se arregla, pedir cancelacion
                        if (!solucionado)
                        {
                            p2.SetVelocidad(velOriginalP2);

                            DialogResult res = MessageBox.Show($"🚨 Conflicto Inmitigable Detectado:\n\nNinguna variación de velocidad salva la colisión geométrica entre [{p1.GetId()}] y [{p2.GetId()}].\n\n¿Deseas CANCELAR el despegue de [{p2.GetId()}]?", "Alerta de Tráfico Aéreo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (res == DialogResult.Yes)
                            {
                                if (!indicesAEvitar.Contains(j)) indicesAEvitar.Add(j);
                                huboModificaciones = true;

                                reporteCambiosCompanias.AppendLine($"❌ ORDEN DE CANCELACIÓN DE DESPEGUE:");
                                reporteCambiosCompanias.AppendLine($"   • Aeronave Suspendida: {p2.GetId()} (Ruta incompatible con [{p1.GetId()}])");
                                reporteCambiosCompanias.AppendLine($"   • COMPAÑÍA: {compaAfectada.Name} | Teléfono: {compaAfectada.Phone} | Email: {compaAfectada.Email}");
                                reporteCambiosCompanias.AppendLine("--------------------------------------------------------------------------");
                            }
                            else
                            {
                                DialogResult res2 = MessageBox.Show($"¿Deseas cancelar el despegue de [{p1.GetId()}] en su lugar?", "Opción Alternativa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                if (res2 == DialogResult.Yes)
                                {
                                    if (!indicesAEvitar.Contains(i)) indicesAEvitar.Add(i);
                                    huboModificaciones = true;
                                    Company compaAfectada1 = companyDb.BuscarPorPrefijo(p1.GetId());

                                    reporteCambiosCompanias.AppendLine($"❌ ORDEN DE CANCELACIÓN DE DESPEGUE:");
                                    reporteCambiosCompanias.AppendLine($"   • Aeronave Suspendida: {p1.GetId()} (Ruta incompatible con [{p2.GetId()}])");
                                    reporteCambiosCompanias.AppendLine($"   • COMPAÑÍA: {compaAfectada1.Name} | Teléfono: {compaAfectada1.Phone} | Email: {compaAfectada1.Email}");
                                    reporteCambiosCompanias.AppendLine("--------------------------------------------------------------------------");
                                }
                            }
                        }
                    }
                }
            }

            // Mover aviones cancelados fuera del mapa
            for (int k = 0; k < indicesAEvitar.Count; k++)
            {
                FlightPlan avionCancelado = data.GetFlightPlan(indicesAEvitar[k]);
                avionCancelado.SetCurrentPosition(new Position(-9999, -9999));
                avionCancelado.SetVelocidad(0);
            }

            // Exportar archivo txt al escritorio si hay cambios
            if (huboModificaciones)
            {
                try
                {
                    string rutaFichero = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Reporte_Notificaciones_Companias.txt");
                    File.WriteAllText(rutaFichero, reporteCambiosCompanias.ToString());
                    MessageBox.Show("💾 Archivo de cambios generado con éxito en el Escritorio.", "Reporte Guardado");
                }
                catch (Exception ex) { MessageBox.Show("Error al generar el archivo: " + ex.Message); }
            }

            CargarTabla();
            PanelSimulacion.Invalidate();
        }

        // Mostrar lista completa de todos los vuelos
        private void btnVerDatosCompletos_Click(object sender, EventArgs e)
        {
            if (data == null || data.GetNumber() == 0) return;

            Form ventanaVisualizar = new Form() { Text = "Telemetría Global de Vuelo con Datos de Aerolíneas", Size = new Size(720, 450), FormBorderStyle = FormBorderStyle.FixedDialog, StartPosition = FormStartPosition.CenterParent };
            TextBox txtReporte = new TextBox() { Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical, Font = new Font("Consolas", 10F), Size = new Size(675, 360), Location = new Point(15, 15) };

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("==========================================================================");
            sb.AppendLine("      PLANOS DE VUELO ACTIVOS - REVISIÓN LOGÍSTICA CON AEROLÍNEAS        ");
            sb.AppendLine("==========================================================================");
            sb.AppendLine();

            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan p = data.GetFlightPlan(i);
                if (p.GetCurrentPosition().GetX() < -1000) continue;

                Company c = companyDb.BuscarPorPrefijo(p.GetId());

                sb.AppendLine($"✈️ IDENTIFICADOR : {p.GetId()}");
                sb.AppendLine($"   📍 Origen     : ({p.GetInitialPosition().GetX()}, {p.GetInitialPosition().GetY()})");
                sb.AppendLine($"   🏁 Destino    : ({p.GetFinalPosition().GetX()}, {p.GetFinalPosition().GetY()})");
                sb.AppendLine($"   ⚡ Velocidad  : {p.GetVelocidad()} km/h");
                sb.AppendLine($"   🏢 COMPAÑÍA   : {c.Name}");
                sb.AppendLine($"   📞 Teléfono   : {c.Phone}");
                sb.AppendLine($"   ✉️ Correo     : {c.Email}");
                sb.AppendLine("--------------------------------------------------------------------------");
            }

            txtReporte.Text = sb.ToString();
            ventanaVisualizar.Controls.Add(txtReporte);
            ventanaVisualizar.ShowDialog();
        }

        // Boton manual para revisar conflictos
        private void btnComprobarIncidencias_Click(object sender, EventArgs e)
        {
            if (data == null || data.GetNumber() == 0) return;

            double d = data.GetDistanciaSeguridad();
            bool hayConflicto = false;
            string detallesIncidencias = "INFORME DE TRAFICO - INCIDENCIAS DETECTADAS:\n\n";

            for (int i = 0; i < data.GetNumber(); i++)
            {
                for (int j = i + 1; j < data.GetNumber(); j++)
                {
                    FlightPlan p1 = data.GetFlightPlan(i); FlightPlan p2 = data.GetFlightPlan(j);
                    if (p1.GetCurrentPosition().GetX() < -1000 || p2.GetCurrentPosition().GetX() < -1000) continue;

                    double dx = p1.GetCurrentPosition().GetX() - p2.GetCurrentPosition().GetX();
                    double dy = p1.GetCurrentPosition().GetY() - p2.GetCurrentPosition().GetY();
                    if (Math.Sqrt(dx * dx + dy * dy) < d)
                    {
                        hayConflicto = true;
                        detallesIncidencias += $"🚨 CONFLICTO ACTUAL: [{p1.GetId()}] y [{p2.GetId()}] violan la separación.\n";
                    }
                    else if (EvaluarConflictoSimulado(p1, p2, d))
                    {
                        hayConflicto = true;
                        detallesIncidencias += $"⚠️ PREVISIÓN: Trayecto de [{p1.GetId()}] y [{p2.GetId()}]" + " provocará colisión.\n";
                    }
                }
            }

            if (hayConflicto) MessageBox.Show(detallesIncidencias, "Reporte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else MessageBox.Show("No se detectan incidencias actuales ni futuras.", "Seguro");
        }

        // Clic en el mapa para ver datos o borrar
        private void PanelSimulacion_MouseClick(object sender, MouseEventArgs e)
        {
            if (data == null || data.GetNumber() == 0) return;

            double maxCoordX = 0; double maxCoordY = 0;
            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan p = data.GetFlightPlan(i);
                if (p.GetInitialPosition().GetX() > maxCoordX) maxCoordX = p.GetInitialPosition().GetX();
                if (p.GetFinalPosition().GetX() > maxCoordX) maxCoordX = p.GetFinalPosition().GetX();
                if (p.GetInitialPosition().GetY() > maxCoordY) maxCoordY = p.GetInitialPosition().GetY();
                if (p.GetFinalPosition().GetY() > maxCoordY) maxCoordY = p.GetFinalPosition().GetY();
            }
            if (maxCoordX == 0) maxCoordX = 1000; if (maxCoordY == 0) maxCoordY = 600;

            float scaleX = (float)(PanelSimulacion.Width / (maxCoordX * 1.2));
            float scaleY = (float)(PanelSimulacion.Height / (maxCoordY * 1.2));

            int mouseX = e.X; int mouseY = e.Y;

            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan a = data.GetFlightPlan(i);
                if (a.GetCurrentPosition().GetX() < -1000 || a.GetVelocidad() <= 0.01) continue;

                float x = (float)a.GetCurrentPosition().GetX() * scaleX;
                float y = (float)a.GetCurrentPosition().GetY() * scaleY;
                int tolerance = 15;

                if (mouseX >= x - tolerance && mouseX <= x + tolerance && mouseY >= y - tolerance && mouseY <= y + tolerance)
                {
                    if (modoBorradoPorClic)
                    {
                        a.SetCurrentPosition(new Position(-9999, -9999)); a.SetVelocidad(0);
                        modoBorradoPorClic = false; historial.Clear(); CargarTabla(); PanelSimulacion.Invalidate();
                        return;
                    }
                    else
                    {
                        Company c = companyDb.BuscarPorPrefijo(a.GetId());

                        MessageBox.Show($"ID: {a.GetId()}\nVelocidad: {a.GetVelocidad()} km/h\nPosición Actual: ({Math.Round(a.GetCurrentPosition().GetX(), 1)}, {Math.Round(a.GetCurrentPosition().GetY(), 1)})\n\nCOMPAÑÍA AÉREA:\nNombre: {c.Name}\nTeléfono: {c.Phone}\nEmail: {c.Email}", "Información de Vuelo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
            }
            if (modoBorradoPorClic) modoBorradoPorClic = false;
        }

        // Crear avion de forma manual
        private void btnAnadirAvionManual_Click(object sender, EventArgs e)
        {
            Form ventanaFormulario = new Form() { Text = "Configurar Nuevo Avión con Operadora", Size = new Size(360, 440), FormBorderStyle = FormBorderStyle.FixedDialog, StartPosition = FormStartPosition.CenterParent };

            Label lblId = new Label() { Text = "ID Avión (ej RYR10):", Location = new Point(20, 20), Width = 120 };
            TextBox txtId = new TextBox() { Location = new Point(160, 17), Width = 140, Text = "RYR_" + (data.GetNumber() + 1) };

            Label lblVel = new Label() { Text = "Velocidad:", Location = new Point(20, 55), Width = 120 };
            TextBox txtVel = new TextBox() { Location = new Point(160, 52), Width = 140, Text = "200" };

            Label lblX0 = new Label() { Text = "X Inicial:", Location = new Point(20, 90), Width = 120 };
            TextBox txtX0 = new TextBox() { Location = new Point(160, 87), Width = 140, Text = "100" };

            Label lblY0 = new Label() { Text = "Y Inicial:", Location = new Point(20, 125), Width = 120 };
            TextBox txtY0 = new TextBox() { Location = new Point(160, 122), Width = 140, Text = "100" };

            Label lblX1 = new Label() { Text = "X Final:", Location = new Point(20, 160), Width = 120 };
            TextBox txtX1 = new TextBox() { Location = new Point(160, 157), Width = 140, Text = "800" };

            Label lblY1 = new Label() { Text = "Y Final:", Location = new Point(20, 195), Width = 120 };
            TextBox txtY1 = new TextBox() { Location = new Point(160, 192), Width = 140, Text = "400" };

            Label lblComp = new Label() { Text = "Nombre Compañía:", Location = new Point(20, 240), Width = 120, Font = new Font("Segoe UI", 9F, FontStyle.Bold) };
            TextBox txtComp = new TextBox() { Location = new Point(160, 237), Width = 140, Text = "Ryanair" };

            Label lblTel = new Label() { Text = "Teléfono Operaciones:", Location = new Point(20, 275), Width = 120 };
            TextBox txtTel = new TextBox() { Location = new Point(160, 272), Width = 140, Text = "+34 918293711" };

            Label lblMail = new Label() { Text = "Email Contacto:", Location = new Point(20, 310), Width = 120 };
            TextBox txtMail = new TextBox() { Location = new Point(160, 307), Width = 140, Text = "ops@ryanair.com" };

            Button btnGuardarVuelo = new Button() { Text = "ACEPTAR Y REGISTRAR", Location = new Point(90, 355), Width = 180, Height = 35, BackColor = Color.LightGreen };

            ventanaFormulario.Controls.AddRange(new Control[] { lblId, txtId, lblVel, txtVel, lblX0, txtX0, lblY0, txtY0, lblX1, txtX1, lblY1, txtY1, lblComp, txtComp, lblTel, txtTel, lblMail, txtMail, btnGuardarVuelo });

            btnGuardarVuelo.Click += (s, ev) => { ventanaFormulario.DialogResult = DialogResult.OK; ventanaFormulario.Close(); };

            if (ventanaFormulario.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    string avionId = txtId.Text.Trim();
                    if (avionId.Length >= 3)
                    {
                        string prefijo = avionId.Substring(0, 3).ToUpper();
                        companyDb.InsertarCompania(new Company(prefijo, txtTel.Text, txtMail.Text));
                    }

                    data.AddFlightPlan(new FlightPlan(avionId, Convert.ToDouble(txtX0.Text), Convert.ToDouble(txtY0.Text), Convert.ToDouble(txtX1.Text), Convert.ToDouble(txtY1.Text), Convert.ToDouble(txtVel.Text)));
                    CargarTabla(); PanelSimulacion.Invalidate();
                }
                catch { MessageBox.Show("Error de formato en los parámetros numéricos."); }
            }
        }

        private void btnBorrarAvion_Click(object sender, EventArgs e)
        {
            modoBorradoPorClic = true;
            MessageBox.Show("Pincha sobre el avión en el mapa para eliminarlo.");
        }

        private void btnMover_Click(object sender, EventArgs e)
        {
            List<Position> estado = new List<Position>();
            for (int i = 0; i < data.GetNumber(); i++) { Position pos = data.GetFlightPlan(i).GetCurrentPosition(); estado.Add(new Position(pos.GetX(), pos.GetY())); }
            historial.Push(estado); data.Mover(data.GetCiclo()); PanelSimulacion.Invalidate();
        }

        private void btndeshacer_Click(object sender, EventArgs e)
        {
            if (historial.Count > 0)
            {
                List<Position> estado = historial.Pop();
                for (int i = 0; i < data.GetNumber(); i++) data.GetFlightPlan(i).SetCurrentPosition(estado[i]);
                PanelSimulacion.Invalidate();
            }
        }

        // Evento del timer para avance continuo
        private void timer1_Tick(object sender, EventArgs e)
        {
            double d = data.GetDistanciaSeguridad();
            bool hayMovimiento = false;
            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan p = data.GetFlightPlan(i); if (p.GetCurrentPosition().GetX() < -1000) continue;
                if (!p.EstaEnDestino()) { p.Mover(data.GetCiclo()); if (p.EstaEnDestino()) p.SetCurrentPosition(p.GetFinalPosition()); hayMovimiento = true; }
            }
            if (hayMovimiento) PanelSimulacion.Invalidate();
            else timer1.Stop();
        }

        private void btnIniciar_Click(object sender, EventArgs e) { timer1.Start(); }
        private void btnDetener_Click(object sender, EventArgs e) { timer1.Stop(); }
        private void btnreiniciar_Click(object sender, EventArgs e) { ReiniciarSimulacion(); }

        private void ReiniciarSimulacion()
        {
            timer1.Stop();
            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan p = data.GetFlightPlan(i);
                if (p.GetVelocidad() > 0) p.SetCurrentPosition(new Position(p.GetInitialPosition().GetX(), p.GetInitialPosition().GetY()));
            }
            PanelSimulacion.Invalidate();
        }

        private void CargarTabla()
        {
            dataGridView1.Rows.Clear();
            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan p = data.GetFlightPlan(i);
                if (p.GetCurrentPosition().GetX() > -1000 && p.GetVelocidad() > 0) dataGridView1.Rows.Add(p.GetId(), p.GetVelocidad());
            }
        }

        // Dibujar elementos en el panel
        private void PanelSimulacion_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (data == null || data.GetNumber() == 0) return;

            double maxCoordX = 0; double maxCoordY = 0;
            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan p = data.GetFlightPlan(i);
                if (p.GetInitialPosition().GetX() > maxCoordX) maxCoordX = p.GetInitialPosition().GetX();
                if (p.GetFinalPosition().GetX() > maxCoordX) maxCoordX = p.GetFinalPosition().GetX();
                if (p.GetInitialPosition().GetY() > maxCoordY) maxCoordY = p.GetInitialPosition().GetY();
                if (p.GetFinalPosition().GetY() > maxCoordY) maxCoordY = p.GetFinalPosition().GetY();
            }

            if (maxCoordX == 0) maxCoordX = 1000; if (maxCoordY == 0) maxCoordY = 600;

            float scaleX = (float)(PanelSimulacion.Width / (maxCoordX * 1.2));
            float scaleY = (float)(PanelSimulacion.Height / (maxCoordY * 1.2));
            double d = data.GetDistanciaSeguridad();

            for (int i = 0; i < data.GetNumber(); i++)
            {
                FlightPlan p = data.GetFlightPlan(i);
                if (p.GetCurrentPosition().GetX() < -1000 || p.GetVelocidad() <= 0.01) continue;

                float x0 = (float)p.GetInitialPosition().GetX() * scaleX;
                float y0 = (float)p.GetInitialPosition().GetY() * scaleY;
                float x1 = (float)p.GetFinalPosition().GetX() * scaleX;
                float y1 = (float)p.GetFinalPosition().GetY() * scaleY;
                float x = (float)p.GetCurrentPosition().GetX() * scaleX;
                float y = (float)p.GetCurrentPosition().GetY() * scaleY;

                float promedioEscala = (scaleX + scaleY) / 2f;
                float radioSeguridad = (float)d * promedioEscala;

                g.DrawLine(Pens.Black, x0, y0, x1, y1);
                g.FillEllipse(Brushes.Blue, x - 5, y - 5, 10, 10);
                g.DrawEllipse(Pens.Green, x - radioSeguridad, y - radioSeguridad, radioSeguridad * 2, radioSeguridad * 2);

                bool enConflicto = false;
                for (int j = 0; j < data.GetNumber(); j++)
                {
                    if (i != j)
                    {
                        FlightPlan otro = data.GetFlightPlan(j);
                        if (otro.GetCurrentPosition().GetX() < -1000 || otro.GetVelocidad() <= 0.01) continue;
                        double dx = p.GetCurrentPosition().GetX() - otro.GetCurrentPosition().GetX();
                        double dy = p.GetCurrentPosition().GetY() - otro.GetCurrentPosition().GetY();
                        if (Math.Sqrt(dx * dx + dy * dy) < d) { enConflicto = true; break; }
                    }
                }
                if (enConflicto) g.DrawEllipse(Pens.Red, x - radioSeguridad, y - radioSeguridad, radioSeguridad * 2, radioSeguridad * 2);
            }
        }

        private void btnEditarParametros_Click(object sender, EventArgs e)
        {
            FormParametros form = new FormParametros();
            form.SetData(this.data);
            if (form.ShowDialog() == DialogResult.OK) { CargarTabla(); PanelSimulacion.Invalidate(); }
        }
    }
}