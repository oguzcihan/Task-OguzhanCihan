using Core.DataAccess.Abstracts;
using Core.Entities;

namespace DataAccess.Abstracts;

public interface ICourseRepository : IAsyncRepository<Course>, IRepository<Course>
{
    
}