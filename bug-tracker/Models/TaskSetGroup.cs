using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bug_tracker.Models

{    public class TaskSetGroup : BaseEntity
    {
        [Key]
        public override int Id {get;set;}
        [ForeignKey("Group")] 
        public int GroupId {get;set;}
        [ForeignKey("TaskSet")] 
        public int TaskSetId {get;set;}
        public virtual Group Group { get; set; }
        public virtual TaskSet TaskSet { get; set; }
    }
}