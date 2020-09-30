using Microsoft.EntityFrameworkCore;

namespace organProject.Models
{
    public class MyContext : DbContext{
        public MyContext(DbContextOptions options) : base(options) {}

        public DbSet<User> Users {get;set;}
        public DbSet<Donor> Donors {get;set;}
        public DbSet<Center> Centers {get;set;}
        public DbSet<Recipient> Recipients {get;set;}
    }
}