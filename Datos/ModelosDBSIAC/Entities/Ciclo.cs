using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class Ciclo
{
    public string Id { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<CatPeriodoEvaluacion> CatPeriodoEvaluacions { get; set; } = new List<CatPeriodoEvaluacion>();
}
