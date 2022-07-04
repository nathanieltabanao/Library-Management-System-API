using Library_Management_System_.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System_.API.DataAccess
{
    public class LMSDBContext: DbContext
    {
        public LMSDBContext(DbContextOptions<LMSDBContext> options): base(options)
        { }
        public virtual DbSet<Books> Books { get; set; }
        public virtual DbSet<Languages> Languages { get; set; }
        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Publishers> Publishers { get; set; }
        public virtual DbSet<Authors> Authors { get; set; }
    }
}
