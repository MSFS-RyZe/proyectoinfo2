using FlightSimulator;
using Gestor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormGestor
{
    public partial class Form3 : Form
    {
        Gestion g = new Gestion();
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            g.Iniciar();
        }

        private void btnregistrarse_Click(object sender, EventArgs e)
        {
            string nombre = usuariotxt.Text;
            string pass = contraseñatxt.Text;

            g.InsertarUsuario(nombre, pass);
            MessageBox.Show("Usuario creado correctamente");
            this.Close();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            g.Cerrar();
        }
    }
}
