using CleanQuoteServices.Server.Data.Entities;

namespace CleanQuoteServices.Server.Helpers
{
    public static class PriceCalculator
    {
        public static decimal CalculateQuotePrice(Quote quote)
        {
            // Price Calculation
            decimal totalPrice = quote.Location.PricePerSqm * quote.TotalSquareMeters;

            // Additional optional services
            if (quote.WindowCleaningEnabled == true)
                quote.TotalPrice += 300;
            if (quote.BalconyCleaningEnabled == true)
                quote.TotalPrice += 150;
            if (quote.WasteCollectionEnabled == true)
                quote.TotalPrice += 400;

            return totalPrice;
        }
    }
}
