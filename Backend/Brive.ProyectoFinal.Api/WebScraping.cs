using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace Brive.ProyectoFinal.Api
{
    public class WebScraping
    {
        public static string GetConsulta(string objEmpresa)
        {
            string url = $"https://www.occ.com.mx/empleos/de-{objEmpresa}/";
            HtmlWeb oweb = new HtmlWeb();
            HtmlDocument doc = oweb.Load(url);
            HtmlNode input = doc.DocumentNode.SelectSingleNode("//body/div/div/div/div/div/div/div/div/div/p");
            string sipunt = input.InnerText;

            return sipunt;
        }
    }
}
