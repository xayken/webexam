using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.DAL.Contoller
{
    public class StudentDbController
    {
        private static StudentDbController _instance;

        private StudentDbController()
        {

        }

        public static StudentDbController GetInstance()
        {
            return _instance ?? new StudentDbController();
        }


        public Student AddNewStudent(Student _student)
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    context.Students.Add(_student);
                    var numberOfInserted = context.SaveChanges();
                    if (numberOfInserted > 0)
                    {
                        return _student;
                    }
                    else
                        return null;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Student UpdateStudent(Student _student)
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    var oldStudent = context.Students.FirstOrDefault(x => x.Id == _student.Id);
                    if (oldStudent != null)
                    {
                        oldStudent.Name = _student.Name;
                        oldStudent.Surname = _student.Surname;

                        var numberOfUpdated = context.SaveChanges();

                        return numberOfUpdated > 0 ? _student : null;
                    }

                    return null;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }


        public bool DeleteStudent(int _id)
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    var deletedStudent = context.Students.FirstOrDefault(x => x.Id == _id);

                    if (deletedStudent != null)
                    {
                        context.Students.Remove(deletedStudent);
                        return context.SaveChanges() > 0;
                    }
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Student GetStudentById(int _id)
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    return context.Students.FirstOrDefault(x => x.Id == _id);

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Student> GetAllStudents()
        {
            try
            {
                using (var context = new SchoolEntities())
                {
                    return context.Students.ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }


    }
}
