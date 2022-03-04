using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Brive.ProyectoFinal.Api.Models;

namespace Brive.ProyectoFinal.Api.Models
{
    
    [Table("USUARIO_BUSQUEDA")]
    public class UsusarioBusqueda
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("ID_BUSQUEDA")]
        public int FK_BUSQUEDA { get; set; }
        [ForeignKey("EMAIL")]
        public string FK_USUARIO { get; set; }

        public  Usuarios Usuarios { get; set; }
        public Busquedas Busquedas { get; set; }
        
    }
}
