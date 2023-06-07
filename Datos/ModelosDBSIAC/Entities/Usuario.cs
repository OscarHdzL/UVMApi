using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class Usuario
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public bool Activo { get; set; }

    public int CatNivelRevisionId { get; set; }

    public int TblPerfilId { get; set; }

    public bool? Todos { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual CatNivelRevision CatNivelRevision { get; set; } = null!;

    public virtual TblPerfil TblPerfil { get; set; } = null!;
}
