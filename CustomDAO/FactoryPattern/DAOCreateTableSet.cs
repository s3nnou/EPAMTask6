using CustomDAO.DAOObjects;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection;

namespace CustomDAO.FactoryPattern
{
    /// <summary>
    /// Factory pattern creator. Class for ReadTable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DAOCreateTableSet<T> where T : IDAOBaseElement
    {
        /// <summary>
        /// Method for reading table
        /// </summary>
        /// <param name="typeTable">table type</param>
        /// <param name="connectionString">connection string to sql server</param>
        /// <returns>T DBSet</returns>
        public IEnumerable<T> ReadTable(Type typeTable, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string command = $"SELECT * FROM [{typeTable.Name}]";

                SqlCommand cmd = new SqlCommand(command);

                cmd.Connection = conn;
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                var list = new List<T>();

                IDAOBaseElement obj = DAOFactory.getInstance().CreateInstance(typeTable.Name);

                int columnsNumber = reader.FieldCount;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (var i = 0; i < columnsNumber; i++)
                        {
                            string fieldName = reader.GetName(i);
                            PropertyInfo propInfo = obj.GetType().GetProperty(fieldName);
                            propInfo?.SetValue(obj, reader.GetValue(i));
                        }

                        list.Add((T)obj);
                        obj = DAOFactory.getInstance().CreateInstance(typeTable.Name);
                    }
                }

                return list;
            }

        }
    }
}
