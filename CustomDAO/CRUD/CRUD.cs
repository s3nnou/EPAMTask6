using CustomDAO.DAOObjects;
using CustomDAO.FactoryPattern;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;

namespace CustomCRUD
{
    /// <summary>
    /// Base CRUD representation with use of Reflection and LINQ-To-Object
    /// </summary>
    /// <typeparam name="T">Type of class</typeparam>
    public class CRUD<T> where T : IDAOBaseElement
    {
        /// <summary>
        /// SQLConnection to the DB
        /// </summary>
        private SqlConnection _sqlConnection;

        /// <summary>
        /// Table name for usage
        /// </summary>
        private string _table;

        /// <summary>
        /// Class properties of T class 
        /// </summary>
        private List<PropertyInfo> _properties = new List<PropertyInfo>(typeof(T).GetProperties());

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString">SQL Connection string</param>
        /// <param name="table">Table to work with</param>
        public CRUD(string connectionString, string table)
        {
            _sqlConnection = new SqlConnection(connectionString);
            _table = "[" + table + "]";
        }

        /// <summary>
        /// Open connection to SQL Server
        /// </summary>
        public void Open()
        {
            _sqlConnection.Open();
        }

        /// <summary>
        /// Close connection to SQL Server
        /// </summary>
        public void Close()
        {
            _sqlConnection.Close();
        }

        /// <summary>
        /// In CRUD states for C - create (INSERT). Creates new record in a selected table 
        /// </summary>
        /// <param name="obj">object to insert</param>
        public void Create(T obj)
        {
            string preInsert = @"INSERT INTO" + _table + " (";

            foreach (var property in _properties)
            {
                preInsert += property.Name + ",";
            }

            preInsert = preInsert.Remove(preInsert.Length - 1);

            preInsert += ")";

            string insert = @"VALUES " + "(";

            List<string> param = new List<string>();

            foreach (var property in _properties)
            {
              
                
                var prop = property.Name;
                param.Add("@" + prop);
                insert += "@" + prop + ",";
            }

            insert = insert.Remove(insert.Length - 1);
            insert += ");";

            preInsert += " " + insert;

            var sqlCommand = new SqlCommand(preInsert, _sqlConnection);

            int i = 0;

            foreach (var property in _properties)
            {
                if (property.Name == "Id")
                {
                    continue;
                }

                var propValue = property.GetValue(obj);
                sqlCommand.Parameters.AddWithValue(param[i], propValue);
                i++;
            }

            try
            {
                Open();
                sqlCommand.ExecuteNonQuery();
                Close();
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();

                for (int ind = 0; ind < ex.Errors.Count; ind++)
                {
                    errorMessages.Append("Index #" + ind + "\n" +
                        "Message: " + ex.Errors[ind].Message + "\n" +
                        "Error Number: " + ex.Errors[ind].Number + "\n" +
                        "LineNumber: " + ex.Errors[ind].LineNumber + "\n" +
                        "Source: " + ex.Errors[ind].Source + "\n" +
                        "Procedure: " + ex.Errors[ind].Procedure + "\n");
                }

                throw new Exception(errorMessages.ToString());
            }

        }

