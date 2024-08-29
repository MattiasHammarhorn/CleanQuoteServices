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
            return Ok(await _context.Quotes.ToListAsync());
        }

        // POST: api/Quotes
        [HttpPost]
        public async Task<ActionResult<Quote>> CreateQuote(Quote quote)
        {
            // Price Calculation
            quote.TotalPrice = quote.Location.PricePerSqm * quote.TotalSquareMeters;

            // Additional optional services
            if (quote.WindowCleaningEnabled == true)
                quote.TotalPrice += 300;
            if (quote.BalconyCleaningEnabled == true)
                quote.TotalPrice += 150;
            if (quote.WasteCollectionEnabled == true)
                quote.TotalPrice += 400;

            _context.Quotes.Add(quote);

            if (await _context.SaveChangesAsync() < 0)
                return BadRequest();

            return Ok(quote);
        }
    }
}
