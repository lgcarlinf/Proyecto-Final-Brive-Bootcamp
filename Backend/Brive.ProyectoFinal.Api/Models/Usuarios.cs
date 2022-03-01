using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Brive.ProyectoFinal.Api.Models
{
    [Table("Usuarios")]
    public class Usuarios
    {
        [Key]
        public string EMAIL { set; get; }
        public string NOMBRE { get; set; }
        public string APELLIDOS { get; set; }
        public string PASSWORD { get; set; }
        [DataType(DataType.Date)]
        public DateTime FECHANACIMIENTO { get; set; }
    }
}
