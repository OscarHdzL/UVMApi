using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelUsuarioarearesponsable
{
    public int UsuarioId { get; set; }

    public int CatAreaResponsableId { get; set; }

    public virtual CatAreaResponsable CatAreaResponsable { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
