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

    public virtual ICollection<RelPerfilvistum> RelPerfilvista { get; set; } = new List<RelPerfilvistum>();

    public virtual ICollection<TblPerfil> TblPerfils { get; set; } = new List<TblPerfil>();
}
