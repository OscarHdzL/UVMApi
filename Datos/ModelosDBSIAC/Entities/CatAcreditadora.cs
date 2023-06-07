using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

/// <summary>
/// Listado de Acreditadoras
/// </summary>
public partial class CatAcreditadora
{
    public int Id { get; set; }

    /// <summary>
    /// Nombre de la acreditadora.
    /// </summary>
    public string Nombre { get; set; } = null!;

    public bool EsFimpes { get; set; }

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
}
