using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

/// <summary>
/// Listado de cápitulos.
/// </summary>
public partial class CatCapitulo
{
    /// <summary>
    /// Identificador del proceso al que pertenece este cápitulo.
    /// </summary>
    public int AcreditadoraProcesoId { get; set; }

    /// <summary>
    /// Número del cápitulo dentro del proceso.
    /// </summary>
    public string Id { get; set; } = null!;

    /// <summary>
    /// Nombre del cápitulo.
    /// </summary>
    public string Nombre { get; set; } = null!;

    /// <summary>
    /// Descripción larga del cápitulo.
    /// </summary>
    public string Descripcion { get; set; } = null!;

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
}
