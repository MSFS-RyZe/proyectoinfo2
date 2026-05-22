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
            string dataSource = "Data Source=basededatos.db";
            this.cnx = new SQLiteConnection(dataSource);
            this.cnx.Open();

            string sqlCrearTabla = "CREATE TABLE IF NOT EXISTS usuarios (nombre TEXT PRIMARY KEY, contraseña TEXT, telefono TEXT, email TEXT);";
            using (SQLiteCommand cmd = new SQLiteCommand(sqlCrearTabla, this.cnx))
            {
                cmd.ExecuteNonQuery();
            }

            string sqlCheckVacia = "SELECT COUNT(*) FROM usuarios;";
            int numUsuarios = 0;
            using (SQLiteCommand cmdCheck = new SQLiteCommand(sqlCheckVacia, this.cnx))
            {
                numUsuarios = Convert.ToInt32(cmdCheck.ExecuteScalar());
            }

            if (numUsuarios == 0)
            {
                string sqlInsertPrueba = "INSERT INTO usuarios (nombre, contraseña, telefono, email) VALUES ('asd', 'asd', '934016000', 'soporte.eetac@upc.edu');";
                using (SQLiteCommand cmdInsert = new SQLiteCommand(sqlInsertPrueba, this.cnx))
                {
                    cmdInsert.ExecuteNonQuery();
                }
            }
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

        public void InsertarUsuario(string nombre, string contraseña, string telefono = "", string email = "")
        {
            string query = "INSERT INTO usuarios (nombre, contraseña, telefono, email) VALUES ('" + nombre + "', '" + contraseña + "', '" + telefono + "', '" + email + "')";
            SQLiteCommand cmd = new SQLiteCommand(query, cnx);
            int rows = cmd.ExecuteNonQuery();
        }
    }
}