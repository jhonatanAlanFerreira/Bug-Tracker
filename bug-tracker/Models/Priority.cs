using System.ComponentModel.DataAnnotations;

namespace bug_tracker.Models

{    public class Priority
    {
        [Key]
        public int Id {get;set;}
        
        public string Color {get;set;}
        
        public string Name {get;set;}
        
        public int Value {get;set;}
    }
}