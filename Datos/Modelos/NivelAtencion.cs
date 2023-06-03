using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Catálogo de niveles de atención.
/// </summary>
public partial class NivelAtencion
{
    /// <summary>
    /// Clave única del nivel de atención. 
    /// </summary>
    public string NivelAtencionId { get; set; } = null!;

    /// <summary>
    /// Nombre del nivel de atención.
    /// </summary>
    public string Nombre { get; set; } = null!;

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

    public virtual ICollection<AreaResponsabilidad> AreaResponsabilidads { get; set; } = new List<AreaResponsabilidad>();

    public virtual ICollection<Subarea> Subareas { get; set; } = new List<Subarea>();
}
