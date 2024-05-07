﻿using System.ComponentModel.DataAnnotations;

namespace AcademyAPI.Model
{
    public class Customer
    {
        [Key]
        public int Cust_Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public int Phone { get; set; }

        //Relationships
        public List<Order> Orders { get; set; }
    }
}
