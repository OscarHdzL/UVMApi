using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelUsuarioareacorporativa
{
    public int UsuarioId { get; set; }

    public int CatAreaCorporativaId { get; set; }

    public virtual CatAreaCorporativa CatAreaCorporativa { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
