using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bug_tracker.Models

{    public class TaskState : BaseEntity
    {
        [Key]
        public override int Id {get;set;}
        
        public string Name {get;set;}
        [ForeignKey("Organization")] 
        public int OrganizationId {get;set;}
        
        public int Order {get;set;}
        [ForeignKey("Project")]
        public int ProjectId {get;set;}
        [ForeignKey("TaskSet")]
        public int TaskSetId {get;set;}
        public virtual Organization Organization { get; set; }
        public virtual Project Project { get; set; }
        public virtual TaskSet TaskSet { get; set; }
    }
}