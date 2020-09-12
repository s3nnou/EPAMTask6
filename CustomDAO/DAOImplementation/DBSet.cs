using CustomCRUD;
using CustomDAO.DAOObjects;
using CustomDAO.FactoryPattern;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace CustomDAO.DAOImplementation
{
    /// <summary>
    /// Class for custom DBSet representation
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DBSet<T> : IEnumerable<T> where T : IDAOBaseElement
    {
        /// <summary>
        /// List for holding T objects
        /// </summary>
        private List<T> _list;

        /// <summary>
        /// Connection string to SQL Server
        /// </summary>
        private string _connectionString;

        /// <summary>
        /// Crud model for T object
        /// </summary>
        private CRUD<T> _crud;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="connectionString">Connection string</param>
        public DBSet(string connectionString)
        {
            _list = new DAOCreateTableSet<T>().ReadTable(typeof(T), connectionString).ToList();
            _connectionString = connectionString;
            _crud = new CRUD<T>(connectionString, typeof(T).Name);
        }

        /// <summary>
        /// Indexer for T objects in list
        /// </summary>
        /// <param name="index">index</param>
        /// <returns>T object</returns>
        public T this[int index]
        {
            get
            {
                return _list[index];
            }
            set
            {
                _list[index] = value;
            }
        }

        /// <summary>
        /// Gets Enumerator
        /// </summary>
        /// <returns>Enumerator</returns>
        public IEnumerator<T> GetEnumerator()
        {
            return _list.GetEnumerator();
        }

        /// <summary>
        /// Enumerator itself
        /// </summary>
        /// <returns>Calls GetEnumerator()</returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Adds new record
        /// </summary>
        /// <param name="obj">object to add</param>
        public void Add(T obj)
        {
            _list.Add(obj);
            _crud.Create(obj);
        }

        /// <summary>
        /// Delets object
        /// </summary>
        /// <param name="obj">object to delete</param>
        public void Delete(T obj)
        {
            _list.Remove(obj);
            _crud.Delete(obj);
        }

        /// <summary>
        /// Delets object
        /// </summary>
        /// <param name="obj">object to delete</param>
        public void Delete(int id)
        {
            _list.Remove((T)_list.First(item => item.ID == id));
            _crud.Delete(id);
        }

        /// <summary>
        /// Gets object from table by ID
        /// </summary>
        /// <param name="ID">Id of a search item</param>
        /// <returns>found object</returns>
        public T Get(int ID)
        {
            try
            {
                return (T)_list.First(item => item.ID == ID);
                
            }
            catch(Exception ex)
            {
                throw new ArgumentException();
            }
        } 

        /// <summary>
        /// Updates old object with a new one
        /// </summary>
        /// <param name="id">id to change</param>
        /// <param name="obj">new object</param>
        public void Update(int id, T obj)
        {
            _crud.Update(id, obj);

            for (int i = 0; i < _list.Count; i++)
            {
                if (_list[i].ID == id)
                {
                    _list[i] = obj;
                    break;
                }
            }
        }
    }
}
