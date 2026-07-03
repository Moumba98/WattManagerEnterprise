using Microsoft.AspNetCore.Mvc;
using WattManager.Application.Interfaces;
using WattManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace WattManager.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class IngenieurController : ControllerBase
    {
        private readonly IIngenieurService _ingenieurService;

        // On injecte l'INTERFACE du service maintenant !
        public IngenieurController(IIngenieurService ingenieurService)
        {
            _ingenieurService = ingenieurService;
        }

        // POST : api/ingenieur
        [HttpPost]
        public async Task<ActionResult<Ingenieur>> CreateIngenieur([FromBody] Ingenieur ingenieur)
        {
            var result = await _ingenieurService.CreateAsync(ingenieur);
            return Ok(result);
        }

        // GET : api/ingenieur
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingenieur>>> GetIngenieurs()
        {
            var result = await _ingenieurService.GetAllWithCentralesAsync();
            return Ok(result);
        }
    }
}