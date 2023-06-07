using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelUsuarionivelmodalidad
{
    public int UsuarioId { get; set; }

    public int CatNivelModalidadId { get; set; }

    public virtual CatNivelModalidad CatNivelModalidad { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;
}
