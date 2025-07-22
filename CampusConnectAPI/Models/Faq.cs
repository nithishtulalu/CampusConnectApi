using System.ComponentModel.DataAnnotations;

namespace CampusConnectAPI.Models
{
    public class Faq
    {
        [Key]
        public Guid FaqId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
