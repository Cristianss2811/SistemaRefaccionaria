using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaRefaccionaria.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRefaccionaria.AccesoDatos.Configuracion
{
    public class PuestoConfiguracion
    {
        public void Configure(EntityTypeBuilder<Puesto> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.TipoPuesto).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Salario).IsRequired();
            builder.Property(x => x.Horario).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Estado).IsRequired();

        }
    }
}
