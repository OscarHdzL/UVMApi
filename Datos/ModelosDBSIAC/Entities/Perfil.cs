using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class Perfil
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public int VistaInicial { get; set; }

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<PerfilCampus> PerfilCampuses { get; set; } = new List<PerfilCampus>();

    public virtual ICollection<PerfilVistum> PerfilVista { get; set; } = new List<PerfilVistum>();

    public virtual CatVistum VistaInicialNavigation { get; set; } = null!;
}
