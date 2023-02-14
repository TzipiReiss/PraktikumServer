using System.ComponentModel.DataAnnotations;

namespace _3_Repository.Entities
{
    public enum Gender
    {
        male = 1,//זכר
        female//נקבה
    }
    public enum HMO
    {
        Clalit,
        Leumit,
        Maccabi,
        Meuhedet
    }
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [MaxLength(9)]
        [MinLength(9)]
        public string IDNumber { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public HMO HMO { get; set; }
        [Required]
        public List<Child> Children { get; set; }=new List<Child>();
    }
}
