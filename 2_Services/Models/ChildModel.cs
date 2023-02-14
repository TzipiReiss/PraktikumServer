using _3_Repository.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Services.Models
{
    public class ChildModel
    {
        [Key]
        public int ChildId { get; set; }
        [Required]  
        public string FirstName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string IDNumber { get; set; }
        [ForeignKey("UserId")]
        public int? UserId { get; set; }
    }
}
