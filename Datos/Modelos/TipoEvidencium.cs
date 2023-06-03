using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Catálogo de tipo de evidencias.
/// </summary>
public partial class TipoEvidencium
{
    /// <summary>
    /// Identificador del proceso al que pertenece este tipo de evidencia.
    /// </summary>
    public int AcreditadoraProcesoId { get; set; }

    /// <summary>
    /// Clave única del tipo de evidencia. 
    /// </summary>
    public string TipoEvidenciaId { get; set; } = null!;

    /// <summary>
    /// Nombre del tipo de evidencia.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Región a la que pertenece este tipo de evidencia.
    /// </summary>
    public string RegionId { get; set; } = null!;

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

    public virtual AcreditadoraProceso AcreditadoraProceso { get; set; } = null!;

    public virtual ICollection<Criterio> Criterios { get; set; } = new List<Criterio>();

    public virtual ICollection<Evidencium> Evidencia { get; set; } = new List<Evidencium>();

    public virtual Region Region { get; set; } = null!;
}
