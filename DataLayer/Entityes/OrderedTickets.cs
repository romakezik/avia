using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{

    public partial class OrderedTickets
    {
        [Key]
        public int OrderedTicketsID { get; set; }
        public int OrderID { get; set; }
        public int TicketID { get; set; }
        public int Quantity { get; set; }

        [ForeignKey(nameof(OrderID))]
        public virtual Orders Order { get; set; }

        [ForeignKey(nameof(TicketID))]
        public virtual Tickets Ticket { get; set; }
    }
}
