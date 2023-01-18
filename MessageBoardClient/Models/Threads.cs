using System.ComponentModel.DataAnnotations;

namespace MessageBoard.Models 
{
  public class Threads 
  {
    [Required]
    public string Title { get; set; }
    [Required]
    public int UsersId { get; set; }
    [Required]
    public int ThreadsId { get; set; }
  }
}