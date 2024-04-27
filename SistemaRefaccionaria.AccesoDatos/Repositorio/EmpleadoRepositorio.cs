using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaRefaccionaria.AccesoDatos.Data;
using SistemaRefaccionaria.AccesoDatos.Repositorio.IRepositorio;
using SistemaRefaccionaria.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRefaccionaria.AccesoDatos.Repositorio
{
    public class EmpleadoRepositorio : Repositorio<Empleado>, IEmpleadoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public EmpleadoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Empleado empleado)
        {
            var empleadoBD = _db.Empleados.FirstOrDefault(b => b.Id == empleado.Id);
            if (empleadoBD != null)
            {
                empleadoBD.APaterno = empleado.APaterno;
                empleadoBD.AMaterno = empleado.AMaterno;
                empleadoBD.Nombre = empleado.Nombre;
                empleadoBD.Direccion = empleado.Direccion;
                empleadoBD.Telefono = empleado.Telefono;
                empleadoBD.PuestoId = empleado.PuestoId;
                empleadoBD.DepartamentoId = empleado.DepartamentoId;
                empleadoBD.Estado = empleado.Estado;

                _db.SaveChanges();
            }
        }

        public IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj)
        {
            if (obj == "Puesto")
            {
                return _db.Puestos.Where(c => c.Estado == true).Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString(),
                });

            }

            if (obj == "Departamento")
            {
                return _db.Departamentos.Where(c => c.Estado == true).Select(c => new SelectListItem
                {
                    Text = c.Descripcion,
                    Value = c.Id.ToString(),
                });

            }
            if (obj == "Empleado")
            {
                return _db.Empleados.Where(c => c.Estado == true).Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                });
            }
            return null;
        }
    }
}
