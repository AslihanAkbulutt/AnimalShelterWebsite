using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Application
    {
        
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage ="username_required")]
        [DisplayName("Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "animalid_required")]
        [DisplayName("AnimalId")]
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "name_required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "lastname_required")]
        [DisplayName("Lastname")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "adres_required")]
        [DisplayName("Adress")]
        public string Adress { get; set; }

        [Required(ErrorMessage = "phone_required")]
        [DisplayName("PhoneNo")]
        public string PhoneNo { get; set; }

        [Required(ErrorMessage = "explanation_required")]
        [DisplayName("Explanation")]
        public string Explanation { get; set; }
    }
}
