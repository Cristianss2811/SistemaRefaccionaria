using Microsoft.AspNetCore.Mvc;
using SistemaRefaccionaria.AccesoDatos.Repositorio.IRepositorio;
using SistemaRefaccionaria.Modelos;
using SistemaRefaccionaria.Modelos.ViewModels;
using SistemaRefaccionaria.Utilidades;

namespace SistemaRefaccionaria.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class EmpleadoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public EmpleadoController(IUnidadTrabajo unidadTrabajo, IWebHostEnvironment webHostEnvironment)
        {
            _unidadTrabajo = unidadTrabajo;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        //Metodo Upsert GET
        public async Task<IActionResult> Upsert(int? id)
        {
            EmpleadoVM empleadoVM = new EmpleadoVM()
            {
                Empleado = new Empleado(),
                PuestoLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("Puesto"),
                DepartamentoLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("Departamento"),
            };
            if (id == null)
            {
                //Crear un producto Nuevo
                return View(empleadoVM);

            }
            else
            {
                //Actualizar un producto existente
                empleadoVM.Empleado = await _unidadTrabajo.Empleado
                    .Obtener(id.GetValueOrDefault());
                if (empleadoVM.Empleado == null)
                {
                    return NotFound();
                }
                return View(empleadoVM);
            }
        }

        #region API
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Upsert(EmpleadoVM empleadoVM)
        {
            var files = HttpContext.Request.Form.Files;
            string webRootPath = _webHostEnvironment.WebRootPath;
            if (ModelState.IsValid)
            {
                if (empleadoVM.Empleado.Id == 0)
                {
                    //crear un nuevo producto
                    string upload = webRootPath;
                    //crear un id unico en mi sistema 
                    await _unidadTrabajo.Empleado.Agregar(empleadoVM.Empleado);
                }
                else
                {
                    //Actualizar al producto
                    var objEmpleado = await _unidadTrabajo.Empleado.ObtenerPrimero(p => p.Id == empleadoVM.Empleado.Id, isTracking: false);
                    _unidadTrabajo.Empleado.Actualizar(empleadoVM.Empleado);
                }
                TempData[DS.Exitosa] = "Empleado Registrado";
                await _unidadTrabajo.Guardar();
                return View("Index");
            }
            empleadoVM.PuestoLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("Puesto");
            empleadoVM.DepartamentoLista = _unidadTrabajo.Empleado.ObtenerTodosDropDownList("Departamento");
            return View(empleadoVM);

        }



        [HttpGet]
        public async Task<IActionResult> ObtenerTodos()
        {
            var todos = await _unidadTrabajo.Empleado.ObtenerTodos(incluirPropiedades: "Puesto,Departamento");
            return Json(new { data = todos });
        }




        #endregion

        [ActionName("ValidarNombre")]
        public async Task<IActionResult> ValidarNombre(string serie, int id = 0)
        {
            bool valor = false;
            var lista = await _unidadTrabajo.Empleado.ObtenerTodos();

            if (id == 0)
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim() == serie.ToLower().Trim());
            }
            else
            {
                valor = lista.Any(b => b.Nombre.ToLower().Trim()
                                    == serie.ToLower().Trim()
                                    && b.Id != id);
            }
            if (valor)
            {
                return Json(new { data = true });
            }
            return Json(new { data = false });
        }


        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var empleadoDB = await _unidadTrabajo.Empleado.Obtener(id);
            if (empleadoDB == null)
            {
                return Json(new { success = false, message = "Error al borrar el registro en la Base de datos" });
            }
            _unidadTrabajo.Empleado.Remover(empleadoDB);
            await _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Empleado eliminado con exito" });
        }
    }

}
