using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Application
    {
        
        [Required]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        public int AnimalId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string PhoneNo { get; set; }
        [Required]
        public string Explanation { get; set; }
    }
}
