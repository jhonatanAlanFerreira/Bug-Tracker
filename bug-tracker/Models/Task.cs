using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bug_tracker.Models

{    public class Task : BaseEntity
    {
        [Key]
        public override int Id {get;set;}
        [ForeignKey("UserCreated")] 
        public int UserCreatedId {get;set;}
        [ForeignKey("Organization")] 
        public int OrganizationId {get;set;}
        [ForeignKey("State")]
        public int StateId {get;set;}
        [ForeignKey("Priority")]
        public int PriorityId {get;set;}
        [ForeignKey("Project")]
        public int ProjectId {get;set;}
        [ForeignKey("TaskSet")] 
        public int TaskSetId {get;set;}
        
        public string Title {get;set;}
        public string Description {get;set;}
        public bool Done { get; set; } = false;
        
        public int OrderState {get;set;}
        
        public DateTime CreationDateTime {get;set;}
        public DateTime FinishedDateTime {get;set;}
        public virtual User UserCreated { get; set; }
        public virtual TaskState State { get; set; }
        public virtual Organization Organization { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual Project Project { get; set; }
        public virtual TaskSet TaskSet { get; set; }
    }
}