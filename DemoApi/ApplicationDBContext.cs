using DemoApi.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoApi
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options) 
        { }

        public virtual DbSet<StudentModel> Students { get; set; }
    }
}
