using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Listado de Roles por Proceso.
/// </summary>
public partial class RolProceso
{
    /// <summary>
    /// Identificador del proceso al que pertenece este rol.
    /// </summary>
    public int AcreditadoraProcesoId { get; set; }

    /// <summary>
    /// Identificador del rol para el proceso.
    /// </summary>
    public string RolProcesoId { get; set; } = null!;

    /// <summary>
    /// Nombre del rol.
    /// </summary>
    public string Nombre { get; set; } = null!;

    public string VistaInicial { get; set; } = null!;

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

    public virtual ICollection<RolProcesoVistum> RolProcesoVista { get; set; } = new List<RolProcesoVistum>();

    public virtual ICollection<UsuarioRolProceso> UsuarioRolProcesos { get; set; } = new List<UsuarioRolProceso>();

    public virtual Vistum VistaInicialNavigation { get; set; } = null!;

    public virtual ICollection<Vistum> Vista { get; set; } = new List<Vistum>();
}
