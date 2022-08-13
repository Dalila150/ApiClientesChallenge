using System;
using System.Text.RegularExpressions;

namespace ApiClientes.Helpers
{
    public class Validaciones
    {


        public static bool isNumeric(string campo)
        {
            return Regex.IsMatch(campo, "^[0-9]+$");
        }
        public static bool hayCaracteresEspeciales(string campo)
        {
            string Patron = "[!\"·$%&/()=¿¡?'_:;,|@#€*+]";
            return Regex.IsMatch(campo, Patron);
        }

        public static bool contieneEspaciosIntermedios(string campo)

        {
            if (campo.Contains(" "))
                return true;
            else
                return false;
        }

        public static bool validarId(int campo) //No puede ser menor a 0 ni poseer letras
        {
            bool state = true;

            if(campo <= 0)
            {
                state = false;
            }
            if (!isNumeric(campo.ToString()))
            {
                state = false;
            }


            return state;
        }

        public static bool validarNombre(string campo) //Solo letras
        {
            bool state = true;
            campo = campo.Trim();
            if(campo==null || campo== "")
            {
                state = false;
            }
            if (isNumeric(campo))
            {
                state = false;
            }

            return state;
        }

        public static bool validarApellido(string campo)
        {
            bool state = true;
            campo = campo.Trim();
            if (campo == null || campo == "")
            {
                state = false;
            }
            if (isNumeric(campo))
            {
                state = false;
            }

            return state;
        }

        public static bool validarCuit(string campo) //Solo numeros.
        {
            bool state = true;
            campo = campo.Trim();
            if (campo == null || campo == "")
            {
                state = false;
            }
            if (!isNumeric(campo))
            {
                state = false;
            }
            if (contieneEspaciosIntermedios(campo))
            {
                state = false;
            }

            return state;
        }

        public static bool validarTelefono(string campo) //Solo numeros.
        {
            bool state = true;
            campo = campo.Trim();
            if (campo == null || campo == "")
            {
                state = false;
            }
            if (!isNumeric(campo))
            {
                state = false;
            }
            if (contieneEspaciosIntermedios(campo))
            {
                state = false;
            }

            return state;
        }


        public static bool validarCorreo(string text) //validar @ y no terminar en "."
        {
            
            var correo = text.Trim();
            if (correo == "" || correo == null || correo.Length > 100)
            {
                return false;
            }
            else if (correo.EndsWith("."))
            {
                return false;
            }
            if (contieneEspaciosIntermedios(correo))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(text);
                return addr.Address == correo;
            }
            catch
            {
                return false;
            }
        }

       



    }
}
