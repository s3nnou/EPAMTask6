using CustomDAO.DAOObjects; 

namespace CustomDAO.FactoryPattern
{
    /// <summary>
    /// DAO Factory interface
    /// </summary>
    public interface IDAOFactory
    {
        /// <summary>
        /// Method for creating instances
        /// </summary>
        /// <param name="str">table name</param>
        /// <returns>base class</returns>
        IDAOBaseElement CreateInstance(string str);
    }
}
