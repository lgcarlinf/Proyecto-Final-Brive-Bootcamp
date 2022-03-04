using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Brive.ProyectoFinal.Api.Context;
using Brive.ProyectoFinal.Api.Models;
using System.Reflection;
using Nancy.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Brive.ProyectoFinal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosBusquedasTablaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosBusquedasTablaController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/UsusarioBusquedas
        
        [HttpPost("Busquedas")]
        
        public async Task<ActionResult<IEnumerable<Busquedas>>> Retorno(UsuarioBusqueda obj)
        {
            var email = obj.Email;
            var x = _context.UsusarioBusquedas.Where(pas => pas.FK_USUARIO.Equals(email)).ToListAsync();
            
            var r = _context.Busquedas.Where(resul => resul.ID_BUSQUEDA.Equals(2)).ToListAsync();
            return await r; 

        }

        //[HttpPost("Busquedas3")]
        //public async Task<ActionResult<IEnumerable<Root>>> Retorno2(UsuarioBusqueda obj)
        //{
        //    var email = obj.Email;
        //    var x = await _context.UsusarioBusquedas.Where(pas => pas.FK_USUARIO.Equals(email)).ToListAsync();
        //    string w = x.ToString();
        //    JArray root = JArray.Parse(w);

        //    List<string> list = new List<string>();
        //    foreach (JObject jObject in root)
        //    {
        //        list.Add($"{(int)jObject["Fk_BUSQUEDAS"]}");
        //    }
        //    Root datos = new Root();
        //    datos.fK_BUSQUEDA = list[0]; 

            //list[1];

        //    //var  myDeserializedClass = JsonConvert.DeserializeObject<List<Root>>(list[0].ToString());

        //    return list;

        //}
        // GET: api/UsuariosBusquedasTabla
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsusarioBusqueda>>> GetUsusarioBusquedas()
        {
            return await _context.UsusarioBusquedas.ToListAsync();
        }

        // GET: api/UsuariosBusquedasTabla/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsusarioBusqueda>> GetUsusarioBusqueda(int id)
        {
            var ususarioBusqueda = await _context.UsusarioBusquedas.FindAsync(id);

            if (ususarioBusqueda == null)
            {
                return NotFound();
            }

            return ususarioBusqueda;
        }

        // PUT: api/UsuariosBusquedasTabla/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsusarioBusqueda(int id, UsusarioBusqueda ususarioBusqueda)
        {
            if (id != ususarioBusqueda.ID)
            {
                return BadRequest();
            }

            _context.Entry(ususarioBusqueda).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsusarioBusquedaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/UsuariosBusquedasTabla
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsusarioBusqueda>> PostUsusarioBusqueda(UsusarioBusqueda ususarioBusqueda)
        {
            _context.UsusarioBusquedas.Add(ususarioBusqueda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsusarioBusqueda", new { id = ususarioBusqueda.ID }, ususarioBusqueda);
        }

        // DELETE: api/UsuariosBusquedasTabla/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsusarioBusqueda(int id)
        {
            var ususarioBusqueda = await _context.UsusarioBusquedas.FindAsync(id);
            if (ususarioBusqueda == null)
            {
                return NotFound();
            }

            _context.UsusarioBusquedas.Remove(ususarioBusqueda);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsusarioBusquedaExists(int id)
        {
            return _context.UsusarioBusquedas.Any(e => e.ID == id);
        }
    }
}
