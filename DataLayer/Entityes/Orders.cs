using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer
{
    public partial class Orders
    {
        [Key]
        public int OrdersID { get; set; }
        public int UserID { get; set; }
        public DateTime OrderDate { get; set; }

        [ForeignKey(nameof(UserID))]
        public virtual Users User { get; set; }
        public virtual ICollection<OrderedTickets> OrderedTickets { get; set; } = new HashSet<OrderedTickets>();
    }
}
