using System.Threading.Tasks;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public interface IRepository
    {
        void Add<T>(T entity) where T : class;

        void Update<T>(T entity) where T : class;

        void Delete<T>(T entity) where T : class;

        Task<bool> SaveChangesAsync();

        Task<Student[]> GetAllStudentsAsync(bool includeTeacher);

        Task<Student[]> GetStudentsAsyncByTeacherId(int TeacherId, bool includeTeacher);

        Task<Student> GetStudentAsyncById(int StudentId, bool includeTeacher);

        Task<Teacher[]> GetAllTeachersAsync(bool includeStudent);

        Task<Teacher> GetTeacherAsyncById(int TeacherId, bool includeStudent);
    }
}
