using Microsoft.AspNetCore.Mvc;
using SistemaRefaccionaria.AccesoDatos.Repositorio.IRepositorio;
using SistemaRefaccionaria.Modelos;
using SistemaRefaccionaria.Utilidades;

namespace SistemaRefaccionaria.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartamentoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public DepartamentoController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Departamento departamento = new Departamento();
            if (id == null)
            {
                //creamos un nuevo registro
                departamento.Estado = true;
                return View(departamento);

            }
            departamento = await _unidadTrabajo.Departamento.Obtener(id.GetValueOrDefault());
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                if (departamento.Id == 0)
                {
                    await _unidadTrabajo.Departamento.Agregar(departamento);
                    TempData[DS.Exitosa] = "El departamento se creo con exito";
                }
                else
                {
                    _unidadTrabajo.Departamento.Actualizar(departamento);
                    TempData[DS.Exitosa] = "El departamento se actualizo con exito";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al grabar el departamento";
            return View(departamento);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var departamentoDB = await _unidadTrabajo.Departamento.Obtener(id);
            if (departamentoDB == null)
            {
                return Json(new { success = false, message = "Error al borrar el registro en la Base de datos" });
            }
            _unidadTrabajo.Departamento.Remover(departamentoDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Departamento eliminado con exito" });
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Departamento.ObtenerTodos();
            return Json(new { data = todos });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string descripcion, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Departamento.ObtenerTodos();

            if (id == 0)
            {
                valor = lista.Any(b => b.Descripcion.ToLower().Trim() == descripcion.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Descripcion.ToLower().Trim()
                                    == descripcion.ToLower().Trim()
                                    && b.Id != id);
            }
            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }

        #endregion


    }
}
