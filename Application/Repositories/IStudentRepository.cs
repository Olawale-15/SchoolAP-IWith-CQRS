using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Repositories
{
    public interface IStudentRepository
    {
        Task<Student> CreateStudentAsync(Student student);
        void UpdateStudent(Student student);
        Task<Student?> GetStudentAsync(Expression<Func<Student, bool>> predicate);
        Task<bool> ExistAsync(Expression<Func<Student, bool>> predicate);
        Task<IReadOnlyList<Student>> GetAllAsync();
    }
}
