using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Catálogo de roles del sistema.
/// </summary>
public partial class Rol
{
    /// <summary>
    /// Identificador único del rol.
    /// </summary>
    public int RolId { get; set; }

    /// <summary>
    /// Nombre del rol.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Descripción del rol.
    /// </summary>
    public string? Descripción { get; set; }

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

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
