using MessagePack;
using Microsoft.Build.Framework;

namespace WebProject.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required]
        public string Breed { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Info { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public bool CorD { get; set; }

    }
}
