using System;
using System.Collections.Generic;

namespace ApiEntidades.Models;

public partial class NombresVariablesMuestra
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public int? IdTipoMuestra { get; set; }

    public virtual TiposMuestra? IdTipoMuestraNavigation { get; set; }

    public virtual ICollection<ValoresVariablesMuestra> ValoresVariablesMuestras { get; set; } = new List<ValoresVariablesMuestra>();
}
