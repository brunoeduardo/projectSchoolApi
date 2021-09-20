using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :
            base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<Teacher>()
                .HasData(new List<Teacher>()
                {
                    new Teacher()
                    { Id = 1, Name = "Bruce T ", Surname = "Doe" },
                    new Teacher()
                    { Id = 2, Name = "Julia T ", Surname = "Doe" },
                    new Teacher() { Id = 3, Name = "John T ", Surname = "Doe" }
                });

            builder
                .Entity<Student>()
                .HasData(new List<Student>()
                {
                    new Student()
                    {
                        Id = 1,
                        Name = "John",
                        Surname = "Doe",
                        Birth = "22/12/2002",
                        TeacherId = 1
                    },
                    new Student()
                    {
                        Id = 2,
                        Name = "Jane",
                        Surname = "Doe",
                        Birth = "12/06/1992",
                        TeacherId = 2
                    },
                    new Student()
                    {
                        Id = 3,
                        Name = "Gabriel",
                        Surname = "Doe",
                        Birth = "01/03/2000",
                        TeacherId = 3
                    }
                });
        }
    }
}
