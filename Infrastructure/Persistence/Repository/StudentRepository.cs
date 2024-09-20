using Application.Repositories;
using Domain.Entities;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.Persistence.Repository
{
    public class StudentRepository:IStudentRepository
    {
        private readonly SchoolApiDbContext _schoolApiDbContext;

        public StudentRepository(SchoolApiDbContext schoolApiDbContext)
        {
            _schoolApiDbContext = schoolApiDbContext;
        }

        public async Task<Student> CreateStudentAsync(Student student)
        {
            await _schoolApiDbContext.Students.AddAsync(student);
            return student;
        }

        public async Task<bool> ExistAsync(Expression<Func<Student, bool>> predicate)
        {
             await _schoolApiDbContext.Students.FirstOrDefaultAsync(predicate);
            return true;
        }

        public async Task<IReadOnlyList<Student>> GetAllAsync()
        {
            var getAllStudent = await _schoolApiDbContext.Students.ToListAsync();
            return getAllStudent;
        }

        public async Task<Student?> GetStudentAsync(Expression<Func<Student, bool> >predicate)
        {
            var getStudent = await _schoolApiDbContext.Students.FirstOrDefaultAsync(predicate);
            return getStudent;
        }

        public void UpdateStudent(Student student)
        {
            _schoolApiDbContext.Students.Update(student);
        }
    }
}
