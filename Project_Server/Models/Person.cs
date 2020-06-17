using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Server.Models
{
    public class Person
    {   [Key]
        public long Id { get; set; }
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(25)]
        public string LastName { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        /*[Required]
        [MaxLength(11)]
        public string SocialSecurityNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        public DateTime LastTimeEdited { get; set; }
        [Required]
        [MaxLength(200)]
        public string Symptom { get; set; }
        [MaxLength(200)]
        public string Diagnosis { get; set; }*/
    }
}
