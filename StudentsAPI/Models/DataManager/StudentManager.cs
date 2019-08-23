using System.Collections.Generic;
using System.Linq;
using StudentsAPI.Models.Repository;

namespace StudentsAPI.Models.DataManager
{
    public class StudentManager : IDataRepository<Student>
    {
        private readonly StudentContext studentContext;

        public StudentManager(StudentContext studentcontext)
        {
            this.studentContext = studentcontext;
        }
        public IEnumerable<Student> GetAll()
        {
            return studentContext.Students.ToList();
        }
        public Student Get(long id)
        {
            return studentContext.Students
                  .FirstOrDefault(e => e.StudentId == id);
        }
        public void Add(Student entity)
        {
            studentContext.Students.Add(entity);
            studentContext.SaveChanges();
        }
        public void Update(Student student, Student entity)
        {
            student.FirstName = entity.FirstName;
            student.LastName = entity.LastName;
            student.University = entity.University;
            student.City = entity.City;
            student.Country = entity.Country;
            studentContext.SaveChanges();
        }
        public void Delete(Student student)
        {
            studentContext.Students.Remove(student);
            studentContext.SaveChanges();
        }
    }
}
