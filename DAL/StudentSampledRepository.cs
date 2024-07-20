using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hogwartshouses.DAL
{
    public class StudentSampledRepository : IRepository<Student>
    {
        private Sampler _sampler { get; }

        public StudentSampledRepository(Sampler sampler)
        {
            _sampler = sampler;
        }
        
        public HashSet<Student> GetAll()
        {
            return _sampler.Students;
        }

        public Student GetById(int id)
        {
            return _sampler.Students.Where(x => x.StudentId == id).First();
        }
        
        public void Add(Student obj)
        {
            // First make sure, that the student id is incremented.
            obj.StudentId = _sampler.GetStudentId();
            _sampler.Students.Add(obj);
        }

        public bool DeleteById(int id)
        {
            var student = GetById(id);
            return _sampler.Students.Remove(student);
        }

        public void UpdateById(int id, Student obj)
        {
            throw new NotImplementedException();
        }
    }
}