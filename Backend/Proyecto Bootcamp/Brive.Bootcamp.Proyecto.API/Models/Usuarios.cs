using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Bootcamp.ProyectoAPI.Models
{
    [Table("USUARIOS")]
    public class Usuarios
    {
        [Key]
        public string Email { get; set; }

        [Column("NOMBRE")]
        public string Nombre { get; set; }

        [Column("APELLIDOS")]
        public string Apellidos { get; set; }

        [Column("PASSWORD")]
        public string Password { get; set; }

        [Column("FECHANACIMIENTO")]
        public DateTime FechaNacimiento { get; set; }

        

    }
}
