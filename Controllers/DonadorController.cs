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
    public class DonadorController : Controller
    {
        public readonly SADCDSDbContext _context;
        public readonly IMapper _mapper;
        public DonadorController(SADCDSDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("GetDonadores")]
        public async Task<ActionResult<IEnumerable<DonadorDTO>>> GetDonadores()
        {
            try
            {
                List<Donador> donadores = _context.donadors.ToList();
                return _mapper.Map<List<DonadorDTO>>(donadores);
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult);
            }
        }

        [HttpGet]
        [Route("GetDonador/{id}")]
        public async Task<ActionResult<DonadorDTO>> GetDonador(int id)
        {
            try
            {
                Donador donador = _context.donadors.FirstOrDefault(d => d.Id == id);
                if (donador == null)
                {
                    return NotFound();
                }
                return _mapper.Map<DonadorDTO>(donador);
            }
            catch (SqlException ex)
            {
                return StatusCode(ex.ErrorCode);
            }
        }

        [HttpPost]
        [Route("AddDonador")]
        public async Task<ActionResult<Donador>> AddDonador(DonadorDTO donadorDTO)
        {
            try
            {
                Donador donador = _mapper.Map<Donador>(donadorDTO);
                _context.donadors.Add(donador);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetDonador", new { id = donador.Id }, donador);
            }
            catch (SqlException ex)
            {
                return StatusCode(ex.ErrorCode);
            }
        }

        [HttpPut]
        [Route("UpdateDonador/{id}")]
        public async Task<ActionResult<Donador>> UpdateDonador(int id, DonadorDTO donadorDTO)
        {
            if (id != donador.Id)
            {
                return BadRequest();
            }
            try
            {
                Donador donador = _mapper.Map<Donador>(donadorDTO);
                _context.Entry(donador).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (SqlException ex)
            {
                return StatusCode(ex.ErrorCode);
            }
        }

        [HttpDelete]
        [Route("DeleteDonador/{id}")]
        public async Task<ActionResult<Donador>> DeleteDonador(int id)
        {
            try
            {
                Donador donador = _context.donadors.FirstOrDefault(d => d.Id == id);
                if (donador == null)
                {
                    return NotFound();
                }
                _context.donadors.Remove(donador);
                await _context.SaveChangesAsync();
                return NoContent();
            }
            catch (SqlException ex)
            {
                return StatusCode(ex.ErrorCode);
            }
        }
    }
}
