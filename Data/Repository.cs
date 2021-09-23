using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProjectSchool_API.Models;

namespace ProjectSchool_API.Data
{
    public class Repository : IRepository
    {
        public DataContext _context { get; }

        public Repository(DataContext context)
        {
            _context = context;
        }

        public void Add<T>(T entity)
            where T : class
        {
            _context.Add (entity);
        }

        public void Delete<T>(T entity)
            where T : class
        {
            _context.Remove (entity);
        }

        public void Update<T>(T entity)
            where T : class
        {
            _context.Update (entity);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<Student[]> GetAllStudentsAsync(bool includeTeacher)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.Teacher);
            }

            query = query.AsNoTracking().OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Student[]>
        GetStudentsAsyncByTeacherId(int TeacherId, bool includeTeacher)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(s => s.Teacher);
            }

            query =
                query
                    .AsNoTracking()
                    .OrderBy(s => s.Id)
                    .Where(s => s.Id == TeacherId);

            return await query.ToArrayAsync();
        }

        public async Task<Student>
        GetStudentAsyncById(int StudentId, bool includeTeacher)
        {
            IQueryable<Student> query = _context.Students;

            if (includeTeacher)
            {
                query = query.Include(p => p.Teacher);
            }

            query =
                query
                    .AsNoTracking()
                    .OrderBy(s => s.Id)
                    .Where(s => s.Id == StudentId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<Teacher[]> GetAllTeachersAsync(bool includeStudent)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudent)
            {
                query = query.Include(s => s.Students);
            }

            query = query.AsNoTracking().OrderBy(t => t.Id);

            return await query.ToArrayAsync();
        }

        public async Task<Teacher> GetTeacherAsyncById(int TeacherId, bool includeStudent)
        {
            IQueryable<Teacher> query = _context.Teachers;

            if (includeStudent)
            {
                query = query.Include(s => s.Students);
            }

            query = query.AsNoTracking().OrderBy(t => t.Id).Where(t => t.Id == TeacherId);

            return await query.FirstOrDefaultAsync();

        }
    }
}
