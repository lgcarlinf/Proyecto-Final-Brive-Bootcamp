using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Brive.ProyectoFinal.Api.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public string Correo { set; get; }
        public string Nombre { get; set; }
        public string Password { get; set; }
    }
}
