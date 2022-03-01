using Brive.Bootcamp.ProyectoAPI.Models;
using Brive.Bootcamp.ProyectoAPI.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Bootcamp.ProyectoAPI.Service.Implementacion
{
    public class ImpUsuario : IUsuario
    {
        private IUsuarioRepo _usuariosRepository;

        public ImpUsuario(IUsuarioRepo usuariosRepositoriy)
        {
            _usuariosRepository = usuariosRepositoriy;
        }

        public bool GuardarUsuario(Usuarios usuarios)
        {
            if (usuarios == null)
                return false;
            _usuariosRepository.GuardarParticipante(usuarios);
            return true;
        }

        public Usuarios[] ObtenerUsuario()
        {
            return GenerarListadodeParticipantes();
        }

        private Usuarios[] GenerarListadodeParticipantes()
        {
            return _usuariosRepository.ObtenerTodosLosParticipantes();
        }
    }
}
