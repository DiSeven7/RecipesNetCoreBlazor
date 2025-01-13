using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Authorization;
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

        private AuthenticationService _authenticationService;

        public UsuariosController(ApplicationDbContext context, ConfigurationManager config, AuthenticationService authenticationService)
        {
            _context = context;
            _config = config;
            _authenticationService = authenticationService;
        }

        #region Post

        [Authorize]
        [HttpPost("login")]
        public async Task<ActionResult<int>> Login(Usuario usuario)
        {
            try
            {
                Usuario objetivo = _context.Usuarios.First(x => x.Contraseña.Equals(_authenticationService.Encrypt(usuario.Contraseña, _config.GetSection("Salt").Value)) && x.Email.Equals(usuario.Email));
                if (objetivo.Verificado)
                {
                    return Ok(objetivo.Id);
                }
                else
                {
                    return BadRequest("Verifique su email antes de iniciar sesión");
                }
            }
            catch (Exception ex)
            {
                return BadRequest("Email o contraseña incorrectos");
            }
        }

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

                            usuario.Contraseña = _authenticationService.Encrypt(usuario.Contraseña, _config.GetSection("Salt").Value);
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

        [HttpPost("token")]
        public IActionResult Token(Usuario usuario)
        {
            Usuario objetivo = null;
            try
            {
                objetivo = _context.Usuarios.First(x => x.Contraseña.Equals(_authenticationService.Encrypt(usuario.Contraseña, _config.GetSection("Salt").Value)) && x.Email.Equals(usuario.Email));
                if (!objetivo.Verificado)
                {
                    objetivo = null;
                }
            }
            catch
            {
                objetivo = null;
            }

            if (objetivo == null)
                return Unauthorized("Credenciales de usuario no válidas o usuario no verificado");

            // Generate JWT token
            var token = _authenticationService.CreateJwtToken(_config, objetivo.Id);

            return Ok(token);
        }
        #endregion

        #region Gets

        [Authorize]
        [HttpGet("getUsuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            return Ok(await _context.Usuarios.ToListAsync());
        }

        [Authorize]
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

        [Authorize]
        [HttpPut("putUsuario/{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            usuario.Contraseña = _authenticationService.Encrypt(usuario.Contraseña, _config.GetSection("Salt").Value);
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

        [Authorize]
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

        #region Funciones

        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

        #endregion

    }
}
