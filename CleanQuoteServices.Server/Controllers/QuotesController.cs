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
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
        {
            return await _context.Quotes.ToListAsync();
        }

        // POST: api/Quotes
        [HttpPost]
        public async Task CreateQuote(Quote quote)
        {
            // New service
            quote.TotalPrice = quote.Location.PricePerSqm * quote.TotalSquareMeters;

            // Additional optional services
            if (quote.BalconyCleaningEnabled = true)
                quote.TotalPrice += 300;
            if (quote.BalconyCleaningEnabled = true)
                quote.TotalPrice += 300;
            if (quote.BalconyCleaningEnabled = true)
                quote.TotalPrice += 300;

            await _context.Quotes.AddAsync(quote);
            await _context.SaveChangesAsync();
        }
    }
}
