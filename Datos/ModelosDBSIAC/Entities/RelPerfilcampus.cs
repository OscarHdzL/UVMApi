using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class RelPerfilcampus
{
    public int Id { get; set; }

    public int PerfilId { get; set; }

    public int CatCampusId { get; set; }

    public virtual CatCampus CatCampus { get; set; } = null!;

    public virtual TblPerfil Perfil { get; set; } = null!;
}
