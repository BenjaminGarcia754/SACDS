using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SACDS.Modelo.EntityFramework;

namespace SACDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonacionUrgenteController : Controller
    {
        public readonly SADCDSDbContext _context;
        public DonacionUrgenteController(SADCDSDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetDonacionesUrgentes")]
        public async Task<ActionResult<IEnumerable<DonacionUrgente>>> GetDonacionesUrgentes()
        {
            try
            {
                List<DonacionUrgente> donacionesUrgentes = _context.DonacionUrgentes.ToList();
                return donacionesUrgentes;
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult);
            }
        }

        [HttpGet]
        [Route("GetDonacionUrgente/{id}")]
        public async Task<ActionResult<DonacionUrgente>> GetDonacionUrgente(int id)
        {
            try
            {
                DonacionUrgente donacionUrgente = _context.DonacionUrgentes.FirstOrDefault(c => c.Id == id);
                if (donacionUrgente == null)
                {
                    return NotFound();
                }
                return donacionUrgente;
            }
            catch (SqlException ex)
            {
                return StatusCode(ex.ErrorCode);
            }
        }

        [HttpPost]
        [Route("AddDonacionUrgente")]
        public async Task<ActionResult<DonacionUrgente>> AddDonacionUrgente(DonacionUrgente donacionUrgente)
        {
            try
            {
                _context.DonacionUrgentes.Add(donacionUrgente);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetDonacionUrgente", new { id = donacionUrgente.Id }, donacionUrgente);
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult);
            }
        }

        [HttpPut]
        [Route("UpdateDonacionUrgente/{id}")]
        public async Task<ActionResult<DonacionUrgente>> UpdateDonacionUrgente(int id, DonacionUrgente donacionUrgente)
        {
            if (id != donacionUrgente.Id)
            {
                return BadRequest();
            }
            _context.Entry(donacionUrgente).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult);
            }
            return NoContent();
        }

        [HttpDelete]
        [Route("DeleteDonacionUrgente/{id}")]
        public async Task<ActionResult<DonacionUrgente>> DeleteDonacionUrgente(int id)
        {
            try
            {
                DonacionUrgente donacionUrgente = _context.DonacionUrgentes.FirstOrDefault(c => c.Id == id);
                if (donacionUrgente == null)
                {
                    return NotFound();
                }
                _context.DonacionUrgentes.Remove(donacionUrgente);
                await _context.SaveChangesAsync();
                return donacionUrgente;
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult);
            }
        }
    }
}
