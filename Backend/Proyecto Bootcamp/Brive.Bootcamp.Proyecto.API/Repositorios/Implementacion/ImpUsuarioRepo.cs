using Brive.Bootcamp.ProyectoAPI.DataAccess;
using Brive.Bootcamp.ProyectoAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Bootcamp.ProyectoAPI.Repositorios.Implementacion
{
    public class ImpUsuarioRepo : IUsuarioRepo
    {
        private readonly ProjectContext _contextBD;

        public ImpUsuarioRepo(ProjectContext contextDB)
        {
            _contextBD = contextDB;
        }

        public void GuardarParticipante(Usuarios usuarios)
        {
            _contextBD.Usuarios.Add(usuarios);
            _contextBD.SaveChanges();
        }

        public Usuarios[] ObtenerTodosLosParticipantes()
        {
            return _contextBD.Usuarios.ToArray();
        }
    }
}
