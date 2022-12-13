using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Messages { get; set; }
    }
}
