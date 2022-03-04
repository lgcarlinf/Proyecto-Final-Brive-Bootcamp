using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.ProyectoFinal.Api.Models
{
    public class Root 
    {
        public int id { get; set; }
        public int fK_BUSQUEDA { get; set; }
        public string fK_USUARIO { get; set; }
    }
}
