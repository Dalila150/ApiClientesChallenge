using Microsoft.EntityFrameworkCore;

namespace ApiClientes.Contextos
{
    public class ConexionSql : DbContext
    {

        public ConexionSql(DbContextOptions<ConexionSql> opciones) : base(opciones)
        {
            //dejar al final
        }

    }
}
