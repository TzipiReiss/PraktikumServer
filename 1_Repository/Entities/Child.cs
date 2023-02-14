using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _3_Repository.Entities
{
    public class Child
    {
        [Key]
        public int ChildId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(9)]
        [MinLength(9)]
        public string IDNumber { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
    }
}