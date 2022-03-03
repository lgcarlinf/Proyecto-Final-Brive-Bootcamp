using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Brive.ProyectoFinal.Api.Context;
using Brive.ProyectoFinal.Api.Models;
using System.Text.RegularExpressions;
using System.Globalization;

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
            string fecha = usuarios.FECHANACIMIENTO.ToString();
            usuarios.NOMBRE = ArreglarTexto(usuarios.NOMBRE);
            usuarios.APELLIDOS = ArreglarTexto(usuarios.APELLIDOS);

            if (ValidarPass(usuarios.PASSWORD))
            {
                usuarios.PASSWORD = EncriptacionPass.GetMD5(usuarios.PASSWORD);/// cifrado de Pass
            }
            else
            {
                return Ok("Password debe contener minimo 8 caracteres 1 masyuscula, 1 caracter especial ");
            }

            if (TextoVacio(usuarios.NOMBRE) | TextoVacio(usuarios.APELLIDOS) | TextoVacio(usuarios.EMAIL) | TextoVacio(fecha))
            {
                return Ok("Se requieren Todos los campos");
            }
            else
            {
                if (ValidarCorreo(usuarios.EMAIL) & ValidarTexto(usuarios.NOMBRE))// & ValidarTexto(usuarios.APELLIDOS))
                {
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
                else
                {
                    return Ok("correo no Valido");
                }
            }
            //usuarios.PASSWORD = EncriptacionPass.GetMD5(usuarios.PASSWORD);/// cifrado de Pass
            //_context.Usuarios.Add(usuarios);

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateException)
            //{
            //    if (UsuariosExists(usuarios.EMAIL))
            //    {
            //        return Conflict();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            //return CreatedAtAction("GetUsuarios", new { id = usuarios.EMAIL }, usuarios);
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
        private string ArreglarTexto(string texto)
        {
            TextInfo ti = CultureInfo.CurrentCulture.TextInfo;
            texto = ti.ToTitleCase(texto);
            texto = texto.Trim();
            while (texto.Contains("  "))
            {
                texto = texto.Replace("  ", " ");
            }
            return texto;
        }

        private bool TextoVacio(string texto)
        {
            if (String.IsNullOrEmpty(texto))
            {
                return true;
            }
            return false;
        }
        

        private bool ValidarCorreo(string texto)
        {
            string expRegularCorreo = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            Regex r = new Regex(expRegularCorreo);
            if (r.IsMatch(texto))
            {
                return true;
            }
            return false;
        }

        private bool ValidarPass(string texto)
        {
            string expRegularPass = @"^(?=\w*\d)(?=\w*[A-Z])(?=\w*[a-z])\S{8,16}$";
            Regex r = new Regex(expRegularPass);
            if (r.IsMatch(texto))
            {
                return true;
            }
            return false;
        }

        private bool ValidarTexto(string texto)
        {
            string expRegularTextos = @"^[a-zA-Z\\s]+$";
            Regex r = new Regex(expRegularTextos);
            if (r.IsMatch(texto))
            {
                return true;
            }
            return false;
        }
    }
}
