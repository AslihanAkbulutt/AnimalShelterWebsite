using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebProject.Models
{
    public class Message
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name_Required")]
        [DisplayName("Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mail_Required")]
        [DisplayName("Mail")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Message_Required")]
        [DisplayName("Message")]
        public string Messages { get; set; }
    }
}
