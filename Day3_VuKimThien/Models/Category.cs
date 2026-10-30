using System.ComponentModel.DataAnnotations;

namespace Day3_VuKimThien.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100 ,MinimumLength = 3 , ErrorMessage ="phai tu 3 - 100 ki tu")]
        public string Name { get; set; }

        public string Description { get; set; }=string.Empty;
    }
}
