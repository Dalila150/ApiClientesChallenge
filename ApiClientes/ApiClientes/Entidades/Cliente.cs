using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiClientes.Entidades
{
    [Table("Clientes")]
    public class Cliente
    {
        [Key]
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
