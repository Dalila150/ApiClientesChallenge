using System;

namespace ApiClientes.Entidades
{
    public class Cliente
    {

        public int ID { get; set; }

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public DateTime? FechaNac { get; set; }

        public string Cuit { get; set; }

        public string Domicilio { get; set; }

        public string Telefono { get; set; }

        public string Email { get; set; }

    }
}
