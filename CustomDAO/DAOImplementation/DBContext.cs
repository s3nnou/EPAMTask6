namespace CustomDAO.DAOImplementation
{
    /// <summary>
    /// DataBase context class
    /// </summary>
    public abstract class DBContext
    {
        /// <summary>
        /// Connection string for server
        /// </summary>
        internal readonly string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=TASK6UB; Integrated Security=true";
    }
}
