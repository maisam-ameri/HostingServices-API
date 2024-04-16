using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record HostForManipulationDto
    {
        [Required(ErrorMessage = "{0} is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the {0} is {1} characters.")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "{0} is a required field.")]
        [MaxLength(500, ErrorMessage = "Maximum length for the {0} is {1} characters.")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "{0} is a required field.")]
        [MaxLength(100, ErrorMessage = "Maximum length for the {0} is {1} characters.")]
        public string? Details { get; set; }


        public ICollection<PlanForCreationDto>? Plans { get; set; }
    }
}
