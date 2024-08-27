using CleanQuoteServices.Server.Data;
using CleanQuoteServices.Server.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CleanQuoteServices.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly CleanQuoteServicesContext _context;

        public QuotesController(CleanQuoteServicesContext context)
        {
            _context = context;
        }

        // GET: api/Quotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Quote>>> GetAllQuotes()
        {
            return await _context.Quotes.ToListAsync();
        }
    }
}
