using CleanQuoteServices.Server.Data;
using CleanQuoteServices.Server.Data.Entities;
using CleanQuoteServices.Server.Helpers;
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
            Quote quoteToSave = new Quote();

            quoteToSave.LocationId = quote.Location.LocationId;
            quoteToSave.TotalSquareMeters = quote.TotalSquareMeters;
            quoteToSave.TotalPrice = PriceCalculator.CalculateQuotePrice(quote);
            quoteToSave.BalconyCleaningEnabled = quote.BalconyCleaningEnabled;
            quoteToSave.WindowCleaningEnabled = quote.WindowCleaningEnabled;
            quoteToSave.WasteCollectionEnabled = quote.WasteCollectionEnabled;

            _context.Quotes.Add(quoteToSave);

            if (await _context.SaveChangesAsync() < 0)
                return BadRequest();

            return Ok(quoteToSave);
        }
    }
}
