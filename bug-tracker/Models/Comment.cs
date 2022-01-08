using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bug_tracker.Models

{    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Task")] 
        public int TaskId { get; set; }
        [ForeignKey("UserCreated")] 
        public int UserCreatedId { get; set; }
        
        public DateTime CreationDateTime { get; set; }
        public string Text { get; set; }
        public virtual Task Task { get; set; }
        public virtual User UserCreated { get; set; }
    }
} 