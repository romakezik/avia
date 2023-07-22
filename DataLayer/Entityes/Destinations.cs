using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public partial class Destinations
    {
        [Key]
        public int DestinationsID { get; set; }
        public string CityName { get; set; }
        public string IATACode { get; set; }
    }
}
