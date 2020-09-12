using CustomDAO.DAOBaseObjects;
using CustomDAO.DAOObjects;

namespace CustomDAO.DAOImplementation
{
    /// <summary>
    /// Data Base context representation
    /// </summary>
    public class UniversityContext: DBContext
    {
        /// <summary>
        /// Students table
        /// </summary>
        public DBSet<Student> Students { get; set; }

        /// <summary>
        /// Exams table
        /// </summary>
        public DBSet<Exam> Exams { get; set; }

        /// <summary>
        /// Group table
        /// </summary>
        public DBSet<Group> Groups { get; set; }

        /// <summary>
        /// Session table
        /// </summary>
        public DBSet<Session> Sessions { get; set; }

        /// <summary>
        /// Subject table
        /// </summary>
        public DBSet<Subject> Subjects { get; set; }

        /// <summary>
        /// Grade table
        /// </summary>
        public DBSet<Grade> Grades { get; set; }

        /// <summary>
        /// Contructor
        /// </summary>
        public UniversityContext(): base()
        {
            Students = new DBSet<Student>(connectionString);
            Exams = new DBSet<Exam>(connectionString);
            Groups = new DBSet<Group>(connectionString);
            Sessions = new DBSet<Session>(connectionString);
            Subjects = new DBSet<Subject>(connectionString);
            Grades = new DBSet<Grade>(connectionString);
        }
    }
}
