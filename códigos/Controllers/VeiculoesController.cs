using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LocadoraVeiculos.Models;

namespace LocadoraVeiculos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculoesController : ControllerBase
    {
        private readonly LocadoraContext _context;

        public VeiculoesController(LocadoraContext context)
        {
            _context = context;
        }

        // GET: api/Veiculoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Veiculo>>> GetVeiculo()
        {
          if (_context.Veiculo == null)
          {
              return NotFound();
          }
            return await _context.Veiculo.ToListAsync();
        }

        // GET: api/Veiculoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Veiculo>> GetVeiculo(int id)
        {
          if (_context.Veiculo == null)
          {
              return NotFound();
          }
            var veiculo = await _context.Veiculo.FindAsync(id);

            if (veiculo == null)
            {
                return NotFound();
            }

            return veiculo;
        }

        // PUT: api/Veiculoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVeiculo(int id, Veiculo veiculo)
        {
            if (id != veiculo.Id)
            {
                return BadRequest();
            }

            _context.Entry(veiculo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VeiculoExists(id))
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

        // POST: api/Veiculoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Veiculo>> PostVeiculo(Veiculo veiculo)
        {
          //if (_context.Veiculo == null)
          //{
              //return Problem("Entity set 'LocadoraContext.Veiculo'  is null.");
            //}
            //_context.Veiculo.Add(veiculo);
            //await _context.SaveChangesAsync();

            //return CreatedAtAction("GetVeiculo", new { id = veiculo.Id }, veiculo);

            _context.Veiculo.Add(veiculo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(PostVeiculo), new { Id = veiculo.Id }, veiculo);
        }

        // DELETE: api/Veiculoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVeiculo(int id)
        {
            if (_context.Veiculo == null)
            {
                return NotFound();
            }
            var veiculo = await _context.Veiculo.FindAsync(id);
            if (veiculo == null)
            {
                return NotFound();
            }

            _context.Veiculo.Remove(veiculo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VeiculoExists(int id)
        {
            return (_context.Veiculo?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
