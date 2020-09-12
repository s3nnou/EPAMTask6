using CustomDAO.DAOObjects;

namespace CustomDAO.DAOBaseObjects
{
    /// <summary>
    /// Subject table record representation
    /// </summary>
    public class Subject : IDAOBaseElement
    {
        /// <summary>
        /// subject ID
        /// </summary>
        private int _id;

        /// <summary>
        /// Subject's name
        /// </summary>
        private string _name;

        /// <summary>
        /// Accessor for ID field
        /// </summary>
        public int ID { get => _id; set => _id = value; }

        /// <summary>
        /// Accessor for Name field
        /// </summary>
        public string Name { get => _name; set => _name = value; }

        /// <summary>
        /// Finds equal Object
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>true - if it was found, if not - false</returns>
        public override bool Equals(object obj)
        {
            if (obj is Subject)
            {
                Subject subject = obj as Subject;

                return (this.ID == subject.ID) && (this.Name == subject.Name);

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
            return (ID.GetHashCode() ^ Name.GetHashCode()) << 2;
        }

        /// <summary>
        /// Displays an information about an object
        /// </summary>
        /// <returns>Information</returns>
        public override string ToString()
        {
            return string.Format($"ID: {ID}\n" +
                        $"Name: {Name})");
        }
    }
}
