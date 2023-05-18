using System;
using System.Collections.Generic;

namespace ApiEntidades.Models;

public partial class Campo
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Muestra> Muestras { get; set; } = new List<Muestra>();
}
