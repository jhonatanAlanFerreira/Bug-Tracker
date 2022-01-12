using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bug_tracker.Models

{    public class ProjectGroup : BaseEntity
    {
        [Key]
        public override int Id {get;set;}
        [ForeignKey("Project")] 
        public int ProjectId {get;set;}
        [ForeignKey("Group")] 
        public int GroupId {get;set;}
        public virtual Project Project{ get; set; }
        public virtual Group Group{ get; set; }
    }
}