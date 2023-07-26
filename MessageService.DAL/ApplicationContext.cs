using MessageService.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace MessageService.DAL
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<MessageModel> Messages { get; set; }
    }
}
