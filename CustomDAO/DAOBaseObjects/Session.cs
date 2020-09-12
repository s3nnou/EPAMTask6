using CustomDAO.DAOObjects;
using System;

namespace CustomDAO.DAOBaseObjects
{
    /// <summary>
    /// Session table record representation
    /// </summary>
    public class Session : IDAOBaseElement
    {
        /// <summary>
        /// Session ID
        /// </summary>
        private int _id;

        /// <summary>
        /// Session start date
        /// </summary>
        private DateTime _startDate;

        /// <summary>
        /// Session end date
        /// </summary>
        private DateTime _endDate;

        /// <summary>
        /// Accessor for ID field
        /// </summary>
        public int ID { get => _id; set => _id = value; }

        /// <summary>
        /// Accessor for Start Date field
        /// </summary>
        public DateTime StartDate { get => _startDate; set => _startDate = value; }

        /// <summary>
        /// Accessor for End Date field
        /// </summary>
        public DateTime EndDate { get => _endDate; set => _endDate = value; }

        /// <summary>
        /// Finds equal Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true - if it was found, if not - false</returns>
        public override bool Equals(object obj)
        {
            if (obj is Session)
            {
                Session session = obj as Session;

                return (this.ID == session.ID) && (this.StartDate == session.StartDate)
                    && (this.EndDate == session.EndDate);
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
            return (ID.GetHashCode() ^ StartDate.GetHashCode() ^ EndDate.GetHashCode()) << 2;
        }

        /// <summary>
        /// Displays an information about an object
        /// </summary>
        /// <returns>Information</returns>
        public override string ToString()
        {
            return string.Format($"ID: {ID}\n" +
                        $"Start date: {StartDate}\n" +
                        $"End date: {EndDate}");
        }
    }
}
