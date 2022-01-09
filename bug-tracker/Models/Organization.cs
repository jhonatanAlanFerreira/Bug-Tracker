using System.ComponentModel.DataAnnotations;

namespace bug_tracker.Models

{    public class Organization
    {
        [Key]
        public int Id {get;set;}
        
        public string Name {get;set;}
    }
}