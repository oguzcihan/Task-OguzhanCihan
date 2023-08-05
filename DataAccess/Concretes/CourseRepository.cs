using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstracts;
using DataAccess.Context;

namespace DataAccess.Concretes;

public class CourseRepository : EfRepositoryBase<Course, AppDbContext>, ICourseRepository
{
    public CourseRepository(AppDbContext context) : base(context)
    {
    }
}