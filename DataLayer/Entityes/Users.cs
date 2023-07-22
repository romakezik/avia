using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public partial class Users
    {
        [Key]
        public int UsersID { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime RegistrationDate { get; set; }
    }
}
