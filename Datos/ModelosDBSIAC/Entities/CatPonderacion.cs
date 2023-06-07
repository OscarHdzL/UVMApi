using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class CatPonderacion
{
    public int ComponenteId { get; set; }

    public int NivelModalidadId { get; set; }

    public int Puntuacion { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual CatComponente Componente { get; set; } = null!;

    public virtual CatNivelModalidad NivelModalidad { get; set; } = null!;
}
