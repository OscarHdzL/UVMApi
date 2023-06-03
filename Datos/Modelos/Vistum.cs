using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Listado de vistas existentes en la plataforma.
/// </summary>
public partial class Vistum
{
    /// <summary>
    /// Identificador interno de la vista.
    /// </summary>
    public string VistaId { get; set; } = null!;

    /// <summary>
    /// Nombre público de la vista.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Fecha en la que fue creado el registro.
    /// </summary>
    public DateTime FechaCreacion { get; set; }

    /// <summary>
    /// Usuario que generó el registro.
    /// </summary>
    public string UsuarioCreacion { get; set; } = null!;

    /// <summary>
    /// Fecha de última modificación del registro.
    /// </summary>
    public DateTime? FechaModificacion { get; set; }

    /// <summary>
    /// Usuario de última modificación del registro.
    /// </summary>
    public string? UsuarioModificacion { get; set; }

    public string Clave { get; set; } = null!;

    public virtual ICollection<RolProcesoVistum> RolProcesoVista { get; set; } = new List<RolProcesoVistum>();

    public virtual ICollection<RolProceso> RolProcesos { get; set; } = new List<RolProceso>();

    public virtual ICollection<RolProceso> RolProcesosNavigation { get; set; } = new List<RolProceso>();
}
