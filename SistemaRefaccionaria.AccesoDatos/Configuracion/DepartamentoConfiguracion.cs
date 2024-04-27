using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaRefaccionaria.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRefaccionaria.AccesoDatos.Configuracion
{
    public class DepartamentoConfiguracion
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Descripcion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Turno).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Estado).IsRequired();

        }
    }
}
