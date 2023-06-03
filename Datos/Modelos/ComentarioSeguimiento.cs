using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Comentarios de seguimiento sobre un proceso de acreditación.
/// </summary>
public partial class ComentarioSeguimiento
{
    /// <summary>
    /// Identificador único del comentario de seguimiento.
    /// </summary>
    public int ComentarioSeguimientoId { get; set; }

    /// <summary>
    /// Identificador del proceso al que pertenece este comentario.
    /// </summary>
    public int AcreditadoraProcesoId { get; set; }

    /// <summary>
    /// Identificador de la carrera a la que se asocia este comentario.
    /// </summary>
    public string CarreraId { get; set; } = null!;

    public int Orden { get; set; }

    /// <summary>
    /// Titulo del comentario.
    /// </summary>
    public string? Titulo { get; set; }

    /// <summary>
    /// Contenido del comentario. Texto abierto.
    /// </summary>
    public string? Contenido { get; set; }

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

    public virtual Carrera Carrera { get; set; } = null!;
}
