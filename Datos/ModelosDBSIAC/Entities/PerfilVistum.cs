using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class PerfilVistum
{
    public int Id { get; set; }

    public int PerfilId { get; set; }

    public int VistaId { get; set; }

    public virtual Perfil Perfil { get; set; } = null!;

    public virtual ICollection<PerfilVistaTipoAcceso> PerfilVistaTipoAccesos { get; set; } = new List<PerfilVistaTipoAcceso>();

    public virtual CatVistum Vista { get; set; } = null!;
}
