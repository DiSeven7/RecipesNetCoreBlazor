using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebasAPIBlazor.Context;
using PruebasAPIBlazor.Models;

namespace PruebasAPIBlazor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecetasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RecetasController(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Post

        [Authorize]
        [HttpPost("postReceta")]
        public async Task<ActionResult<Receta>> PostReceta(Receta receta)
        {
            _context.Recetas.Add(receta);
            await _context.SaveChangesAsync();

            return Ok(_context.Recetas.First(x => x.NombreReceta.Equals(receta.NombreReceta) && x.Descripcion.Equals(receta.Descripcion) && x.Ingredientes.Equals(receta.Ingredientes)));
        }

        #endregion

        #region Gets

        // GET: api/Recetas/getRecetas
        [HttpGet("getRecetas")]
        public async Task<ActionResult<IEnumerable<Receta>>> GetRecetas()
        {
            return Ok(await _context.Recetas.ToListAsync());
        }

        // GET: api/Recetas/getReceta/5
        [HttpGet("getReceta/{id}")]
        public async Task<ActionResult<Receta>> GetReceta(int id)
        {
            var receta = await _context.Recetas.FindAsync(id);

            if (receta == null)
            {
                return NotFound();
            }

            return Ok(receta);
        }

        [HttpGet("getRecetasUsuario/{idAutor}")]
        public async Task<ActionResult<IEnumerable<Receta>>> GetRecetasUsuario(int idAutor)
        {
            if (_context.Recetas.Any(x => x.IdAutor == idAutor))
            {
                return Ok(await _context.Recetas.Where(x => x.IdAutor == idAutor).ToListAsync());
            }
            else
            {
                return NotFound("El usuario indicado no ha subido recetas todavía");
            }

        }

        [HttpGet("getRecetasCategoria/{idCategoria}")]
        public async Task<ActionResult<IEnumerable<Receta>>> GetRecetasCategoria(int idCategoria)
        {
            if (_context.Recetas.Any(x => (int)x.Categoria == idCategoria))
            {
                return Ok(await _context.Recetas.Where(x => (int)x.Categoria == idCategoria).ToListAsync());
            }
            else
            {
                return NotFound("No hay recetas para la categoría indicada");
            }
        }

        [HttpGet("getRecetasDificultad/{idDificultad}")]
        public async Task<ActionResult<IEnumerable<Receta>>> GetRecetasDificultad(int idDificultad)
        {
            if (_context.Recetas.Any(x => (int)x.Dificultad == idDificultad))
            {
                return Ok(await _context.Recetas.Where(x => (int)x.Dificultad == idDificultad).ToListAsync());
            }
            else
            {
                return NotFound("No hay recetas para la dificultad indicada");
            }
        }

        #endregion

        #region Puts

        [Authorize]
        [HttpPut("putReceta/{id}")]
        public async Task<IActionResult> PutReceta(int id, Receta receta)
        {
            if (id != receta.Id)
            {
                return BadRequest();
            }

            _context.Entry(receta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecetaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Receta actualizada correctamente");
        }

        #endregion

        #region Delete

        [Authorize]
        [HttpDelete("deleteReceta/{id}")]
        public async Task<IActionResult> DeleteReceta(int id)
        {
            var receta = await _context.Recetas.FindAsync(id);
            if (receta == null)
            {
                return NotFound();
            }

            _context.Recetas.Remove(receta);
            await _context.SaveChangesAsync();

            return Ok("Receta eliminada correctamente");
        }

        #endregion

        private bool RecetaExists(int id)
        {
            return _context.Recetas.Any(e => e.Id == id);
        }
    }
}
