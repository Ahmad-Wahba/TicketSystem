using Microsoft.EntityFrameworkCore;
using TicketSystem.Core.Models;
using BCrypt.Net;

namespace TicketSystem.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options) {         }

        public DbSet<User> Users { get; set; }
        public DbSet<ITTeam> ITTeams { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Here you can add any Fluent API configurations if needed in the future


            // 1. Seed Departments
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "Human Resources" },
                new Department { Id = 5, Name = "IT" }
            );

            // 2. Seed a regular User
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FullName = "Ahmad Employee",
                    Email = "employee@example.com",
                    PasswordHash = "$2a$12$A3aIyrP5RyvXZZ6uDuLAHObBtXkeVWZGm4pT8Hpy1iyu.d0Fewor.",
                    RemoteConnectionId = "123456789",
                    Role = UserRole.Employee,
                    DepartmentId = 1
                }
            );

            // 3. Seed an IT Team member
            modelBuilder.Entity<ITTeam>().HasData(
                new ITTeam
                {
                    Id = 1,
                    FullName = "Omar IT Support",
                    Email = "it@example.com",
                    PasswordHash = "$2a$12$A3aIyrP5RyvXZZ6uDuLAHObBtXkeVWZGm4pT8Hpy1iyu.d0Fewor.",
                    DepartmentId = 5
                }
            );



            modelBuilder.Entity <Comment>()
                .HasOne(U => U.User)
                .WithMany(C => C.Comments)
                .HasForeignKey(C => C.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(T => T.Ticket)
                .WithOne(C => C.Comment)
                .HasForeignKey<Comment>(C => C.TicketId)
                .OnDelete(DeleteBehavior.Cascade);

               
        }
    }
}
