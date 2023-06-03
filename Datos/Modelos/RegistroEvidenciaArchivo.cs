using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Listado de archivos registrados como evidencia.
/// </summary>
public partial class RegistroEvidenciaArchivo
{
    /// <summary>
    /// Identificador único del archivo registrado.
    /// </summary>
    public int RegistroEvidenciaArchivoId { get; set; }

    /// <summary>
    /// Identificador del registro de evidencia.
    /// </summary>
    public int RegistroEvidenciaId { get; set; }

    /// <summary>
    /// Identificador del proceso al que pertenece este archivo de evidencia.
    /// </summary>
    public int AcreditadoraProcesoId { get; set; }

    /// <summary>
    /// Identificador de la carrera a la que se asocia este archivo de evidencia.
    /// </summary>
    public string CarreraId { get; set; } = null!;

    /// <summary>
    /// Identificador del criterio al que se asocia este archivo de evidencia.
    /// </summary>
    public string CriterioId { get; set; } = null!;

    /// <summary>
    /// Número del evidencia dentro del proceso al que pertence este archivo.
    /// </summary>
    public int EvidenciaId { get; set; }

    /// <summary>
    /// Identificador de la subárea a la que pertence este archivo de evidencia.
    /// </summary>
    public string SubareaId { get; set; } = null!;

    /// <summary>
    /// Identificador del campus al que pertenece este archivo de evidencia.
    /// </summary>
    public string CampusId { get; set; } = null!;

    /// <summary>
    /// Indicador de si el registro es un archivo o una URL.
    /// </summary>
    public bool EsUrl { get; set; }

    /// <summary>
    /// En el caso de archivos, el nombre físico del archivo.
    /// </summary>
    public string? NombreArchivo { get; set; }

    /// <summary>
    /// En el caso de archivos, el mime type del tipo de archivo.
    /// </summary>
    public string? Mime { get; set; }

    /// <summary>
    /// En caso de ser URL, esta es la dirección de la evidencia.
    /// </summary>
    public string? Url { get; set; }

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

    public virtual RegistroEvidencium RegistroEvidencium { get; set; } = null!;
}
