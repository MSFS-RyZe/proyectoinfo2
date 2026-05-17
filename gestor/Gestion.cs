using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestor
{
    public class Gestion
    {
        SQLiteConnection cnx;
        public void Iniciar()
        {
            string dataSource ="Data Source=basededatos.db";
            this.cnx = new SQLiteConnection(dataSource);
            this.cnx.Open();
        }
        public void Cerrar()
        {
            this.cnx.Close();
        }
        public DataTable buscarUsuario(string nombre, string contraseña)
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM usuarios WHERE nombre='" + nombre + "' and contraseña='" + contraseña + "'";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            return dt;
        }
        public DataTable GetUsuarios()
        {
            DataTable dt = new DataTable();
            string sql = "SELECT * FROM usuarios";
            SQLiteDataAdapter adp = new SQLiteDataAdapter(sql, cnx);
            adp.Fill(dt);
            return dt;
        }
        public void InsertarUsuario(string nombre, string contraseña)
        {
            string query = "INSERT INTO usuarios VALUES('" + nombre + "','" + contraseña + "')";
            SQLiteCommand cmd = new SQLiteCommand(query, cnx);
            int rows = cmd.ExecuteNonQuery();
        }
    }
}
