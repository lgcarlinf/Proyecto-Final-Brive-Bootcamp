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

        public Consultas[] ObtenerConsulta()
        {
            List<Consultas> consultas = new List<Consultas>();



            return consultas.ToArray();
        }

        public string GetConsulta(string empresa) 
        {
            string url = $"https://www.occ.com.mx/empleos/de-{empresa}/";
            string sinput;
            HtmlWeb oweb = new HtmlWeb();
            try
            {
                HtmlDocument doc = oweb.Load(url);
                HtmlNode input = doc.DocumentNode.SelectSingleNode("//body/div/div/div/div/div/div/div/div/div/p");
                sinput = input.InnerText;

                Consultas consultas = new Consultas();
                consultas.EMPRESABUSCADA = empresa;
                consultas.RESULTADOBUSQUEDA = sinput;

                _consultaRepositorio.GuardarConsulta(consultas);
            }
            catch (Exception e) 
            {
                sinput = "Busqueda incorrecta";
            }
            

            return sinput;
        }        
    }
}
