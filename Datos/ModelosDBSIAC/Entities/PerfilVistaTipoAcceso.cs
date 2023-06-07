using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class PerfilVistaTipoAcceso
{
    public int Id { get; set; }

    public int PerfilVistaId { get; set; }

    public string CatTipoAccesoId { get; set; } = null!;

    public virtual CatTipoAcceso CatTipoAcceso { get; set; } = null!;

    public virtual PerfilVistum PerfilVista { get; set; } = null!;
}
