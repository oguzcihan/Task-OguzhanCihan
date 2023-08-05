using Core.DataAccess.Abstracts;
using Core.Dtos;
using Core.Entities;
using DataAccess.Context;
using System.Linq.Expressions;

namespace DataAccess.Abstracts;

public interface IStudentRepository : IBaseRepository<Student>
{
    ICollection<Student> GetStudents();
}