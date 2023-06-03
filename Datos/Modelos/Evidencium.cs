using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Indice de evidencias por proceso y carrera.
/// </summary>
public partial class Evidencium
{
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

    public string? AreaResponsabilidadId { get; set; }

    public string? TipoEvidenciaId { get; set; }

    public string? SedeId { get; set; }

    public string? NivelOrganizacionalId { get; set; }

    /// <summary>
    /// Descripción larga de la evidencia.
    /// </summary>
    public string Descripcion { get; set; } = null!;

    /// <summary>
    /// Especificaciones para capturar la evidencia.
    /// </summary>
    public string? Especificaciones { get; set; }

    /// <summary>
    /// Fecha compromiso para el registro de las evidencias. Debe ser inferior a la fecha de fin del proceso.
    /// </summary>
    public DateTime FechaCompromiso { get; set; }

    /// <summary>
    /// Identificador del responsable general de estas evidencias.
    /// </summary>
    public Guid Responsable { get; set; }

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

    public virtual AreaResponsabilidad? A { get; set; }

    public virtual AcreditadoraProceso AcreditadoraProceso { get; set; } = null!;

    public virtual Carrera Carrera { get; set; } = null!;

    public virtual Criterio Criterio { get; set; } = null!;

    public virtual ICollection<EvidenciaAnio> EvidenciaAnios { get; set; } = new List<EvidenciaAnio>();

    public virtual NivelOrganizacional? NivelOrganizacional { get; set; }

    public virtual ICollection<RegistroEvidencium> RegistroEvidencia { get; set; } = new List<RegistroEvidencium>();

    public virtual Usuario ResponsableNavigation { get; set; } = null!;

    public virtual Sede? Sede { get; set; }

    public virtual TipoEvidencium? TipoEvidencium { get; set; }

    public virtual ICollection<Campus> Campuses { get; set; } = new List<Campus>();

    public virtual ICollection<Ciclo> Ciclos { get; set; } = new List<Ciclo>();

    public virtual ICollection<Subarea> Subareas { get; set; } = new List<Subarea>();
}
