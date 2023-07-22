using DataLayer;

namespace avia.Models
{
    public class CartViewModel
    {
        public List<OrderedTickets> OrderedTickets { get; set; }
        public Orders Order { get; set; }
    }

}
