using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Brive.ProyectoFinal.Api.Context;
using Brive.ProyectoFinal.Api.Models;
using Brive.ProyectoFinal.Api.Controllers;

namespace Brive.ProyectoFinal.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusquedasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public BusquedasController(AppDbContext context)
        {
            _context = context;
        }

       
        // GET: api/Busquedas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Busquedas>>> GetBusquedas()
        {
            return await _context.Busquedas.ToListAsync();
        }

        // GET: api/Busquedas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Busquedas>> GetBusquedas(int id)
        {
            var busquedas = await _context.Busquedas.FindAsync(id);

            if (busquedas == null)
            {
                return NotFound();
            }

            return busquedas;
        }

        // PUT: api/Busquedas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBusquedas(int id, Busquedas busquedas)
        {
            if (id != busquedas.ID_BUSQUEDA)
            {
                return BadRequest();
            }

            _context.Entry(busquedas).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusquedasExists(id))
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

        // POST: api/Busquedas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Busquedas>> PostBusquedas(Busquedas busquedas)
        {
            var nombre = busquedas.EMPRESA_BUSCADA;
            if (TextoVacio(nombre))
            {
                return Ok("Se requiere el nombre de una empresa");
            }
            else
            {
                var resultado = WebScraping.GetConsulta(busquedas.EMPRESA_BUSCADA);
                var arr = resultado.Split(' ');
                var numero = arr[0];


                if (resultado == nombre)
                {
                    return Conflict();
                }
                else
                {
                    busquedas.FECHA_BUSQUEDA = DateTime.Today;
                    busquedas.RESULTADO_BUSQUEDA = Int16.Parse(numero);

                    _context.Busquedas.Add(busquedas);
                    await _context.SaveChangesAsync();

                    return CreatedAtAction("GetBusquedas", new { id = busquedas.ID_BUSQUEDA }, busquedas);

                }
            
            }
        }
        private bool TextoVacio(string texto)
        {
            if (String.IsNullOrWhiteSpace(texto))
            {
                return true;
            }
            return false;
        }

        // DELETE: api/Busquedas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBusquedas(int id)
        {
            var busquedas = await _context.Busquedas.FindAsync(id);
            if (busquedas == null)
            {
                return NotFound();
            }

            _context.Busquedas.Remove(busquedas);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BusquedasExists(int id)
        {
            return _context.Busquedas.Any(e => e.ID_BUSQUEDA == id);
        }

        

        }
    }
