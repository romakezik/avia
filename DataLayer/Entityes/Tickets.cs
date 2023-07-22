using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public partial class Tickets
    {
        [Key]
        public int TicketsID { get; set; }
        public int FlightID { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }

        [ForeignKey(nameof(FlightID))]
        public virtual Flights Flight { get; set; }

    }
}
