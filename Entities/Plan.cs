using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    public class Plan
    {
        [Column("PlanId")]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "{0} is a required field.")]
        [MaxLength(60, ErrorMessage = "Maximum length for the {0} is {1} characters.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} is a required field.")]
        public double Price { get; set; }


        [ForeignKey(nameof(Host))]
        public Guid HostId { get; set; }
        public Host? Host { get; set; }
        public List<Feature>? Features{ get; set; }
        //public User Users{ get; set; }

    }
}
