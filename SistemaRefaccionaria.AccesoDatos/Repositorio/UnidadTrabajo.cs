using SistemaRefaccionaria.AccesoDatos.Repositorio.IRepositorio;
using SistemaRefaccionaria.AccesoDatos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaRefaccionaria.AccesoDatos.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IBodegaRepositorio Bodega { get; set; }

        public ICategoriaRepositorio Categoria { get; set; }

        public IMarcaRepositorio Marca { get; set; }

        public IProductoRepositorio Producto { get; set; }

        public IPuestoRepositorio Puesto { get; set; }

        public IDepartamentoRepositorio Departamento { get; set; }

        public IEmpleadoRepositorio Empleado { get; set; }

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Bodega = new BodegaRepositorio(_db);

            Categoria = new CategoriaRepositorio(_db);

            Marca = new MarcaRepositorio(_db);

            Producto = new ProductoRepositorio(_db);

            Puesto = new PuestoRepositorio(_db);

            Departamento = new DepartamentoRepositorio(_db);

            Empleado = new EmpleadoRepositorio(_db);
        }

        public void Dispose()
        {           
            _db.Dispose();
        }

        public async Task Guardar()
        {
            await _db.SaveChangesAsync();
        }
    }
}
