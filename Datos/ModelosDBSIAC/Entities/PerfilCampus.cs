using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class PerfilCampus
{
    public int Id { get; set; }

    public int PerfilId { get; set; }

    public int CatCampusId { get; set; }

    public virtual CatCampus CatCampus { get; set; } = null!;

    public virtual Perfil Perfil { get; set; } = null!;
}
