using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Relación entre evidencias y años
/// </summary>
public partial class EvidenciaAnio
{
    public int AnioId { get; set; }

    public int EvidenciaId { get; set; }

    public int AcreditadoraProcesoId { get; set; }

    public string CarreraId { get; set; } = null!;

    public string CriterioId { get; set; } = null!;

    public virtual Evidencium Evidencium { get; set; } = null!;
}
