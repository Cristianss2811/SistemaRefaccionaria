using SistemaRefaccionaria.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRefaccionaria.AccesoDatos.Repositorio.IRepositorio
{
    public interface IDepartamentoRepositorio : IRepositorio<Departamento>
    {
        void Actualizar(Departamento departamento);
    }
}
