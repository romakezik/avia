// TicketSearchViewModel.cs
using DataLayer;
namespace avia.Models
{

    public class TicketSearchViewModel
    {
        public List<Airlines> Airlines { get; set; }
        public List<Destinations> Cities { get; set; }
        public int? AirlineID { get; set; }
        public int? DepartureCityID { get; set; }
        public int? ArrivalCityID { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool SortByPrice { get; set; }
    }

    public class TicketSearchResultsViewModel
    {
        public List<TicketViewModel> Tickets { get; set; }
        public string? UserId { get; internal set; }
    }

    public class TicketViewModel
    {
        public int TicketID { get; set; }
        public string AirlineName { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureCity { get; set; }
        public string ArrivalCity { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public bool IsBooked { get; set; }
        public int UserID { get; set; }
        // TicketSearchResultsViewModel.cs
        public class TicketSearchResultsViewModel
        {
            public List<TicketViewModel> Tickets { get; set; }
        }

    }
}