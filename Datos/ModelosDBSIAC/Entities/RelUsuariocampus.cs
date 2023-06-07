using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelUsuariocampus
{
    public int UsuarioId { get; set; }

    public int CatCampusId { get; set; }

    public virtual CatCampus CatCampus { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
