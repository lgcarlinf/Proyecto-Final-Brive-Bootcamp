using Brive.Bootcamp.Proyecto.API.Web.Scrapping.Models;
using Brive.Bootcamp.Proyecto.API.Web.Scrapping.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Bootcamp.Proyecto.API.Web.Scrapping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WebScrappingController : ControllerBase
    {
        private readonly IConsulta _consulta;
        public WebScrappingController(IConsulta consultas)
        {
            _consulta = consultas;
        }

        [HttpGet]
        public string ObtenerConsulta()
        {
            return _consulta.GetConsulta("https://www.occ.com.mx/empleos/de-liverpool/");
        }

        [HttpPost]
        public string Consulta([FromBody] string empresa)
        {
            return _consulta.GetConsulta(empresa);
        }


        [HttpPost]
        [Route("post2")]
        public bool GuardarConsulta(Consultas consulta)
        {
            return _consulta.GuardarConsulta(consulta);
        }
    }
}
