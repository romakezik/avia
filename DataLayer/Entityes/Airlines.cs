using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public partial class Airlines
    {
        [Key]
        public int AirlinesID { get; set; }
        public string Name { get; set; }
        public string IATACode { get; set; }
    }
}
