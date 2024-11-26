using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebasAPIBlazor.Context;
using PruebasAPIBlazor.Helpers;
using PruebasAPIBlazor.Models;

namespace PruebasAPIBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        private ConfigurationManager _config { get; set; }

        public UsuariosController(ApplicationDbContext context, ConfigurationManager config)
        {
            _context = context;
            _config = config;
        }

        #region Post

        // POST: api/Usuarios/login
        [HttpPost("login")]
        public async Task<ActionResult<int>> Login(Usuario usuario)
        {
            try
            {
                Usuario objetivo = _context.Usuarios.First(x => x.Contraseña.Equals(PasswordHelpers.Encrypt(usuario.Contraseña, _config.GetSection("Salt").Value)) && x.Email.Equals(usuario.Email));
                return Ok(objetivo.Id);
            }
            catch (Exception ex)
            {
                return BadRequest("Email o contraseña incorrectos");
            }
        }

        // POST: api/Usuarios/postUsuario
        [HttpPost("postUsuario")]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            if (!_context.Usuarios.Any(x => x.Email.Equals(usuario.Email)))
            {
                if (Regex.Match(usuario.Email, ".{1,}@.{1,}\\..{1,}").Success)
                {
                    if (usuario.Contraseña.Length >= 6)
                    {
                        if (usuario.Verificado)
                        {

                            usuario.Contraseña = PasswordHelpers.Encrypt(usuario.Contraseña, _config.GetSection("Salt").Value);
                            _context.Usuarios.Add(usuario);
                            await _context.SaveChangesAsync();

                            return Ok("Usuario creado correctamente");
                        }
                        else
                        {
                            return BadRequest("La cuenta no ha sido todavía verificada");
                        }
                    }
                    else
                    {
                        return BadRequest("La contraseña debe tener 6 o más caracteres");
                    }
                }
                else
                {
                    return BadRequest("Formato de email inválido");
                }
            }
            else
            {
                return BadRequest("Ya existe un usuario con el email indicado");
            }
        }

        #endregion

        #region Gets

        // GET: api/getUsuarios
        [HttpGet("getUsuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return Ok(await _context.Usuarios.ToListAsync());
        }

        // GET: api/Usuarios/getUsuario/5
        [HttpGet("getUsuario/{id}")]
        public async Task<ActionResult<Usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        #endregion

        #region Puts

        // PUT: api/Usuarios/putUsuario/5
        [HttpPut("putUsuario/{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            usuario.Contraseña = PasswordHelpers.Encrypt(usuario.Contraseña, _config.GetSection("Salt").Value);
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Usuario actualizado correctamente");
        }

        #endregion

        #region Deletes

        // DELETE: api/Usuarios/deleteUsuario/5
        [HttpDelete("deleteUsuario/{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return Ok("Usuario eliminado correctamente");
        }

        #endregion

        #region Helpers

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        #endregion

    }
}
