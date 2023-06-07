using System;
using System.Collections.Generic;

namespace Datos.ModelosDBSIAC.Entities;

public partial class CatTipoAcceso
{
    public string Id { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public DateTime FechaCreacion { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime? FechaModificacion { get; set; }

    public string? UsuarioModificacion { get; set; }

    public virtual ICollection<PerfilVistaTipoAcceso> PerfilVistaTipoAccesos { get; set; } = new List<PerfilVistaTipoAcceso>();
}
