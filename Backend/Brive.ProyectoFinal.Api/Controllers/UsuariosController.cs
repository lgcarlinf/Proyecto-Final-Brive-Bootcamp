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
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuarios>>> GetUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Usuarios>> GetUsuarios(string id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios;
        }

        // PUT: api/Usuarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuarios(string id, Usuarios usuarios)
        {
            if (id != usuarios.EMAIL)
            {
                return BadRequest();
            }

            _context.Entry(usuarios).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuariosExists(id))
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

        // POST: api/Usuarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Usuarios>> PostUsuarios(Usuarios usuarios)
        {
            usuarios.PASSWORD = EncriptacionPass.GetMD5(usuarios.PASSWORD);/// cifrado de Pass
            _context.Usuarios.Add(usuarios);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (UsuariosExists(usuarios.EMAIL))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetUsuarios", new { id = usuarios.EMAIL }, usuarios);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuarios(string id)
        {
            var usuarios = await _context.Usuarios.FindAsync(id);
            if (usuarios == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuarios);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuariosExists(string id)
        {
            return _context.Usuarios.Any(e => e.EMAIL == id);
        }

        ///// Metodos Personalnzados para inico de sesion
        
        //[HttpPost]
        [HttpGet("login/{correo}/{password}")]
        public ActionResult<List<Usuarios>> GetInicioSesion(string correo, string password)
        {
            var passDes = EncriptacionPass.GetMD5(password);
            var usuarios = _context.Usuarios.Where(usuario => usuario.EMAIL.Equals(correo) && usuario.PASSWORD.Equals(passDes)).ToList();

            if (usuarios == null)
            {
                return NotFound();
            }

            return usuarios;
        }



        [HttpPost("login")]
        public async Task<ActionResult<Usuarios>> Index(Login objuserlogin)
        {
            objuserlogin.PASSWORD = EncriptacionPass.GetMD5(objuserlogin.PASSWORD);/// cifrado de Pass
            var usuario = _context.Usuarios.Where(m => m.EMAIL == objuserlogin.EMAIL && m.PASSWORD == objuserlogin.PASSWORD).FirstOrDefault();
            
            if (usuario != null)
            {
                return CreatedAtAction("GetUsuarios", new { id = objuserlogin.EMAIL }, usuario); //throw;
            }
            else
            {
                    return Conflict();
            }                    
        }
    }
}