        /// <summary>
        /// In CRUD states for R - read (SELECT). Selects a record in a selected table and returns in object T
        /// </summary>
        /// <param name="id">ID of a record</param>
        /// <returns>selected object</returns>
        public T Read(int id)
        {
            var obj = DAOFactory.getInstance().CreateInstance(typeof(T).Name);
            Type _typeOf = typeof(T);
            string select = @"SELECT * FROM " + _table + " WHERE ID = @ID" + ";";
            SqlCommand sqlCommand = new SqlCommand(select, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@ID", id);

            try
            {
                Open();
                SqlDataReader reader = sqlCommand.ExecuteReader();

                var count = reader.FieldCount;

                if (reader.HasRows)
                {
                    for (int i = 0; i < count; i++)
                    {
                        var fieldName = reader.GetName(i);
                        var propInfo = _typeOf.GetProperty(fieldName);
                        propInfo?.SetValue(obj, reader.GetValue(i));
                    }
                }

                Close();
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();

                for (int ind = 0; ind < ex.Errors.Count; ind++)
                {
                    errorMessages.Append("Index #" + ind + "\n" +
                        "Message: " + ex.Errors[ind].Message + "\n" +
                        "Error Number: " + ex.Errors[ind].Number + "\n" +
                        "LineNumber: " + ex.Errors[ind].LineNumber + "\n" +
                        "Source: " + ex.Errors[ind].Source + "\n" +
                        "Procedure: " + ex.Errors[ind].Procedure + "\n");
                }

                throw new Exception(errorMessages.ToString());
            }

            return (T) obj;
        }

        /// <summary>
        /// In CRUD states for U - update (UPDATE). Updates a record in a selected table
        /// </summary>
        /// <param name="obj">object to update</param>
        /// <param name="id">object id to replace</param>
        public void Update(int index, T obj)
        {
            string update = "UPDATE " + _table + " SET ";

            foreach (var property in _properties)
            {
                update += "[" + property.Name + "]=" + "@" + property.Name + ",";
            }

            update = update.Remove(update.Length - 1);

            update += " WHERE [ID]=@" + nameof(index) + ";";
            SqlCommand sqlCommand = new SqlCommand(update, _sqlConnection);

            foreach (var property in _properties)
            {
                sqlCommand.Parameters.AddWithValue("@" + property.Name, property.GetValue(obj));
            }
            sqlCommand.Parameters.AddWithValue("@" + nameof(index), index);

            try
            {
                Open();
                sqlCommand.ExecuteNonQuery();
                Close();
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();

                for (int ind = 0; ind < ex.Errors.Count; ind++)
                {
                    errorMessages.Append("Index #" + ind + "\n" +
                        "Message: " + ex.Errors[ind].Message + "\n" +
                        "Error Number: " + ex.Errors[ind].Number + "\n" +
                        "LineNumber: " + ex.Errors[ind].LineNumber + "\n" +
                        "Source: " + ex.Errors[ind].Source + "\n" +
                        "Procedure: " + ex.Errors[ind].Procedure + "\n");
                }

                throw new Exception(errorMessages.ToString());
            }
        }

        /// <summary>
        /// In CRUD states for D - delete (DELETE). Deletes a record from a selected table
        /// </summary>
        /// <param name="obj">object to delete</param>
        public void Delete(T obj)
        {
            string delete = "DELETE FROM " + _table + " WHERE ID = @ID ;";

            var property = _properties.First(o => o.Name == "ID");

            SqlCommand sqlCommand = new SqlCommand(delete, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@ID", property.GetValue(obj));

            try
            {
                Open();
                sqlCommand.ExecuteNonQuery();
                Close();
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();

                for (int ind = 0; ind < ex.Errors.Count; ind++)
                {
                    errorMessages.Append("Index #" + ind + "\n" +
                        "Message: " + ex.Errors[ind].Message + "\n" +
                        "Error Number: " + ex.Errors[ind].Number + "\n" +
                        "LineNumber: " + ex.Errors[ind].LineNumber + "\n" +
                        "Source: " + ex.Errors[ind].Source + "\n" +
                        "Procedure: " + ex.Errors[ind].Procedure + "\n");
                }

                throw new Exception(errorMessages.ToString());
            }
        }

        /// <summary>
        /// In CRUD states for D - delete (DELETE). Deletes a record from a selected table
        /// </summary>
        /// <param name="int">int id</param>
        public void Delete(int id)
        {
            string delete = "DELETE FROM " + _table + " WHERE ID = @ID ;";

            SqlCommand sqlCommand = new SqlCommand(delete, _sqlConnection);
            sqlCommand.Parameters.AddWithValue("@ID", id);

            try
            {
                Open();
                sqlCommand.ExecuteNonQuery();
                Close();
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();

                for (int ind = 0; ind < ex.Errors.Count; ind++)
                {
                    errorMessages.Append("Index #" + ind + "\n" +
                        "Message: " + ex.Errors[ind].Message + "\n" +
                        "Error Number: " + ex.Errors[ind].Number + "\n" +
                        "LineNumber: " + ex.Errors[ind].LineNumber + "\n" +
                        "Source: " + ex.Errors[ind].Source + "\n" +
                        "Procedure: " + ex.Errors[ind].Procedure + "\n");
                }

                throw new Exception(errorMessages.ToString());
            }
        }
    }
}