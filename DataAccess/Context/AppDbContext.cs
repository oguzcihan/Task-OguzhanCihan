using Core.Entities;
using Core.Entities.Identity;
using Core.Entities.Relationships;
using Core.Utilities.AppSettings;
using DataAccess.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace DataAccess.Context;

public class AppDbContext : DbContext
{

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    public DbSet<Department> Departments { get; set; }

    //role table
    public DbSet<OperationClaim> OperationClaims { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserOperationClaim> UserOperationClaims { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Tüm seed config lerini alır
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentId, sc.CourseId });
        modelBuilder.Entity<StudentCourse>()
            .HasOne(s => s.Student)
            .WithMany(sc => sc.StudentCourses)
            .HasForeignKey(s => s.StudentId);
        modelBuilder.Entity<StudentCourse>()
            .HasOne(c => c.Course)
            .WithMany(sc => sc.StudentCourses)
            .HasForeignKey(c => c.CourseId);




        base.OnModelCreating(modelBuilder);

    }



}