using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SACDS.Modelo.EntityFramework;

namespace SACDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDonacionController : ControllerBase
    {
        public readonly SADCDSDbContext _context;
        public TipoDonacionController(SADCDSDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetTipoDonaciones")]
        public async Task<ActionResult<IEnumerable<TipoDonacion>>> GetTipoDonaciones()
        {
            try
            {
                List<TipoDonacion> tipoDonaciones = await _context.tipoDonacions.ToListAsync();
                return tipoDonaciones;
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult);
            }
        }

        [HttpGet]
        [Route("GetTipoDonacion/{id}")]
        public async Task<ActionResult<TipoDonacion>> GetTipoDonacion(int id)
        {
            try
            {
                TipoDonacion tipoDonacion = await _context.tipoDonacions.FirstOrDefaultAsync(c => c.Id == id);
                if (tipoDonacion == null)
                {
                    return NotFound();
                }
                return tipoDonacion;
            }
            catch (SqlException ex)
            {
                return StatusCode(ex.ErrorCode);
            }
        }

        [HttpPost]
        [Route("AddTipoDonacion")]
        public async Task<ActionResult<TipoDonacion>> AddTipoDonacion(TipoDonacion tipoDonacion)
        {
            try
            {
                _context.tipoDonacions.Add(tipoDonacion);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetTipoDonacion", new { id = tipoDonacion.Id }, tipoDonacion);
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult);
            }
        }

        [HttpPut]
        [Route("UpdateTipoDonacion/{id}")]
        public async Task<ActionResult<TipoDonacion>> UpdateTipoDonacion(int id, TipoDonacion tipoDonacion)
        {
            if (id != tipoDonacion.Id)
            {
                return BadRequest();
            }
            try
            {   
                _context.Entry(tipoDonacion).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult);
            }
        }

        [HttpDelete]
        [Route("DeleteTipoDonacion/{id}")]
        public async Task<ActionResult<TipoDonacion>> DeleteTipoDonacion(int id)
        {
            TipoDonacion tipoDonacion = await _context.tipoDonacions.FindAsync(id);
            if (tipoDonacion == null)
            {
                return NotFound();
            }
            _context.tipoDonacions.Remove(tipoDonacion);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
