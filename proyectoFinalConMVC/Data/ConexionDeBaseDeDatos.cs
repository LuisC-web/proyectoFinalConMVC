using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient; //Libreria encargada de la conexion
using MySql.Data;
using System.Data;
using System.Data.SqlClient;
using Org.BouncyCastle.Crypto.Generators;
using proyectoFinalConMVC.servicios;

namespace proyectoFinalConMVC.Data
{
    public class ConexionDeBaseDeDatos
    {
        private static string cadenaMySql = "Server=localhost; Port=3306; Database=proyectoFinal; Uid=root; password=2023";
        public static void Registrar(string correo, string password)
        {


            try
            {
                using (MySqlConnection con = new MySqlConnection(cadenaMySql))
                {
                    con.Open();
                    string query = "insert into usuario(correo,password)";
                    query += " values(@correo,@password)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add("@correo", MySqlDbType.VarChar).Value = correo;
                    cmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = password;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }


            }
            catch
            {
                Console.Write("Error");
            }



        }
        public static string Login(string correo, string password)
        {


            try
            {
                using (MySqlConnection con = new MySqlConnection(cadenaMySql))
                {
                    string queryCorreo = "SELECT correo FROM usuario where correo=@correo", queryPassword = "SELECT password FROM usuario where correo=@correo";
                    con.Open();
                    MySqlCommand solictudCorreo = new MySqlCommand(queryCorreo, con), solictudPassword = new MySqlCommand(queryPassword, con);
                    solictudCorreo.Parameters.Add("@correo", MySqlDbType.VarChar).Value = correo;
                    solictudCorreo.ExecuteNonQuery();
                    if (Convert.ToString(solictudCorreo.Parameters["correo"].Value).Equals(""))
                    {
                        con.Close();
                        return "No existe usuario";
                    }
                    else
                    {
                        solictudPassword.Parameters.Add("@correo", MySqlDbType.VarChar).Value = correo;

                        solictudPassword.ExecuteNonQuery();
                        if (EncriptarDesencriptarClave.descrinptar(password, Convert.ToString(solictudPassword.Parameters["password"].Value)))
                        {
                            con.Close();
                            return "Login";
                        }
                        else
                        {
                            con.Close();
                            return "Constraseña incorrecta";
                        }

                    }
                }


            }
            catch
            {
                return "Se produjo un error";
            }
        }
    }
}