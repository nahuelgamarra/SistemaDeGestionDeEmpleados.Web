using System;
using System.Collections.Generic;

namespace SistemaDeGestionDeEmpleados.Data.EF;

public partial class Sucursal
{
    public int IdSucursal { get; set; }

    public string Ciudad { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public bool Eliminada { get; set; }

    public virtual ICollection<Empleado> Empleados { get; set; } = new List<Empleado>();
}
