using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SACDS.Modelo.DTO;
using SACDS.Modelo.EntityFramework;

namespace SACDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaController : ControllerBase
    {
        public readonly SADCDSDbContext _context;
        public readonly IMapper _mapper;
        public CitaController(SADCDSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("GetCitas")]
        public async Task<ActionResult<IEnumerable<CitaDTO>>> GetCitas()
        {
            try
            {
                List<Cita> citas = await _context.Citas.ToListAsync();
                return _mapper.Map<List<CitaDTO>>(citas);
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult);
            }
        }

        [HttpGet]
        [Route("GetCita/{id}")]
        public async Task<ActionResult<CitaDTO>> GetCita(int id)
        {
            try
            {
                Cita cita = await _context.Citas.FirstOrDefaultAsync(c => c.Id == id);
                if (cita == null)
                {
                    return NotFound();
                }
                return _mapper.Map<CitaDTO>(cita);
            }
            catch (SqlException ex)
            {
                return StatusCode(ex.ErrorCode);
            }
        }

        [HttpPost]
        [Route("AddCita")]
        public async Task<ActionResult<Cita>> AddCita(CitaDTO citaDTO)
        {
            try
            {
                Cita cita = _mapper.Map<Cita>(citaDTO);
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
        public async Task<ActionResult<Cita>> UpdateCita(int id, CitaDTO citaDTO)
        {
            if (id != citaDTO.Id)
            {
                return BadRequest();
            }
            try
            {
                Cita cita = _mapper.Map<Cita>(citaDTO);
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
