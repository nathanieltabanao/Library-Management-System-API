using System;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System_.API.Models
{
    public class Authors
    {
        [Key]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool IsDeleted { get; set; }
    }
}
