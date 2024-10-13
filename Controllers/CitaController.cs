using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SACDS.Modelo.EntityFramework;

namespace SACDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        public readonly SADCDSDbContext _context;
        public CitaController(SADCDSDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("GetCitas")]
        public async Task<ActionResult<IEnumerable<Cita>>> GetCitas()
        {
            try
            {
                List<Cita> citas = _context.Citas.ToList();
                return citas;
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult);
            }
        }

        [HttpGet]
        [Route("GetCita/{id}")]
        public async Task<ActionResult<Cita>> GetCita(int id)
        {
            try
            {
                Cita cita = _context.Citas.FirstOrDefault(c => c.Id == id);
                if (cita == null)
                {
                    return NotFound();
                }
                return cita;
            }
            catch (SqlException ex)
            {
                return StatusCode(ex.ErrorCode);

            }
        }

        [HttpPost]
        [Route("AddCita")]
        public async Task<ActionResult<Cita>> AddCita(Cita cita)
        {
            try
            {
                _context.Citas.Add(cita);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetCita", new { id = cita.Id }, cita);
            }
            catch (SqlException ex)
            {
                return StatusCode(ex.HResult);
            }
        }

        [HttpPut]
        [Route("UpdateCita/{id}")]
        public async Task<ActionResult<Cita>> UpdateCita(int id, Cita cita)
        {
            if (id != cita.Id)
            {
                return BadRequest();
            }
            try
            {
                _context.Entry(cita).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return cita;
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(ex.HResult);
            }
        }

        [HttpDelete]
        [Route("DeleteCita/{id}")]
        public async Task<ActionResult<Cita>> DeleteCita(int id)
        {
            try
            {
                Cita cita = _context.Citas.FirstOrDefault(c => c.Id == id);
                if (cita == null)
                {
                    return NotFound();
                }
                _context.Citas.Remove(cita);
                await _context.SaveChangesAsync();
                return cita;
            }
            catch (SqlException ex)
            {
                return StatusCode(ex.HResult);
            }
        }
    }
}
