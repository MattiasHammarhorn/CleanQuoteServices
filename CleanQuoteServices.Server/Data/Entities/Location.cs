using System.ComponentModel.DataAnnotations;

namespace CleanQuoteServices.Server.Data.Entities
{
    public class Location
    {
        [Key]
        public int LocationId { get; set; }
        public string LocationName { get; set; }
        public decimal PricePerSqm { get; set; }
        public bool HasWindowCleaning { get; set; }
        public bool HasBalconyCleaning { get; set; }
        public bool HasWasteCollection{ get; set; }
    }
}
