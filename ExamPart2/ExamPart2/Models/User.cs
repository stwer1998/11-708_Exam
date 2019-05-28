using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamPart2.Models
{
    public class User 
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public List<Restaurant> Restaurants { get; set; }
        public Role Role { get; set; }
    }
    public enum Role
    {
        Owner,
        Simple
    }
}
