﻿using System;
using System.Collections.Generic;

namespace ApiEntidades.Models;

public partial class ValoresVariablesMuestra
{
    public int Id { get; set; }

    public int? IdNombreVariableMuestra { get; set; }

    public int? IdMuestra { get; set; }

    public string? Valor { get; set; }

    public virtual Muestra? IdMuestraNavigation { get; set; }

    public virtual NombresVariablesMuestra? IdNombreVariableMuestraNavigation { get; set; }
}
