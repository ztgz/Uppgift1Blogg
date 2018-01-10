using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Uppgift1Blogg.Models
{
    public partial class BlogPost
    {
        public int Id { get; set; }

        [DisplayName("Rubrik")]
        [Required(ErrorMessage = "Rubrik är obligatorisk")]
        [StringLength(50, ErrorMessage = "Rubrik kan inte vara längre än 50 tecken")]
        public string Header { get; set; }

        [DisplayName("Innehåll")]
        [Required(ErrorMessage = "Innehåll är obligatoriskt")]
        [StringLength(2000, ErrorMessage = "Innehåll kan inte vara längre än 2000 tecken")]
        public string Content { get; set; }

        public DateTime Date { get; set; }

        [DisplayName("Kategori")]
        [Required]
        public int? CategoryId { get; set; }

        public Category Category { get; set; }

    }
}
