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
    public class DepartamentoRepositorio : Repositorio<Departamento>, IDepartamentoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public DepartamentoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Departamento departamento)
        {
            var departamentoBD = _db.Departamentos.FirstOrDefault(b => b.Id == departamento.Id);
            if (departamentoBD != null)
            {
                departamentoBD.Descripcion = departamento.Descripcion;
                departamentoBD.Turno = departamento.Turno;
                departamentoBD.Estado = departamento.Estado;

                _db.SaveChanges();
            }
        }
    }
}
