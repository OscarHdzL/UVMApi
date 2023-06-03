using System;
using System.Collections.Generic;

namespace Datos.Modelos;

/// <summary>
/// Asociación entre usaurio, rol y captíulos.
/// </summary>
public partial class UsuarioRolProcesoCriterio
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
    /// Identificador del criterio
    /// </summary>
    public string CriterioId { get; set; } = null!;

    public virtual Criterio Criterio { get; set; } = null!;

    public virtual UsuarioRolProceso UsuarioRolProceso { get; set; } = null!;
}
