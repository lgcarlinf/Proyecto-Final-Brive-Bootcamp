﻿using Brive.Bootcamp.ProyectoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Bootcamp.ProyectoAPI.Repositorios
{
    public interface IUsuarioRepo
    {
        void GuardarParticipante(Usuarios usuarios);

        Usuarios[] ObtenerTodosLosParticipantes();
    }
}
