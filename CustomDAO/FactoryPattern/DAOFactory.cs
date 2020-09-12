using CustomDAO.DAOObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


namespace CustomDAO.FactoryPattern
{
    /// <summary>
    /// Factory class. Creates instances of tables classes.
    /// </summary>
    public class DAOFactory : IDAOFactory
    {
        private Dictionary<string, Type> _tableTypes = new Dictionary<string, Type>();
        private bool isUsed = false;

        //singltone
        private DAOFactory() { }

        private static DAOFactory _instance;

        public Dictionary<string, Type> TableTypes { get => _tableTypes; set => _tableTypes = value; }

        public static DAOFactory getInstance()
        {
            if (_instance == null)
                _instance = new DAOFactory();
            return _instance;
        }
        //end

        public IDAOBaseElement CreateInstance(string str)
        {
            void GenerateAssemblyTypes()
            {
                if (!isUsed)
                {
                    Type[] typesInThisAssembly = Assembly.GetExecutingAssembly().GetTypes();

                    foreach (Type type in typesInThisAssembly)
                    {
                        if (type.GetInterface(typeof(IDAOBaseElement).ToString()) != null)
                        {
                            TableTypes.Add(type.Name, type);
                        }
                    }

                    isUsed = true;
                }

            }

            Type t;

            GenerateAssemblyTypes();
            if (TableTypes.Keys.Contains(str))
            {
                t = TableTypes[str];

                return Activator.CreateInstance(t) as IDAOBaseElement;
            }
            else
            {
                throw new Exception("Shit");
            }
        }
    }
}
