using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Catálogo de ciclos.
/// </summary>
public partial class Ciclo
{
    /// <summary>
    /// Nombre del ciclo.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Clave única del ciclo.
    /// </summary>
    public string CicloId { get; set; } = null!;

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

    public virtual ICollection<RegistroEvidencium> RegistroEvidencia { get; set; } = new List<RegistroEvidencium>();

    public virtual ICollection<Evidencium> Evidencia { get; set; } = new List<Evidencium>();
}
