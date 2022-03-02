using Brive.Bootcamp.Proyecto.API.Web.Scrapping.Models;
using Brive.Bootcamp.Proyecto.API.Web.Scrapping.Repositorio;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using ScrapySharp.Network;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Brive.Bootcamp.Proyecto.API.Web.Scrapping.Service.Implementation
{
    public class ImpConsulta: IConsulta
    {
        private IConsultaRepositorio _consultaRepositorio;

        public ImpConsulta(IConsultaRepositorio consultaRepositorio)
        {
            _consultaRepositorio = consultaRepositorio;
        }

        public bool GuardarConsulta(Consultas consulta)
        {
            if (consulta == null)
                return false;
            _consultaRepositorio.GuardarConsulta(consulta);
            return true;
        }

        public Consultas[] ObtenerConsulta()
        {
            List<Consultas> consultas = new List<Consultas>();



            return consultas.ToArray();
        }

        public string GetConsulta(string empresa) 
        {
            string url = $"https://www.occ.com.mx/empleos/de-{empresa}/";
            HtmlWeb oweb = new HtmlWeb();
            HtmlDocument doc = oweb.Load(url);
            HtmlNode input = doc.DocumentNode.SelectSingleNode("//body/div/div/div/div/div/div/div/div/div/p");
            string sipunt = input.InnerText;

            Consultas consultas = new Consultas();
            consultas.Empresa = empresa;
            consultas.Vacantes = sipunt;

            //GuardarConsulta(consultas);
            
            return sipunt;
        }        
    }
}
