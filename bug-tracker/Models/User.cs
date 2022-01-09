using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bug_tracker.Models

{    public class User
    {
        [Key]
        public int Id {get;set;}
        
        public string Name {get;set;}
        
        public string Login {get;set;}
        
        public string Email {get;set;}
        
        public string Password {get;set;}
        [ForeignKey("Organization")] 
        public int OrganizationId {get;set;}
        [ForeignKey("UserType")]
        public int UserTypeId {get;set;}
        public virtual Organization Organization { get; set; }
        public virtual UserType UserType { get; set; }
    }
}