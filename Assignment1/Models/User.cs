using System.ComponentModel.DataAnnotations;

namespace Assignment1.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required] public string UserName { get; set; }
        [Required] public string Password { get; set; }
        public string Role { get; set; }
        public int SecurityLevel { get; set; }
    }
}