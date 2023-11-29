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
using Org.BouncyCastle.Asn1.X500;

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
        public  static string Login(string correo, string password)
        {


            try
            {
                using (MySqlConnection con = new MySqlConnection(cadenaMySql))
                {
                    con.Open();
                    string queryCorreo = "SELECT * FROM usuario WHERE correo=@correo", queryPassword = "SELECT password FROM usuario";
                   queryPassword += " where correo = @correo";
                    
                    MySqlCommand solictudCorreo = new MySqlCommand(queryCorreo, con), solictudPassword = new MySqlCommand(queryPassword, con);
                    solictudCorreo.Parameters.AddWithValue("@correo",correo);
                   
                    using (MySqlDataReader resultadoQuery = solictudCorreo.ExecuteReader())
                    {
                        if (resultadoQuery.HasRows)
                        {
                            return "Usuario existe";
                        }
                        else
                        {
                            return "usuario no existe" ;

                        }

                    }

                 
             


                    /*    if(Convert.ToString(solictudCorreo.ExecuteScalar()) == "")
                          {
                              return "No existe el usuario";
                          }
                          solictudPassword.Parameters.Add("@correo", MySqlDbType.VarChar).Value = correo;
                          solictudPassword.ExecuteNonQuery();
                          if ( EncriptarDesencriptarClave.descrinptar(password, Convert.ToString(solictudPassword.ExecuteScalar()))){
                              return "usuario verifado";
                          }
                          else { return "contraseña incorrecta"; }
                         */
                }


            }
            catch
            {
                return "Se produjo un error";
            }
        }
    }
}