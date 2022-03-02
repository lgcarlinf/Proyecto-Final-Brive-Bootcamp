using Brive.Bootcamp.Proyecto.API.Web.Scrapping.Dataaccess;
using Brive.Bootcamp.Proyecto.API.Web.Scrapping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Bootcamp.Proyecto.API.Web.Scrapping.Repositorio.Implementacion
{
    public class ImpConsultaRepositorio: IConsultaRepositorio
    {
        private readonly ProjectContext _contextBD;

        public ImpConsultaRepositorio(ProjectContext contextDB)
        {
            _contextBD = contextDB;
        }

        public void GuardarConsulta(Consultas consultas)
        {
            _contextBD.Consultas.Add(consultas);
            _contextBD.SaveChanges();
        }

        public Consultas[] ObtenerConsulta()
        {
            return _contextBD.Consultas.ToArray();
        }
    }
}
