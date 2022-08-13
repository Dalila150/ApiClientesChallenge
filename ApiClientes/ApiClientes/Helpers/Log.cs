using System;
using System.IO;

namespace ApiClientes.Helpers
{
    public class Log
    {
        static string _path = "";
        //private string _salto = "\n";


        //El constructor no existe, para poder hacer Log estatico.

        static string obtenerNombreArchivo()
        {
            string nombre = "";

            nombre = "log_" + DateTime.Now.Day +"_"+DateTime.Now.Month +"_"+DateTime.Now.Year+".txt";

            return nombre;
        }

        static void crearDirectorio()
        {
            //comprobar si el directorio existe
            try
            {
                if (!Directory.Exists(_path))
                {
                    Directory.CreateDirectory(_path);
                }

                
            }
            catch (DirectoryNotFoundException ex)
            {

                throw new Exception(ex.Message);
                
            }
            
        }

        public static void agregarLog(string sLog, string path) //captura la exepcion/ entrada de datos
        {
            _path = path;
            
            crearDirectorio();
            string nombre = obtenerNombreArchivo();
            string cadena = "";

            cadena+=DateTime.Now +"|"+sLog+ Environment.NewLine; //crea un salto de linea en el archivo

            StreamWriter sw = new StreamWriter(path+"/"+nombre, true); //true para no sobreescribir
            sw.Write(cadena);
            sw.Close();

        }
    }
}
