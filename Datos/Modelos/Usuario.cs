using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Listado de usaurios del sistema.
/// </summary>
public partial class Usuario
{
    /// <summary>
    /// Identificador único del usuario en el directorio activo.
    /// </summary>
    public Guid UsuarioId { get; set; }

    /// <summary>
    /// Nombre(s) del usuario.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Apellido paterno del usaurio.
    /// </summary>
    public string Apellidos { get; set; } = null!;

    /// <summary>
    /// Correo electrónico del usuario.
    /// </summary>
    public string Correo { get; set; } = null!;

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

    public bool? EsAvisoAceptado { get; set; }

    public virtual ICollection<Evidencium> Evidencia { get; set; } = new List<Evidencium>();

    public virtual ICollection<UsuarioRolProceso> UsuarioRolProcesos { get; set; } = new List<UsuarioRolProceso>();

    public virtual ICollection<Rol> Rols { get; set; } = new List<Rol>();
}
