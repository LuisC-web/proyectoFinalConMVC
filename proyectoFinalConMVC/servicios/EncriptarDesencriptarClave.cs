using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoFinalConMVC.servicios
{
    public class EncriptarDesencriptarClave
    {
        public static string encriptar  (string password){
            return BCrypt.Net.BCrypt.HashPassword(password);
} 
        public static bool descrinptar (string password, string passwordHash) {
        
           if(BCrypt.Net.BCrypt.Verify(password,passwordHash))
            {
                return true;
            }

            return false;

        }
    }
}