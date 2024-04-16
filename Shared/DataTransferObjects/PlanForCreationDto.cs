
using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public record PlanForCreationDto
    {
        [Required(ErrorMessage = "{0} is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the {0} is {1} characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} is a required field.")]
        public double Price { get; set; }
    }
}
