using System.ComponentModel.DataAnnotations;

namespace bug_tracker.Models

{    public class Priority : BaseEntity
    {
        [Key]
        public override int Id {get;set;}
        
        public string Color {get;set;}
        
        public string Name {get;set;}
        
        public int Value {get;set;}
    }
}