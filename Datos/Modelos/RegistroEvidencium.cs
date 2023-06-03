using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Tabla donde se generan los registros de evidencia en base los indices.
/// </summary>
public partial class RegistroEvidencium
{
    /// <summary>
    /// Identificador unico del registro de evidencia.
    /// </summary>
    public int RegistroEvidenciaId { get; set; }

    /// <summary>
    /// Identificador del proceso al que pertenece esta evidencia.
    /// </summary>
    public int AcreditadoraProcesoId { get; set; }

    /// <summary>
    /// Identificador de la carrera a la que se asocia esta evidencia. Null significa que no aplica.
    /// </summary>
    public string CarreraId { get; set; } = null!;

    /// <summary>
    /// Identificador del criterio al que se asocia esta evidencia. El criterio también relaciona el capitulo.
    /// </summary>
    public string CriterioId { get; set; } = null!;

    /// <summary>
    /// Número del evidencia dentro del proceso.
    /// </summary>
    public int EvidenciaId { get; set; }

    /// <summary>
    /// Clave de subárea a la cual se asocia este registro de evidencia.
    /// </summary>
    public string SubareaId { get; set; } = null!;

    /// <summary>
    /// Clave de campus a la cual se asocia este registro de evidencia.
    /// </summary>
    public string CampusId { get; set; } = null!;

    /// <summary>
    /// Año asignado a este registro de evidencia.
    /// </summary>
    public int? AnioId { get; set; }

    /// <summary>
    /// Ciclo asignado a este registro de evidencia.
    /// </summary>
    public string? CicloId { get; set; }

    /// <summary>
    /// Indica si la evidencia ya fue registrada y esta lista para ser validada.
    /// </summary>
    public bool? EsCargada { get; set; }

    /// <summary>
    /// Indica si la evidencia fue aceptada y ya solo puede ser editada por el validador.
    /// </summary>
    public bool? EsAceptada { get; set; }

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

    public virtual Campus Campus { get; set; } = null!;

    public virtual Ciclo? Ciclo { get; set; }

    public virtual Criterio Criterio { get; set; } = null!;

    public virtual Evidencium Evidencium { get; set; } = null!;

    public virtual ICollection<RegistroEvidenciaArchivo> RegistroEvidenciaArchivos { get; set; } = new List<RegistroEvidenciaArchivo>();

    public virtual Subarea Subarea { get; set; } = null!;
}
