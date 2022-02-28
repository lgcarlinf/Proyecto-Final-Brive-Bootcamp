using Brive.Bootcamp.ProyectoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Bootcamp.ProyectoAPI.Service
{
    public interface IUsuario
    {
        bool GuardarUsuario(Usuarios usuarios);

        Usuarios[] ObtenerUsuario();
    }
}
