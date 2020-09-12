using CustomDAO.DAOBaseObjects;
using CustomDAO.DAOImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileExtensions
{
    /// <summary>
    /// Class for building information to write it on XLS format
    /// </summary>
    public class InformationBuilding
    {
        /// <summary>
        /// Method for getting information about one group session results
        /// </summary>
        /// <param name="university">DBContext</param>
        /// <param name="sessionID">Session id</param>
        /// <param name="filepath">path to the file</param>
        /// <param name="sort">Sotring type</param>
        /// <returns>group names and mark</returns>
        public Dictionary<string, float> GetSessionForAGroupInformation(UniversityContext university, int sessionID, string filepath, string sort)
        {
            SortingMethods methods = new SortingMethods();

            Dictionary<string, float> group_contains = new Dictionary<string, float>();

            var Grades = from grade in university.Grades
                         where grade.SessionID == sessionID
                         select grade;

            var Students = from grd in Grades
                           select grd.StudentID;

            var groups = from student in university.Students
                         where Students.Contains(student.ID)
                         select student.GroupID;

            groups = groups.Distinct();

            var Groups = from grp in university.Groups
                         where groups.Contains(grp.ID)
                         select grp;

            foreach (var t in Groups)
            {
                var student_count = from student in university.Students
                                    where student.GroupID == t.ID
                                    select student.ID;

                var marks = from grd in Grades
                            where student_count.Contains(grd.StudentID)
                            select grd.Mark;

                float mark = (marks.Sum() / marks.Count());

                group_contains.Add(t.Name, mark);
            }

            return methods.OrderList(group_contains, sort);
        }

        /// <summary>
        /// Method for getting information about all sessions
        /// </summary>
        /// <param name="university">DBContext</param>
        /// <param name="filepath">path to the file</param>
        /// <param name="TypeOfOrder">how to sort</param>
        /// <returns>group name and marks</returns>
        public Dictionary<Session, Dictionary<string, List<float>>> GetSessionInformation(UniversityContext university, string filepath, string TypeOfOrder = "OrderBy")
        {
            Dictionary<Session, Dictionary<string, List<float>>> results = new Dictionary<Session, Dictionary<string, List<float>>>();

            foreach (Session session_elem in university.Sessions)
            {
                Dictionary<string, List<float>> group_contains = new Dictionary<string, List<float>>();

                var Grades = from grade in university.Grades
                             where grade.SessionID == session_elem.ID
                             select grade;

                var students = from grd in Grades
                               select grd.StudentID;

                var groups = from student in university.Students
                             where students.Contains(student.ID)
                             select student.GroupID;

                groups = groups.Distinct();

                var Groups = from grp in university.Groups
                             where groups.Contains(grp.ID)
                             select grp;

                foreach (var t in Groups)
                {
                    var student_count = from student in university.Students
                                        where student.GroupID == t.ID
                                        select student.ID;

                    var marks = from grd in Grades
                                where student_count.Contains(grd.StudentID)
                                select grd.Mark;

                    float mark_Aver = (marks.Sum() / marks.Count());
                    float mark_max = marks.Max();
                    float mark_min = marks.Min();

                    group_contains.Add(t.Name, new List<float>() { mark_max, mark_Aver, mark_min });
                }

                results.Add(session_elem, group_contains);
            }
            SortingMethods methods = new SortingMethods();

            return methods.OrderList(results, TypeOfOrder);
        }

        /// <summary>
        /// Method for getting information about all D-Students
        /// </summary>
        /// <param name="university">DBContext</param>
        /// <param name="filepath">path to the file</param>
        /// <param name="TypeOfOrder">how to sort</param>
        /// <returns>group name and students names</returns>
        public Dictionary<string, List<string>> GetAllDStudents(UniversityContext university, string filepath, string TypeOfOrder = "OrderBy")
        {
            Dictionary<string, List<string>> group_allocated = new Dictionary<string, List<string>>();


            var Grades = from grade in university.Grades
                         where grade.Mark < 4
                         select grade;

            var students = from grd in Grades
                           select grd.StudentID;


            var student_allocated = from student in university.Students
                                    where students.Contains(student.ID)
                                    select student;

            student_allocated = student_allocated.Distinct();

            var groups = from student in student_allocated
                         select student.GroupID;


            var Groups = from grp in university.Groups
                         where groups.Contains(grp.ID)
                         select grp;

            foreach (var t in Groups)
            {
                var student_count = from student in university.Students
                                    where student.GroupID == t.ID
                                    select student.LastName;

                group_allocated.Add(t.Name, student_count.ToList());
            }

            SortingMethods methods = new SortingMethods();

            return methods.OrderList(group_allocated, TypeOfOrder);
        }
    }
}
