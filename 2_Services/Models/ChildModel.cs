﻿using _3_Repository.Entities;
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
        public int ChildId { get; set; }
        public string FirstName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string IDNumber { get; set; }
        public int UserId { get; set; }
    }
}
