using System.ComponentModel.DataAnnotations;

namespace bug_tracker.Models

{
    public class Organization
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
    }
}