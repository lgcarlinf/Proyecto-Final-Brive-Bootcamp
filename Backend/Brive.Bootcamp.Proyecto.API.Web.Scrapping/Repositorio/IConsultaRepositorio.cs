using Brive.Bootcamp.Proyecto.API.Web.Scrapping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Bootcamp.Proyecto.API.Web.Scrapping.Repositorio
{
    public interface IConsultaRepositorio
    {
        void GuardarConsulta(Consultas consultas);

        Consultas[] ObtenerConsulta();

    }
}
