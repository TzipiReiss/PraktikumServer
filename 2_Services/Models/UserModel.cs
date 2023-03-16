using _3_Repository.Entities;
using System.ComponentModel.DataAnnotations;

namespace _2_Services.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IDNumber { get; set; }
        public Gender Gender { get; set; }
        public HMO HMO { get; set; }
        public List<ChildModel> Children { get; set; } = new List<ChildModel>();
    }
}
