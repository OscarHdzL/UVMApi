using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Listado de procesos por acreditadora.
/// </summary>
public partial class AcreditadoraProceso
{
    /// <summary>
    /// Identificador único del proceso.
    /// </summary>
    public int AcreditadoraProcesoId { get; set; }

    /// <summary>
    /// Identificador de la acreditadora a la que perteneces este proceso.
    /// </summary>
    public string AcreditadoraId { get; set; } = null!;

    /// <summary>
    /// Nombre del proceso. Usualmente es un año seguido de un ciclo.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Fecha de inicio del proceso.
    /// </summary>
    public DateTime FechaInicio { get; set; }

    /// <summary>
    /// Fecha de fin del proceso. Limite para generar y documentar evidencias.
    /// </summary>
    public DateTime FechaFin { get; set; }

    /// <summary>
    /// Fecha de creación del registro.
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
    /// Usuario que realizó la última modificación sobre el registro.
    /// </summary>
    public string? UsuarioModificacion { get; set; }

    public virtual Acreditadora Acreditadora { get; set; } = null!;

    public virtual ICollection<AreaResponsabilidad> AreaResponsabilidads { get; set; } = new List<AreaResponsabilidad>();

    public virtual ICollection<Capitulo> Capitulos { get; set; } = new List<Capitulo>();

    public virtual ICollection<ComentarioSeguimiento> ComentarioSeguimientos { get; set; } = new List<ComentarioSeguimiento>();

    public virtual ICollection<Criterio> Criterios { get; set; } = new List<Criterio>();

    public virtual ICollection<Evidencium> Evidencia { get; set; } = new List<Evidencium>();

    public virtual ICollection<RegistroEvidencium> RegistroEvidencia { get; set; } = new List<RegistroEvidencium>();

    public virtual ICollection<RolProceso> RolProcesos { get; set; } = new List<RolProceso>();

    public virtual ICollection<TipoEvidencium> TipoEvidencia { get; set; } = new List<TipoEvidencium>();
}
