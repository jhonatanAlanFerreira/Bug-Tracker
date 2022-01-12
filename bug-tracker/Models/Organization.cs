using System.ComponentModel.DataAnnotations;

namespace bug_tracker.Models

{
    public class Organization : BaseEntity
    {
        [Key]
        public override int Id { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
    }
}