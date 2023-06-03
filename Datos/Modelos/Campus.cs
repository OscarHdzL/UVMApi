using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Catálogo de campus.
/// </summary>
public partial class Campus
{
    /// <summary>
    /// Clave única del campus. 
    /// </summary>
    public string CampusId { get; set; } = null!;

    /// <summary>
    /// Nombre del campus.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Región a la que pertenece este campus.
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

    public virtual Region Region { get; set; } = null!;

    public virtual ICollection<RegistroEvidencium> RegistroEvidencia { get; set; } = new List<RegistroEvidencium>();

    public virtual ICollection<Evidencium> Evidencia { get; set; } = new List<Evidencium>();

    public virtual ICollection<UsuarioRolProceso> UsuarioRolProcesos { get; set; } = new List<UsuarioRolProceso>();
}
