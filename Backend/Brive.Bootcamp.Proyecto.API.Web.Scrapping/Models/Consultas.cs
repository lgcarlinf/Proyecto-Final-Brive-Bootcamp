using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Bootcamp.Proyecto.API.Web.Scrapping.Models
{
    [Table("BUSQUEDAS")]

    public class Consultas
    {
        [Key]
        public int IDBUSQUEDA { get; set; }

        [Column("EMPRESABUSCADA")]
        public string Empresa { get; set; }

        [Column("RESULTADOBUSQUEDA")]
        public string Vacantes { get; set; }
    }
}
