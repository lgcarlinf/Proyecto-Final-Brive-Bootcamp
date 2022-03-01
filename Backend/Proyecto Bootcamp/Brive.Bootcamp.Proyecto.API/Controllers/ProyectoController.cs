using Brive.Bootcamp.ProyectoAPI.Models;
using Brive.Bootcamp.ProyectoAPI.Service;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Bootcamp.ProyectoAPI.Controllers
{
    [EnableCors("PruebaApi")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProyectoController : ControllerBase
    {

        private readonly IUsuario _usuarios;
        public ProyectoController(IUsuario usuarios)
        {
            _usuarios = usuarios;
        }

        [HttpGet]
        
        public Usuarios[] ObtenerParticipantes()
        {
            return _usuarios.ObtenerUsuario();
        }

        [HttpPost]
        [Route("GuardarParticipante")]
        public bool GuardarParticipante(Usuarios usuario)
        {
            return _usuarios.GuardarUsuario(usuario);
        }
    }
}
