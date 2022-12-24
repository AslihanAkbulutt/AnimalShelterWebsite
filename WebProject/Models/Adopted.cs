using System.ComponentModel;

namespace WebProject.Models
{
    public class Adopted
    {
        public int Id { get; set; }
        [DisplayName("OldId")]
        public int OldId { get; set; }
        [DisplayName("Breed")]
        public string Breed { get; set; }
        [DisplayName("Info")]
        public string Info { get; set; }
        [DisplayName("Age")]
        public int Age { get; set; }
    }
}
