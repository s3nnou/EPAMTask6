using CustomDAO.DAOObjects;
using System;

namespace CustomDAO.DAOBaseObjects
{
    /// <summary>
    /// Exam  table record representation
    /// </summary>
    public class Exam : IDAOBaseElement
    {
        /// <summary>
        /// Exam ID
        /// </summary>
        private int _id;

        /// <summary>
        /// Group ID
        /// </summary>
        private int _groupId;

        /// <summary>
        /// Session ID
        /// </summary>
        private int _sessionID;

        /// <summary>
        /// Subject ID
        /// </summary>
        private int _subjectID;

        /// <summary>
        /// Date of exam
        /// </summary>
        private DateTime _examDate;

        /// <summary>
        /// Is it Credit
        /// </summary>
        private bool _isCredit;

        /// <summary>
        /// Accessor for ID field
        /// </summary>
        public int ID { get => _id; set => _id = value; }

        /// <summary>
        /// Accessor for GroupId field
        /// </summary>
        public int GroupId { get => _groupId; set => _groupId = value; }

        /// <summary>
        /// Accessor for SessionID field
        /// </summary>
        public int SessionID { get => _sessionID; set => _sessionID = value; }

        /// <summary>
        /// Accessor for SubjectID field
        /// </summary>
        public int SubjectID { get => _subjectID; set => _subjectID = value; }

        /// <summary>
        /// Accessor for ExamDate field
        /// </summary>
        public DateTime ExamDate { get => _examDate; set => _examDate = value; }

        /// <summary>
        /// Accessor for IsCredit field
        /// </summary>
        public bool IsCredit { get => _isCredit; set => _isCredit = value; }

        /// <summary>
        /// Finds equal Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true - if it was found, if not - false</returns>
        public override bool Equals(object obj)
        {
            if (obj is Exam)
            {
                Exam exam = obj as Exam;

                return (this.ID == exam.ID) && (this.GroupId == exam.GroupId)
                    && (this.IsCredit == exam.IsCredit) && (this.SubjectID == exam.SubjectID)
                    && (this.ExamDate == exam.ExamDate) && (this.SessionID == exam.SessionID);
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
            return (ID.GetHashCode() ^ GroupId.GetHashCode() ^ SessionID.GetHashCode() 
                ^SubjectID.GetHashCode() ^ ExamDate.GetHashCode() ^ IsCredit.GetHashCode()) << 2;
        }

        /// <summary>
        /// Displays an information about an object
        /// </summary>
        /// <returns>Information</returns>
        public override string ToString()
        {
            return string.Format($"ID: {ID}\n" +
                        $"GroupID: {GroupId}\n" +
                        $"SessionID: {SessionID}\n" +
                        $"SubjectID: {GroupId}\n" +
                        $"ExamDate: {ExamDate.Date}\n" +
                        $"IsCredit: {IsCredit}");
        }
    }
}
