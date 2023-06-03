using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Listado de áreas de reponsabilidad.
/// </summary>
public partial class AreaResponsabilidad
{
    /// <summary>
    /// Identificador del proceso al que pertenece esta área.
    /// </summary>
    public int AcreditadoraProcesoId { get; set; }

    /// <summary>
    /// Siglas de la área de responsabilidad dentro del proceso.
    /// </summary>
    public string AreaResponsabilidadId { get; set; } = null!;

    /// <summary>
    /// Nombre del área de responsabilidad.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Identificador del nivel de atención asociado a esta área.
    /// </summary>
    public string NivelAtencionId { get; set; } = null!;

    /// <summary>
    /// Identificador del nivel de organizacional asociado a esta área.
    /// </summary>
    public string NivelOrganizacionalId { get; set; } = null!;

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

    public virtual ICollection<Evidencium> Evidencia { get; set; } = new List<Evidencium>();

    public virtual NivelAtencion NivelAtencion { get; set; } = null!;

    public virtual NivelOrganizacional NivelOrganizacional { get; set; } = null!;
}
