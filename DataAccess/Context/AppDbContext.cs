using Core.Entities;
using Core.Entities.Relationships;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DataAccess.Context;

public class AppDbContext : DbContext
{
    //protected IConfiguration Configuration { get; set; }
    //, IConfiguration configuration
    //Configuration = configuration;

    public DbSet<Student> Students { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudentCourse> StudentCourses { get; set; }
    public DbSet<Department> Departments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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



       // modelBuilder.Entity<Department>().HasData(
       //    new Department
       //    {
       //        Id = 1,
       //        DepartmentName = "Computer Science",
       //        CreatedDate = DateTime.Now,
       //    },
       //    new Department
       //    {
       //        Id = 2,
       //        DepartmentName = "Physics",
       //        CreatedDate = DateTime.Now,
       //    }
       //);

       // modelBuilder.Entity<Course>().HasData(
       //     new Course
       //     {
       //         Id = 1,
       //         CourseName = "Math",
       //         CreatedDate = DateTime.Now,
       //     },
       //     new Course
       //     {
       //         Id = 2,
       //         CourseName = "Physics",
       //         CreatedDate = DateTime.Now,
       //     },
       //     new Course
       //     {
       //         Id = 3,
       //         CourseName = "Chemistry",
       //         CreatedDate = DateTime.Now,
       //     }
       // );

        base.OnModelCreating(modelBuilder);
    }

}