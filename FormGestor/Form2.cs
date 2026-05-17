using Gestor;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FlightSimulator;
using System.Security.Cryptography.X509Certificates;

namespace FormGestor
{
    public partial class Form2 : Form
    {
        Gestion g = new Gestion();
        public Form2()
        {
            InitializeComponent();
        }

        private void btnsesion_Click(object sender, EventArgs e)
        {
            string nombre = usuariotxt.Text;
            string pass = contraseñatxt.Text;

            DataTable dt = g.buscarUsuario(nombre, pass);

            if (dt.Rows.Count > 0)
            {
                MainForm form = new MainForm();
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos");
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            g.Iniciar();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            g.Cerrar();
        }
    }
}
