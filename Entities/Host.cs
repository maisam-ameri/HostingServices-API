using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    public class Host
    {
        [Column("HostId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the {0} is {1} characters.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "{0} is a required field.")]
        [MaxLength(500, ErrorMessage = "Maximum length for the {0} is {1} characters.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "{0} is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the {0} is {1} characters.")]
        public string? Details { get; set; }


        public ICollection<Plan>? Plans { get; set; }

    }
}
