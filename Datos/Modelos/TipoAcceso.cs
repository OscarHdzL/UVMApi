using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Catálogo de tipo de acceso del sistema.
/// </summary>
public partial class TipoAcceso
{
    /// <summary>
    /// Identificador único del tipo de acceso.
    /// </summary>
    public string TipoAccesoId { get; set; } = null!;

    /// <summary>
    /// Nombre del tipo acceso.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Descripción del tipo acceso.
    /// </summary>
    public string Descripcion { get; set; } = null!;

    /// <summary>
    /// Indica si el registro se encuentra activo en el sistema.
    /// </summary>
    public bool Activo { get; set; }

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

    public virtual ICollection<RolProcesoVistaTipoAcceso> RolProcesoVistaTipoAccesos { get; set; } = new List<RolProcesoVistaTipoAcceso>();
}
