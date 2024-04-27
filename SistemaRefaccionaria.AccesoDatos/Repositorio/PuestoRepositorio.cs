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
    public class PuestoRepositorio : Repositorio<Puesto>, IPuestoRepositorio
    {
        private readonly ApplicationDbContext _db;

        public PuestoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Actualizar(Puesto puesto)
        {
            var puestoBD = _db.Puestos.FirstOrDefault(b => b.Id == puesto.Id);
            if (puestoBD != null)
            {
                puestoBD.Nombre = puesto.Nombre;
                puestoBD.TipoPuesto = puesto.TipoPuesto;
                puestoBD.Salario = puesto.Salario;
                puestoBD.Horario = puesto.Horario;
                puestoBD.Estado = puesto.Estado;

                _db.SaveChanges();
            }
        }
    }
}
