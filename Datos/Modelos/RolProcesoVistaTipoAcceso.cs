using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Asociación entre rol, vista y tipo de acceso.
/// </summary>
public partial class RolProcesoVistaTipoAcceso
{
    public int RolProcesoVistaTipoAccesoId { get; set; }

    public int RolProcesoVistaId { get; set; }

    public string TipoAccesoId { get; set; } = null!;

    public virtual RolProcesoVistum RolProcesoVista { get; set; } = null!;

    public virtual TipoAcceso TipoAcceso { get; set; } = null!;
}
