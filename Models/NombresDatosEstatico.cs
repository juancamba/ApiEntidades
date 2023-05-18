using System;
using System.Collections.Generic;

namespace ApiEntidades.Models;

public partial class NombresDatosEstatico
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<ValoresDatosEstatico> ValoresDatosEstaticos { get; set; } = new List<ValoresDatosEstatico>();
}
