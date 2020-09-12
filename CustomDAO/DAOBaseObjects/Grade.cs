using CustomDAO.DAOObjects;

namespace CustomDAO.DAOBaseObjects
{
    /// <summary>
    /// Grade  table record representation
    /// </summary>
    public class Grade: IDAOBaseElement
    {
        /// <summary>
        /// Grade ID
        /// </summary>
        private int _id;

        /// <summary>
        /// Group ID
        /// </summary>
        private int _groupId;

        /// <summary>
        /// Student's mark
        /// </summary>
        private int _mark;

        /// <summary>
        /// Exam ID
        /// </summary>
        private int _examId;

        /// <summary>
        /// Student ID
        /// </summary>
        private int _studentId;

        /// <summary>
        /// Session ID
        /// </summary>
        private int _sessionId;

        /// <summary>
        /// Accessor for ID field
        /// </summary>
        public int ID { get => _id; set => _id = value; }

        /// <summary>
        /// Accessor for Mark field
        /// </summary>
        public int Mark { get => _mark; set => _mark = value; }

        /// <summary>
        /// Accessor for Exam IDfield
        /// </summary>
        public int ExamID { get => _examId; set => _examId = value; }

        /// <summary>
        /// Accessor for Group ID field
        /// </summary>
        public int GroupID { get => _groupId; set => _groupId = value; }

        /// <summary>
        /// Accessor for Student ID field
        /// </summary>
        public int StudentID { get => _studentId; set => _studentId = value; }

        /// <summary>
        /// Accessor for Session ID field
        /// </summary>
        public int SessionID { get => _sessionId; set => _sessionId = value; }

        /// <summary>
        /// Finds equal Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true - if it was found, if not - false</returns>
        public override bool Equals(object obj)
        {
            if (obj is Grade)
            {
                Grade grade = obj as Grade;

                return (this.ID == grade.ID) && (this.GroupID == grade.GroupID)
                    && (this.Mark == grade.Mark) && (this.ExamID == grade.ExamID)
                    && (this.SessionID == grade.SessionID);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Calculates Hashcode
        /// </summary>
        /// <returns>Hashcode</returns>
        public override int GetHashCode()
        {
            return (ID.GetHashCode() ^ GroupID.GetHashCode() ^ SessionID.GetHashCode()
                ^ ExamID.GetHashCode() ^ Mark.GetHashCode()) << 2;
        }

        /// <summary>
        /// Displays an information about an object
        /// </summary>
        /// <returns>Information</returns>
        public override string ToString()
        {
            return string.Format($"ID: {ID}\n" +
                        $"GroupID: {GroupID}\n" +
                        $"SessionID: {SessionID}\n" +
                        $"ExamID: {ExamID}\n" +
                        $"Mark: {Mark}\n" );
        }

    }
}
