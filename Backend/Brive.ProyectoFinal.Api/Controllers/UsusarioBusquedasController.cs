using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Brive.ProyectoFinal.Api.Context;
using Brive.ProyectoFinal.Api.Models;

namespace Brive.ProyectoFinal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsusarioBusquedasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsusarioBusquedasController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/UsusarioBusquedas
        //[HttpGet("UsuarioBusquedas")]
        //public Task<ActionResult<IEnumerable<UsusarioBusqueda>>> UsusarioBusquedasAsync(UsusarioBusquedasController obj)
        //{
          
        //    return  _context.UsusarioBusquedas.Where(pas => pas.FK_USUARIO.Equals(obj)).ToListAsync();// && usuario.PASSWORD.Equals(passDes)).ToList();
            
           
        //}
        /// <summary>
        /// ///////////////////////
        // GET: api/UsusarioBusquedas
        [HttpPost("Busquedas")]
        public async Task<ActionResult<IEnumerable<UsusarioBusqueda>>> Retorno(UsuarioBusqueda obj)
        {
            var email = obj.Email;
            return await _context.UsusarioBusquedas.Where(pas => pas.FK_USUARIO.Equals(email)).ToListAsync();// && usuario.PASSWORD.Equals(passDes)).ToList();

        }

        //[HttpPost("BusquedasTabla")]
        //public async Task<ActionResult<IEnumerable<UsusarioBusqueda>>> Retornotabla(UsuarioBusqueda obj)
        //{
        //    var email = obj.Email;

        //    return await _context.Busquedas.Where(pas => pas.FK_USUARIO.Equals(email)).ToListAsync();
        //    //    //return await _context.UsusarioBusquedas.Where(pas => pas.FK_USUARIO.Equals(email)).ToListAsync();// && usuario.PASSWORD.Equals(passDes)).ToList();

        //    //
         //}
        [HttpGet("Busquedas2")]
        public async Task<ActionResult<IEnumerable<UsusarioBusqueda>>> Retorno2()
        {

            var x= _context.UsusarioBusquedas.Where(pas => pas.FK_USUARIO.Equals("ncg@gmail.com")).ToListAsync();

            return await x;

        }

        /// </summary>



        // GET: api/UsusarioBusquedas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsusarioBusqueda>>> GetUsusarioBusquedas()
        {
            //var res = _context.UsusarioBusquedas.Where(pas => pas.FK_USUARIO.Equals("ncg@gmai.com"));
            //var res2 = res.ToListAsync();
            //return await res2;
            return await _context.UsusarioBusquedas.ToListAsync();

        }

        // GET: api/UsusarioBusquedas/5
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

        // PUT: api/UsusarioBusquedas/5
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

        // POST: api/UsusarioBusquedas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsusarioBusqueda>> PostUsusarioBusqueda(UsusarioBusqueda ususarioBusqueda)
        {
            _context.UsusarioBusquedas.Add(ususarioBusqueda);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsusarioBusqueda", new { id = ususarioBusqueda.ID }, ususarioBusqueda);
        }

        // DELETE: api/UsusarioBusquedas/5
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
