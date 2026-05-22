using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Gestor;

namespace FlightSimulator
{ 
    public partial class FormCompanies : Form
    {
        private CompanyDatabase db = new CompanyDatabase();
        private DataGridView grid;
        private TextBox txtNombre, txtTelefono, txtEmail;
        private Button btnAnadir, btnEliminar;

        public FormCompanies()
        {
            this.Text = "Panel de Control de Base de Datos de Compañías";
            this.Size = new Size(650, 450);
            this.StartPosition = FormStartPosition.CenterParent;
            db.Iniciar();
            InitializeComponents();
            CargarGrid();
        }

        private void InitializeComponents()
        {
            grid = new DataGridView() { Location = new Point(15, 15), Size = new Size(600, 220), AllowUserToAddRows = false, ReadOnly = true, SelectionMode = DataGridViewSelectionMode.FullRowSelect };
            this.Controls.Add(grid);

            Label lblNom = new Label() { Text = "Nombre Aerolínea:", Location = new Point(20, 260), Width = 110 };
            txtNombre = new TextBox() { Location = new Point(140, 257), Width = 150 };

            Label lblTel = new Label() { Text = "Teléfono:", Location = new Point(20, 295), Width = 110 };
            txtTelefono = new TextBox() { Location = new Point(140, 292), Width = 150 };

            Label lblEm = new Label() { Text = "Email:", Location = new Point(20, 330), Width = 110 };
            txtEmail = new TextBox() { Location = new Point(140, 327), Width = 150 };

            this.Controls.AddRange(new Control[] { lblNom, txtNombre, lblTel, txtTelefono, lblEm, txtEmail });

            btnAnadir = new Button() { Text = "INSERTAR COMPAÑÍA", Location = new Point(320, 255), Size = new Size(140, 40), BackColor = Color.LightGreen };
            btnAnadir.Click += (s, e) => {
                if (string.IsNullOrEmpty(txtNombre.Text)) return;
                db.InsertarCompania(new Company(txtNombre.Text, txtTelefono.Text, txtEmail.Text));
                CargarGrid();
                txtNombre.Clear(); txtTelefono.Clear(); txtEmail.Clear();
            };

            btnEliminar = new Button() { Text = "ELIMINAR SELECCIONADA", Location = new Point(470, 255), Size = new Size(140, 40), BackColor = Color.LightCoral };
            btnEliminar.Click += (s, e) => {
                if (grid.SelectedRows.Count > 0)
                {
                    string nom = grid.SelectedRows[0].Cells["Nombre"].Value.ToString();
                    db.EliminarCompania(nom);
                    CargarGrid();
                }
            };

            this.Controls.AddRange(new Control[] { btnAnadir, btnEliminar });
        }

        private void CargarGrid()
        {
            grid.DataSource = db.ObtenerTodas();
            if (grid.Columns.Count >= 3)
            {
                grid.Columns[0].Width = 180; grid.Columns[1].Width = 150; grid.Columns[2].Width = 220;
            }
        }
    }
}