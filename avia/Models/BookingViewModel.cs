namespace avia.Models
{
    public class TicketBookingViewModel
    {
        public int TicketID { get; set; }
        public string AirlineName { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
       
    }
}