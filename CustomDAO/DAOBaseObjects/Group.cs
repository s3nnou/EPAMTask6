using CustomDAO.DAOObjects;

namespace CustomDAO.DAOBaseObjects
{
    /// <summary>
    /// Group  table record representation
    /// </summary>
    public class Group : IDAOBaseElement
    {
        /// <summary>
        /// Exam ID
        /// </summary>
        private int _id;

        /// <summary>
        /// Group ID
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
            if (obj is Group)
            {
                Group group = obj as Group;

                return (this.ID == group.ID) && (this.Name == group.Name);
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
                        $"Name: {Name}\n");
        }
    }
}
