﻿using Core.Enums;
using System.ComponentModel.DataAnnotations;
namespace Core.Entities
{
    public class User
    {
        public Guid UserID { get; set; } = Guid.NewGuid();
        public Role Role { get; set; } = Role.Customer;
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } 


        public string Password { get; set; }
        public string Address { get; set; }


    
    }

}
