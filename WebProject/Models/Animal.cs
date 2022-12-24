using MessagePack;
using Microsoft.Build.Framework;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace WebProject.Models
{
    public class Animal
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="breed_required")]
        [DisplayName("Breed")]
        public string Breed { get; set; }

        [Required(ErrorMessage = "age_required")]
        [DisplayName("Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "info_required")]
        [DisplayName("Info")]
        public string Info { get; set; }

        [Required(ErrorMessage = "image_required")]
        [DisplayName("Image")]
        public string Image { get; set; }

        
        [DisplayName("CorD")]
        public bool CorD { get; set; }

    }
}
