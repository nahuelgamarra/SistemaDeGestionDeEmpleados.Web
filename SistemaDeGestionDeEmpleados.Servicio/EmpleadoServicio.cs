using Microsoft.EntityFrameworkCore;
using SistemaDeGestionDeEmpleados.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionDeEmpleados.Servicio;

    public interface IEmpleadoServicio
    {
        void Crear(Empleado empleado);
    List<Empleado>? FiltrarEmpleado(int? idSucursal);
    List<Empleado> ListarEmpleado();
    }
    public class EmpleadoServicio : IEmpleadoServicio
    {
        private SistemaParcialContext _context;

        public EmpleadoServicio(SistemaParcialContext context) {


            _context = context;
        }
        public void Crear(Empleado empleado)
        {
           _context.Empleados.Add(empleado);
            _context.SaveChanges();

        }

    public List<Empleado>? FiltrarEmpleado(int? idSucursal)
    {
        return _context.Empleados.Include(e => e.IdSucursalNavigation).
            Where(e => e.IdSucursal == idSucursal).ToList();
    }

    public List<Empleado> ListarEmpleado()
        {
            return _context.Empleados.Include(e => e.IdSucursalNavigation).ToList();
        }
    }

