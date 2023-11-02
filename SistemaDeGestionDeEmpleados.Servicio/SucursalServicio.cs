using Microsoft.EntityFrameworkCore;
using SistemaDeGestionDeEmpleados.Data.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaDeGestionDeEmpleados.Servicio;

public interface ISucursalServicio
{
    List<Sucursal> ListarTodas();
    List<Sucursal> ListarSucursalActivas();
}
public class SucursalServicio : ISucursalServicio
{
    private SistemaParcialContext _context;

    public SucursalServicio(SistemaParcialContext context) {
        _context = context;
    }

    public List<Sucursal> ListarSucursalActivas()
    {
        return _context.Sucursals.OrderBy(s => s.Ciudad).Where(s => s.Eliminada == false).ToList();
    }

    public List<Sucursal> ListarTodas()
    {
        return _context.Sucursals.OrderBy(s => s.Ciudad).ToList();
    }
}
