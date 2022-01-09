using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bug_tracker.Models

{    public class Project
    {
        [Key]
        public int Id {get;set;}
        
        public string Name {get;set;}
        [ForeignKey("Organization")] 
        public int OrganizationId {get;set;}
        [ForeignKey("UserCreated")] 
        public int UserCreatedId {get;set;}
        public string Description {get;set;}
        public virtual Organization Organization { get; set; }
        public virtual User UserCreated { get; set; }
    }
}