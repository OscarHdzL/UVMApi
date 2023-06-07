using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.ModelosDBSIAC.DTO
{
    public class PerfilDTO
    {
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;

       
        public bool Activo { get; set; }

        public DateTime FechaCreacion { get; set; }

        public string UsuarioCreacion { get; set; } = null!;

        public DateTime? FechaModificacion { get; set; }

        public string? UsuarioModificacion { get; set; }

        public List<PerfilVistaDTO> Vistas { get; set; }
    }

    public class PerfilVistaDTO
    {
        public int Id { get; set; }
        public List<int> TipoAcceso { get; set;}
    }
}
