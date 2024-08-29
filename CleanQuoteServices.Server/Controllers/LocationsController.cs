using CleanQuoteServices.Server.Data;
using CleanQuoteServices.Server.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanQuoteServices.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly CleanQuoteServicesContext _context;

        public LocationsController(CleanQuoteServicesContext context)
        {
            _context = context;
        }

        // GET: api/Locations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetLocation()
        {
            return Ok(await _context.Locations.ToListAsync());
        }
    }
}
