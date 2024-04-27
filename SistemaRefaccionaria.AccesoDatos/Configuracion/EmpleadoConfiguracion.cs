using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaRefaccionaria.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRefaccionaria.AccesoDatos.Configuracion
{
    public class EmpleadoConfiguracion : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.APaterno).IsRequired().HasMaxLength(60);
            builder.Property(x => x.AMaterno).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Nombre).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Direccion).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Telefono).IsRequired().HasMaxLength(15);
            builder.Property(x => x.Estado).IsRequired();
            builder.Property(x => x.PuestoId).IsRequired();
            builder.Property(x => x.DepartamentoId).IsRequired();

            //Hagamos las relaciones en Fluent API

            builder.HasOne(x => x.Puesto).WithMany()
                .HasForeignKey(x => x.PuestoId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Departamento).WithMany()
                .HasForeignKey(x => x.DepartamentoId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }

}
