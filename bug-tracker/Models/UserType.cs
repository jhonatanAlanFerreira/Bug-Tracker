using System.ComponentModel.DataAnnotations;

namespace bug_tracker.Models

{    public class UserType : BaseEntity
    {
        [Key]
        public override int Id {get;set;}
        
        public string Name {get;set;}
    }
}