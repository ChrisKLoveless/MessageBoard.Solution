using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Models
{
    public class Users
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public int UsersId { get; set; }

    }

}