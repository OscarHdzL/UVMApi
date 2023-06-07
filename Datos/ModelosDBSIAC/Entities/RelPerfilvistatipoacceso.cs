using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelPerfilvistatipoacceso
{
    public int Id { get; set; }

    public int PerfilVistaId { get; set; }

    public int CatTipoAccesoId { get; set; }

    public virtual CatTipoAcceso CatTipoAcceso { get; set; } = null!;

    public virtual RelPerfilvistum PerfilVista { get; set; } = null!;
}
