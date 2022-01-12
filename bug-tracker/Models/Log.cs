using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bug_tracker.Models

{    public class Log : BaseEntity
    {
        [Key]
        public override int Id {get;set;}
        [ForeignKey("LogType")] 
        public int LogTypeId {get;set;}
        [ForeignKey("Organization")] 
        public int? OrganizationId {get;set;}
        public string Description {get;set;}
        public string Ip {get;set;}
        public DateTime CreationDateTime {get;set;}
        public virtual LogType LogType { get; set; }
        public virtual Organization Organization { get; set; }
    }
}