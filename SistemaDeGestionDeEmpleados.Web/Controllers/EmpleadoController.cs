using Microsoft.AspNetCore.Mvc;
using SistemaDeGestionDeEmpleados.Data.EF;
using SistemaDeGestionDeEmpleados.Servicio;

namespace SistemaDeGestionDeEmpleados.Web.Controllers
{
    public class EmpleadoController : Controller
    {
        private IEmpleadoServicio _empleadoServicio;
        private ISucursalServicio _sucursalServicio;

        public EmpleadoController(IEmpleadoServicio empleadoServicio, ISucursalServicio sucursalServicio) {
            _empleadoServicio = empleadoServicio;
            _sucursalServicio = sucursalServicio;
        }


        public IActionResult ListarEmpleado(int? idSucursal)
        {

            cargarSucursalPartialTodas();
            if (idSucursal.HasValue) {
                return View(_empleadoServicio.FiltrarEmpleado(idSucursal));
            }
            else
            {
                return View(_empleadoServicio.ListarEmpleado());
            }

            return View(_empleadoServicio.ListarEmpleado());
        }

        public IActionResult Crear()
        {
            cargarSucursalPartialActivas();
            return View(new Empleado());
        }
        [HttpPost]
        public IActionResult Crear(Empleado empleado)
        {
            cargarSucursalPartialActivas();
            _empleadoServicio.Crear(empleado);
            return RedirectToAction("ListarEmpleado");
        }
        public void cargarSucursalPartialActivas()
        {
            ViewBag.Sucursal= _sucursalServicio.ListarSucursalActivas();
        }

        public void cargarSucursalPartialTodas()
        {
            ViewBag.Sucursal = _sucursalServicio.ListarTodas();
        }



    }
}
