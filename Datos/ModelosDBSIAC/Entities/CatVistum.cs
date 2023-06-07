using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class CatVistum
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public string Clave { get; set; } = null!;

    public virtual ICollection<PerfilVistum> PerfilVista { get; set; } = new List<PerfilVistum>();

    public virtual ICollection<Perfil> Perfils { get; set; } = new List<Perfil>();
}
