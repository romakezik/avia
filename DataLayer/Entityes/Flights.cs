using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public partial class Flights
    {
        [Key]
        public int FlightsID { get; set; }
        public int AirlineID { get; set; }
        public string FlightNumber { get; set; }
        public DateTime DepartureDate { get; set; }
        public int DepartureCityID { get; set; }
        public int ArrivalCityID { get; set; }

        [ForeignKey(nameof(AirlineID))]
        public virtual Airlines Airline { get; set; }

        [ForeignKey(nameof(DepartureCityID))]
        public virtual Destinations DepartureCity { get; set; }

        [ForeignKey(nameof(ArrivalCityID))]
        public virtual Destinations ArrivalCity { get; set; }
    }
}
