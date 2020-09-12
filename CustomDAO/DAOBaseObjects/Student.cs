using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDAO.DAOObjects
{
    /// <summary>
    /// Student table record representation
    /// </summary>
    public class Student:IDAOBaseElement
    {
        /// <summary>
        /// Student ID
        /// </summary>
        private int _id;

        /// <summary>
        /// Student's First name
        /// </summary>
        private string _firstName;

        /// <summary>
        /// Student's Last name
        /// </summary>
        private string _lastName;

        /// <summary>
        /// Student's date of birth
        /// </summary>
        private DateTime _dateofbirth;

        /// <summary>
        /// Student's group id
        /// </summary>
        private int groupId;

        /// <summary>
        /// Student's sex
        /// </summary>
        private int _sex;

        /// <summary>
        /// Accessor for ID field
        /// </summary>
        public int ID { get => _id; set => _id = value; }

        /// <summary>
        /// Accessor for FirstNamefield
        /// </summary>
        public string FirstName { get => _firstName; set => _firstName = value; }

        /// <summary>
        /// Accessor for LastName  field
        /// </summary>
        public string LastName { get => _lastName; set => _lastName = value; }

        /// <summary>
        /// Accessor for DateofBirth field
        /// </summary>
        public DateTime DateofBirth { get => _dateofbirth; set => _dateofbirth = value; }

        /// <summary>
        /// Accessor for GroupID  field
        /// </summary>
        public int GroupID { get => groupId; set => groupId = value; }

        /// <summary>
        /// Accessor for Sex field
        /// </summary>
        public int Sex { get => _sex; set => _sex = value; }

        /// <summary>
        /// Finds equal Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true - if it was found, if not - false</returns>
        public override bool Equals(object obj)
        {
            if (obj is Student)
            {
                Student student = obj as Student;

                return (this.ID == student.ID) && (this.GroupID == student.GroupID)
                    && (this.Sex == student.Sex) && (this.FirstName == student.FirstName)
                    && (this.DateofBirth == student.DateofBirth) && (this.LastName == student.LastName);
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
            return (ID.GetHashCode() ^ GroupID.GetHashCode() ^ this.Sex.GetHashCode()
                ^ this.FirstName.GetHashCode() ^ DateofBirth.GetHashCode() ^ LastName.GetHashCode()) << 2;
        }

        /// <summary>
        /// Displays an information about an object
        /// </summary>
        /// <returns>Information</returns>
        public override string ToString()
        {
            return string.Format($"ID: {ID}\n" +
                        $"GroupID: {GroupID}\n" +
                        $"FirstName: {FirstName}\n" +
                        $"LastName: {LastName}\n" +
                        $"Dateofbirth: {DateofBirth.Date}\n" +
                        $"Sex: {Sex}");
        }
    }
}
