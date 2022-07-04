using System;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_System_.API.Models
{
    public class Languages
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsDeleted { get; set; }

    }
}
