using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Catálogo de subareas.
/// </summary>
public partial class Subarea
{
    /// <summary>
    /// Clave única de la subarea. 
    /// </summary>
    public string SubareaId { get; set; } = null!;

    /// <summary>
    /// Nombre de la subarea.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Indica si el registro se encuentra activo en el sistema.
    /// </summary>
    public bool Activo { get; set; }

    /// <summary>
    /// Nivel organizacional al que pertence esta subarea.
    /// </summary>
    public string NivelOrganizacionalId { get; set; } = null!;

    /// <summary>
    /// Nivel de atención al que pertence esta subarea.
    /// </summary>
    public string NivelAtencionId { get; set; } = null!;

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

    public virtual NivelAtencion NivelAtencion { get; set; } = null!;

    public virtual NivelOrganizacional NivelOrganizacional { get; set; } = null!;

    public virtual ICollection<RegistroEvidencium> RegistroEvidencia { get; set; } = new List<RegistroEvidencium>();

    public virtual ICollection<Evidencium> Evidencia { get; set; } = new List<Evidencium>();
}
