using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

/// <summary>
/// Catálogo de periodo de evaluación.
/// </summary>
public partial class CatPeriodoEvaluacion
{
    public int Id { get; set; }

    public int AnioId { get; set; }

    public string CicloId { get; set; } = null!;

    /// <summary>
    /// Fecha inicial del proceso Meta.
    /// </summary>
    public DateTime FechaInicialMeta { get; set; }

    /// <summary>
    /// Fecha fin del proceso Meta.
    /// </summary>
    public DateTime FechaFinMeta { get; set; }

    /// <summary>
    /// Fecha inicial del proceso Captura de resultados.
    /// </summary>
    public DateTime FechaInicialCapturaResultados { get; set; }

    /// <summary>
    /// Fecha fin del proceso Captura de resultados.
    /// </summary>
    public DateTime FechaFinCapturaResultados { get; set; }

    /// <summary>
    /// Fecha inicial del proceso Carga de evidencias.
    /// </summary>
    public DateTime FechaInicialCargaEvidencia { get; set; }

    /// <summary>
    /// Fecha fin del proceso Carga de evidencias.
    /// </summary>
    public DateTime FechaFinCargaEvidencia { get; set; }

    /// <summary>
    /// Fecha inicial del proceso Autoevaluación.
    /// </summary>
    public DateTime FechaInicialAutoEvaluacion { get; set; }

    /// <summary>
    /// Fecha fin del proceso Autoevaluación.
    /// </summary>
    public DateTime FechaFinAutoEvaluacion { get; set; }

    /// <summary>
    /// Fecha inicial del proceso de Revisión.
    /// </summary>
    public DateTime FechaInicialRevision { get; set; }

    /// <summary>
    /// Fecha fin del proceso de Revisión.
    /// </summary>
    public DateTime FechaFinRevision { get; set; }

    /// <summary>
    /// Fecha inicial del proceso Plan mejora.
    /// </summary>
    public DateTime FechaInicialPlanMejora { get; set; }

    /// <summary>
    /// Fecha fin del proceso Plan mejora.
    /// </summary>
    public DateTime FechaFinPlanMejora { get; set; }

    /// <summary>
    /// Fecha inicial del proceso Auditoría.
    /// </summary>
    public DateTime FechaInicialAuditoria { get; set; }

    /// <summary>
    /// Fecha fin del proceso Auditoría .
    /// </summary>
    public DateTime FechaFinAuditoria { get; set; }

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

    public virtual Ciclo Ciclo { get; set; } = null!;
}
