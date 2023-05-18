using System;
using System.Collections.Generic;

namespace ApiEntidades.Models;

public partial class Entidade
{
    public string Id { get; set; } = null!;

    public DateTime? FechaAlta { get; set; }

    public virtual ICollection<Muestra> Muestras { get; set; } = new List<Muestra>();

    public virtual ICollection<ValoresDatosEstatico> ValoresDatosEstaticos { get; set; } = new List<ValoresDatosEstatico>();
}
