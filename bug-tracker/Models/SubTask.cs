using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bug_tracker.Models

{    public class SubTask
    {
        [Key]
        public int Id {get;set;}
        [ForeignKey("Task")] 
        public int TaskId {get;set;}
        [ForeignKey("Priority")] 
        public int PriorityId {get;set;}
        [ForeignKey("WorkingUser")] 
        public int WorkingUserId {get;set;}
        
        public string Text {get;set;}
        public bool Done { get; set; } = false;
        public bool CanUserAssume { get; set; } = true;
        
        public DateTime CreationDateTime {get;set;}
        
        public DateTime FinishedDateTime {get;set;}
        public virtual Task Task { get; set; }
        public virtual Priority Priority { get; set; }
        public virtual User WorkingUser { get; set; }
    }
}