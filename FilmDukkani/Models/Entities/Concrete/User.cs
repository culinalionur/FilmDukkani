using Microsoft.AspNetCore.Identity;
using System;

namespace FilmDukkani.Models.Entities.Concrete
{
    public class User 
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
       
        public string MailAddress { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public Membership MembershipId { get; set; }

    }
}
