using Microsoft.AspNetCore.Mvc;
using SistemaRefaccionaria.AccesoDatos.Repositorio.IRepositorio;
using SistemaRefaccionaria.Modelos;
using SistemaRefaccionaria.Utilidades;

namespace SistemaRefaccionaria.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PuestoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;

        public PuestoController(IUnidadTrabajo unidadTrabajo)
        {
            _unidadTrabajo = unidadTrabajo;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Upsert(int? id)
        {
            Puesto puesto = new Puesto();
            if (id == null)
            {
                //creamos un nuevo registro
                puesto.Estado = true;
                return View(puesto);

            }
            puesto = await _unidadTrabajo.Puesto.Obtener(id.GetValueOrDefault());
            if (puesto == null)
            {
                return NotFound();
            }
            return View(puesto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(Puesto puesto)
        {
            if (ModelState.IsValid)
            {
                if (puesto.Id == 0)
                {
                    await _unidadTrabajo.Puesto.Agregar(puesto);
                    TempData[DS.Exitosa] = "El puesto se creo con exito";
                }
                else
                {
                    _unidadTrabajo.Puesto.Actualizar(puesto);
                    TempData[DS.Exitosa] = "El puesto se actualizo con exito";
                }
                await _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            TempData[DS.Error] = "Error al grabar el puesto";
            return View(puesto);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var puestoDB = await _unidadTrabajo.Puesto.Obtener(id);
            if (puestoDB == null)
            {
                return Json(new { success = false, message = "Error al borrar el registro en la Base de datos" });
            }
            _unidadTrabajo.Puesto.Remover(puestoDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Puesto eliminada con exito" });
        }

        #region API
        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Puesto.ObtenerTodos();
            return Json(new { data = todos });
        }

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string nombre, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Puesto.ObtenerTodos();

            if (id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == nombre.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim()
                                    == nombre.ToLower().Trim()
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
