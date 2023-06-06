using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class Perfil
{
    public int PerfilId { get; set; }

    public string Nombre { get; set; } = null!;

    public string VistaInicial { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }
}
