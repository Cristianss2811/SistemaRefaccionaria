using Microsoft.AspNetCore.Mvc.Rendering;
using SistemaRefaccionaria.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRefaccionaria.AccesoDatos.Repositorio.IRepositorio
{
    public interface IEmpleadoRepositorio : IRepositorio<Empleado>
    {
        void Actualizar(Empleado empleado);

        IEnumerable<SelectListItem> ObtenerTodosDropDownList(string obj);

    }
}
