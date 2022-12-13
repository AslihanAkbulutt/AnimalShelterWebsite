namespace WebProject.Models
{
    public class AnimalAdd
    {
        public int Id { get; set; }
        public string Breed { get; set; }
        public int Age { get; set; }
        public IFormFile Image { get; set; }
        public string Info { get; set; }
        public bool CorD { get; set; } //cat:1 dog:0

    }
}
