using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WattManager.Infrastructure.Persistence;
using WattManager.Domain.Entities;

namespace WattManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CentraleController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CentraleController(AppDbContext context)
        {
            _context = context;
        }

        // POST : api/centrale
        [HttpPost]
        public async Task<ActionResult<Centrale>> CreateCentrale([FromBody] Centrale centrale)
        {
            _context.Centrales.Add(centrale);
            await _context.SaveChangesAsync();
            return Ok(centrale);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Centrale>>> GetCentrales()
        {
            // On récupère toutes les centrales stockées en base
            var centrales = await _context.Centrales.ToListAsync();
            return Ok(centrales);
        }
    }
} 