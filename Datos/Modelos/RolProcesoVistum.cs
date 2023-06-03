using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Listado de Vistas por Rol.
/// </summary>
public partial class RolProcesoVistum
{
    /// <summary>
    /// Identificador único de la relación rol y vista.
    /// </summary>
    public int RolProcesoVistaId { get; set; }

    /// <summary>
    /// Identificador del rol.
    /// </summary>
    public string RolProcesoId { get; set; } = null!;

    public int AcreditadoraProcesoId { get; set; }

    /// <summary>
    /// Identificador de la vista.
    /// </summary>
    public string VistaId { get; set; } = null!;

    public virtual RolProceso RolProceso { get; set; } = null!;

    public virtual ICollection<RolProcesoVistaTipoAcceso> RolProcesoVistaTipoAccesos { get; set; } = new List<RolProcesoVistaTipoAcceso>();

    public virtual Vistum Vista { get; set; } = null!;
}
