using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Catálogo de regiones.
/// </summary>
public partial class Region
{
    /// <summary>
    /// Clave única del región. 
    /// </summary>
    public string RegionId { get; set; } = null!;

    /// <summary>
    /// Nombre del región.
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

    public virtual ICollection<Campus> Campuses { get; set; } = new List<Campus>();

    public virtual ICollection<TipoEvidencium> TipoEvidencia { get; set; } = new List<TipoEvidencium>();
}
