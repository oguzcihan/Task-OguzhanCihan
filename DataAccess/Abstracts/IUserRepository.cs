using Core.DataAccess.Abstracts;
using Core.Entities;

namespace DataAccess.Abstracts;

public interface IUserRepository : IAsyncRepository<User>, IRepository<User>
{
    //For AuthorRepository operations
}