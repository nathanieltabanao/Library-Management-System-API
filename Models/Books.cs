using System;
using System.ComponentModel.DataAnnotations;
namespace Library_Management_System_.API.Models
{
    public class Books
    {
        [Key]
        public Guid Id { get; set; }
        public string ISBN { get; set; }
        public string Title { get; set; }
        public Guid LanaguageId { get; set; }
        public Guid AuthorId { get; set; }
        public Guid PublisherId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
