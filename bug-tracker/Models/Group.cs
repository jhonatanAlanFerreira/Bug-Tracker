using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bug_tracker.Models

{
    public class Group : BaseEntity
    {
        [Key]
        public override int Id { get; set; }
        
        public string Name { get; set; }
        [ForeignKey("Organization")] 
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
    }
}