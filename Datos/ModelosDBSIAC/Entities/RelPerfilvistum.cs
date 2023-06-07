using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelPerfilvistum
{
    public int Id { get; set; }

    public int PerfilId { get; set; }

    public int VistaId { get; set; }

    public virtual TblPerfil Perfil { get; set; } = null!;

    public virtual ICollection<RelPerfilvistatipoacceso> RelPerfilvistatipoaccesos { get; set; } = new List<RelPerfilvistatipoacceso>();

    public virtual CatVistum Vista { get; set; } = null!;
}
