using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Apartados del libro electrónico.
/// </summary>
public partial class Apartado
{
    /// <summary>
    /// Identificador único del apartado.
    /// </summary>
    public int ApartadoId { get; set; }

    /// <summary>
    /// Identificador del padre de este apartado. NULL en caso de ser un apartado de primer nivel.
    /// </summary>
    public int? ApartadoPadre { get; set; }

    /// <summary>
    /// Identificador del proceso al que pertenece este apartado.
    /// </summary>
    public int AcreditadoraProcesoId { get; set; }

    /// <summary>
    /// Identificador del criterio al que se asocia este apartado.
    /// </summary>
    public string CriterioId { get; set; } = null!;

    /// <summary>
    /// Identificador de la carrera a la que se asocia este apartado.
    /// </summary>
    public string CarreraId { get; set; } = null!;

    /// <summary>
    /// Titulo del apartado.
    /// </summary>
    public string Titulo { get; set; } = null!;

    /// <summary>
    /// Contenido en HTML del apartado.
    /// </summary>
    public string? Especificaciones { get; set; }

    /// <summary>
    /// Indica el orden de despliegue de los apartados. Se ordenan de menor a mayor, agrupados por niveles herárquicos.
    /// </summary>
    public int Orden { get; set; }

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

    public virtual Apartado? ApartadoPadreNavigation { get; set; }

    public virtual Carrera Carrera { get; set; } = null!;

    public virtual Criterio Criterio { get; set; } = null!;

    public virtual ICollection<Apartado> InverseApartadoPadreNavigation { get; set; } = new List<Apartado>();
}
