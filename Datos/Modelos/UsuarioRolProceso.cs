using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Asociación entre usuarios y roles por proceso.
/// </summary>
public partial class UsuarioRolProceso
{
    /// <summary>
    /// Identificador del usuario.
    /// </summary>
    public Guid UsuarioId { get; set; }

    /// <summary>
    /// Identificador del proceso de acreditación.
    /// </summary>
    public int AcreditadoraProcesoId { get; set; }

    /// <summary>
    /// Identificador del rol asociado.
    /// </summary>
    public string RolProcesoId { get; set; } = null!;

    public string CarreraId { get; set; } = null!;

    /// <summary>
    /// Fecha de creación del registro.
    /// </summary>
    public DateTime FechaCreacion { get; set; }

    /// <summary>
    /// Usuario que creó el registro.
    /// </summary>
    public string UsuarioCreacion { get; set; } = null!;

    /// <summary>
    /// Fecha de última modificación del registro.
    /// </summary>
    public DateTime? FechaModificacion { get; set; }

    /// <summary>
    /// Usuario que realizó la última modificación del registro.
    /// </summary>
    public string? UsuarioModificacion { get; set; }

    public virtual Carrera Carrera { get; set; } = null!;

    public virtual RolProceso RolProceso { get; set; } = null!;

    public virtual Usuario Usuario { get; set; } = null!;

    public virtual ICollection<UsuarioRolProcesoCapitulo> UsuarioRolProcesoCapitulos { get; set; } = new List<UsuarioRolProcesoCapitulo>();

    public virtual ICollection<UsuarioRolProcesoCriterio> UsuarioRolProcesoCriterios { get; set; } = new List<UsuarioRolProcesoCriterio>();

    public virtual ICollection<Campus> Campuses { get; set; } = new List<Campus>();
}
