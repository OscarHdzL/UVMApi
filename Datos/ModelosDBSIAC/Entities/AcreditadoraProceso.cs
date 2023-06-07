using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class AcreditadoraProceso
{
    public int Id { get; set; }

    public virtual ICollection<CatCapitulo> CatCapitulos { get; set; } = new List<CatCapitulo>();
}
