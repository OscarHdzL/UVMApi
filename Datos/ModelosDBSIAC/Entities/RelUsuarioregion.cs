using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelUsuarioregion
{
    public int UsuarioId { get; set; }

    public int CatRegionId { get; set; }

    public virtual CatRegion CatRegion { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
