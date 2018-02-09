using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CST356_Week_4_Lab.Data.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        public string MiddleName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public int YearsInSchool { get; set; }
        
        [Required]
        public int Age { get; set; }

        [Required]
        public string Occupation { get; set; }
    }
}