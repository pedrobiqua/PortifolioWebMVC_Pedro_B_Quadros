using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class Portifolio
    {
        public int Id { get; set; }
        public String? Descrition { get; set; }
        public String? Title { get; set; }
        public String? LinkProject { get; set; }
    }
}