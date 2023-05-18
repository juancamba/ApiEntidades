using System;
using System.Collections.Generic;

namespace ApiEntidades.Models;

public partial class TiposMuestra
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public virtual ICollection<Muestra> Muestras { get; set; } = new List<Muestra>();

    public virtual ICollection<NombresVariablesMuestra> NombresVariablesMuestras { get; set; } = new List<NombresVariablesMuestra>();
}
