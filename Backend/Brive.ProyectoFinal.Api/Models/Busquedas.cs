using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Brive.ProyectoFinal.Api.Models
{
    [Table("BUSQUEDAS")]
    public class Busquedas
    {
        [Key]
        public int ID_BUSQUEDA { get; set; }
        public string EMPRESA_BUSCADA { get; set; }
        public int RESULTADO_BUSQUEDA { get; set; }
        [DataType(DataType.Date)]
        public DateTime FECHA_BUSQUEDA { get; set; }
    }
}
