using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanQuoteServices.Server.Data.Entities
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }
        [ForeignKey("Location")]
        public int LocationId { get; set; }
        public decimal TotalPrice { get; set; }
        public int TotalSquareMeters { get; set; }
        public bool WindowCleaningEnabled { get; set; }
        public bool BalconyCleaningEnabled { get; set; }
        public bool WasteCollectionEnabled { get; set; }

        public Location Location { get; set; }
    }
}
