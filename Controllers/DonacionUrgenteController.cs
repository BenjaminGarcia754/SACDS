using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SACDS.Modelo.DTO;
using SACDS.Modelo.EntityFramework;

namespace SACDS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonacionUrgenteController : Controller
    {
        public readonly SADCDSDbContext _context;
        public readonly IMapper _mapper;
        public DonacionUrgenteController(SADCDSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetDonacionesUrgentes")]
        public async Task<ActionResult<IEnumerable<DonacionUrgenteDTO>>> GetDonacionesUrgentes()
        {
            try
            {
                List<DonacionUrgente> donacionesUrgentes = await _context.DonacionUrgentes.ToListAsync();
                return _mapper.Map<List<DonacionUrgenteDTO>>(donacionesUrgentes);
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult);
            }
        }

        [HttpGet]
        [Route("GetDonacionUrgente/{id}")]
        public async Task<ActionResult<DonacionUrgenteDTO>> GetDonacionUrgente(int id)
        {
            try
            {
                DonacionUrgente donacionUrgente = await _context.DonacionUrgentes.FirstOrDefaultAsync(c => c.Id == id);
                if (donacionUrgente == null)
                {
                    return NotFound();
                }
                return _mapper.Map<DonacionUrgenteDTO>(donacionUrgente);
            }
            catch (SqlException ex)
            {
                return StatusCode(ex.ErrorCode);
            }
        }

        [HttpPost]
        [Route("AddDonacionUrgente")]
        public async Task<ActionResult<DonacionUrgente>> AddDonacionUrgente(DonacionUrgenteDTO donacionUrgenteDTO)
        {
            try
            {
                DonacionUrgente donacionUrgente = _mapper.Map<DonacionUrgente>(donacionUrgenteDTO);
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
        public async Task<ActionResult<DonacionUrgente>> UpdateDonacionUrgente(int id, DonacionUrgente donacionUrgenteDTO)
        {
            if (id != donacionUrgenteDTO.Id)
            {
                return BadRequest();
            }
            DonacionUrgente donacionUrgente = _mapper.Map<DonacionUrgente>(donacionUrgenteDTO);
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
