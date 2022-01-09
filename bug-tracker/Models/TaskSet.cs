using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bug_tracker.Models

{    public class TaskSet
    {
        [Key]
        public int Id {get;set;}
        
        public string Name {get;set;}
        public string Description {get;set;}
        [ForeignKey("Project")]
        public int ProjectId {get;set;}
        public virtual Project Project { get; set; }
    }
}