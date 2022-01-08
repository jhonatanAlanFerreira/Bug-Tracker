using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bug_tracker.Models

{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }
        [ForeignKey("Organization")] 
        public int OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }
    }
}