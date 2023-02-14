using _3_Repository.Entities;
using System.ComponentModel.DataAnnotations;

namespace _2_Services.Models
{
    public class UserModel
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(9)]
        [MinLength(9)]
        public string IDNumber { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public HMO HMO { get; set; }

        public List<ChildModel> Children { get; set; } = new List<ChildModel>();
    }
}
