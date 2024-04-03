using System.ComponentModel.DataAnnotations.Schema;


namespace Entities
{
    public class Feature
    {
        [Column("FeatureId")]
        public Guid Id { get; set; }
        public int Storage { get; set; }
        public int Traffic { get; set; }
        public int DbCount { get; set; }
        public bool MySql { get; set; }


        [ForeignKey(nameof(Plan))]
        public Guid PlanId { get; set; }
        public Plan? Plan { get; set; }
    }
}
