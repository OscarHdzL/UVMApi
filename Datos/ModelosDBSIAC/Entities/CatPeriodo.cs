using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class CatPeriodo
{
    public int Id { get; set; }

    public string Etapa { get; set; } = null!;

    public DateTime FechaInicial { get; set; }

    public DateTime FechaFinal { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}
