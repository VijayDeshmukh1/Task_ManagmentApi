using Microsoft.EntityFrameworkCore;
using Task_ManagmentApi.Models;

namespace Task_ManagmentApi.Data
{
    public class ApplicationDbContext: DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {                
        }
        public DbSet<User> Users { get; set; } 
        public DbSet<TaskItem> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
    
                // Configure the relationship between User and TaskItem
                modelBuilder.Entity<User>()
                    .HasMany(u => u.Tasks)
                    .WithOne(t => t.User)
                    .HasForeignKey(t => t.UserId)
                    .OnDelete(DeleteBehavior.Cascade); // Optional: specify delete behavior

            modelBuilder.Entity<User>()
                .HasIndex(u=>u.Email)
                .IsUnique(); // Ensure email is unique

            modelBuilder.Entity<User>()
               .HasIndex(u => u.UserName)
               .IsUnique();
        }
    }
}
