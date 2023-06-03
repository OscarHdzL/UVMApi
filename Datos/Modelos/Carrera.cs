using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Catálogo de carreras.
/// </summary>
public partial class Carrera
{
    /// <summary>
    /// Siglas de identificación única para la carrera.
    /// </summary>
    public string CarreraId { get; set; } = null!;

    /// <summary>
    /// Nombre descriptivo de la carrera.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Plan de la carrera.
    /// </summary>
    public string Plan { get; set; } = null!;

    /// <summary>
    /// Indicador de activo/inactivo para el registro.
    /// </summary>
    public bool Activo { get; set; }

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

    public virtual ICollection<Apartado> Apartados { get; set; } = new List<Apartado>();

    public virtual ICollection<ComentarioSeguimiento> ComentarioSeguimientos { get; set; } = new List<ComentarioSeguimiento>();

    public virtual ICollection<Criterio> Criterios { get; set; } = new List<Criterio>();

    public virtual ICollection<Evidencium> Evidencia { get; set; } = new List<Evidencium>();

    public virtual ICollection<UsuarioRolProceso> UsuarioRolProcesos { get; set; } = new List<UsuarioRolProceso>();
}
