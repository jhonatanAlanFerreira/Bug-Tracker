using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bug_tracker.Models

{    public class GroupUser : BaseEntity
    {
        [Key]
        public override int Id {get;set;}
        [ForeignKey("User")] 
        public int UserId {get;set;}
        [ForeignKey("Group")] 
        public int GroupId {get;set;}
        public virtual User User {get;set;}
        public virtual Group Group {get;set;}
    }
}