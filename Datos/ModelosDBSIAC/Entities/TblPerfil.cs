using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class TblPerfil
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int VistaInicial { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<RelPerfilcampus> RelPerfilcampuses { get; set; } = new List<RelPerfilcampus>();

    public virtual ICollection<RelPerfilvistum> RelPerfilvista { get; set; } = new List<RelPerfilvistum>();

    public virtual CatVistum VistaInicialNavigation { get; set; } = null!;
}
