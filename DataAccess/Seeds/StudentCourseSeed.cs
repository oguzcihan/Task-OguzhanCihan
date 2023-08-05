using Core.Entities.Relationships;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Seeds
{
    public class StudentCourseSeed : IEntityTypeConfiguration<StudentCourse>
    {
        public void Configure(EntityTypeBuilder<StudentCourse> builder)
        {
            builder.HasData(
                    new StudentCourse
                    {
                        CourseId = 1,
                        StudentId = 1
                    }
                );
        }
    }
}
