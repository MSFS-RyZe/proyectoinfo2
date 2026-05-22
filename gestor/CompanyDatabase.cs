using System;
using System.Data;
using System.Data.SQLite;
using System.Collections.Generic;

namespace Gestor
{
    public class CompanyDatabase
    {
        private string cadenaConexion = "Data Source=BaseDatosAeropuerto.db;Version=3;";

        public void Iniciar()
        {
            using (SQLiteConnection con = new SQLiteConnection(cadenaConexion))
            {
                con.Open();
                string sql = "CREATE TABLE IF NOT EXISTS Companias (Nombre TEXT PRIMARY KEY, Telefono TEXT, Email TEXT);";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    cmd.ExecuteNonQuery();
                }
            }
            if (ObtenerTodas().Rows.Count == 0)
            {
                InsertarCompania(new Company("RYR", "+34 918293711", "imediatequeries@ryanair.org"));
                InsertarCompania(new Company("JKK", "+34 934015200", "no-especificado"));
                InsertarCompania(new Company("DLH", "+49 6986799799", "customer.relations@lufthansa.com"));
                InsertarCompania(new Company("QTR", "+34 913754167", "madstation@qatarairways.com.qa"));
            }
        }

        public void InsertarCompania(Company c)
        {
            using (SQLiteConnection con = new SQLiteConnection(cadenaConexion))
            {
                con.Open();
                string sql = "INSERT OR REPLACE INTO Companias (Nombre, Telefono, Email) VALUES (@nom, @tel, @em);";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nom", c.Name.ToUpper());
                    cmd.Parameters.AddWithValue("@tel", c.Phone);
                    cmd.Parameters.AddWithValue("@em", c.Email);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void EliminarCompania(string nombre)
        {
            using (SQLiteConnection con = new SQLiteConnection(cadenaConexion))
            {
                con.Open();
                string sql = "DELETE FROM Companias WHERE Nombre = @nom;";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nom", nombre.ToUpper());
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public DataTable ObtenerTodas()
        {
            DataTable dt = new DataTable();
            using (SQLiteConnection con = new SQLiteConnection(cadenaConexion))
            {
                con.Open();
                string sql = "SELECT * FROM Companias;";
                using (SQLiteDataAdapter da = new SQLiteDataAdapter(sql, con))
                {
                    da.Fill(dt);
                }
            }
            return dt;
        }

        public Company BuscarPorPrefijo(string idAvion)
        {
            if (string.IsNullOrEmpty(idAvion) || idAvion.Length < 3)
                return new Company("No especificado", "No especificado", "No especificado");

            string prefijo = idAvion.Substring(0, 3).ToUpper();

            using (SQLiteConnection con = new SQLiteConnection(cadenaConexion))
            {
                con.Open();
                string sql = "SELECT * FROM Companias WHERE UPPER(Nombre) = @pref LIMIT 1;";
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@pref", prefijo);
                    using (SQLiteDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            return new Company(dr["Nombre"].ToString(), dr["Telefono"].ToString(), dr["Email"].ToString());
                        }
                    }
                }
            }
            // Requisito: Si se añade un vuelo por TXT y no tiene datos previos en la base de datos, pone "No especificado"
            return new Company(prefijo, "No especificado", "No especificado");
        }
    }
}