﻿using hairSalonScheduler.Models.Enum;
using System;

namespace hairSalonScheduler.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public string Address { get; set; }
        public int LoyaltyPoints { get; set; }
    }
}
