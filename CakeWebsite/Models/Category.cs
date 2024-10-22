using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CakeWebsite.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
         [Required]
        public string Name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100, ErrorMessage ="Display Order must be between 1 and 100 only!!")]
        public int Display { get; set; }
        public DateTime CreatedDateTime { get; set; }= DateTime.Now;    

    }
}
