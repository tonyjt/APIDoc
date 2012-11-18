using APIDoc.IDAL;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace APIDoc.DataFactory
{
    /// <summary>
    /// This class is implemented following the Abstract Factory pattern to create the DAL implementation
    /// specified from the configuration file
    /// </summary>
    public sealed class DataAccess
    {

        // Look up the DAL implementation we should be using
        private static readonly string path = ConfigurationManager.AppSettings["APIDocDAL"];

        private DataAccess() { }

        public static IDALAPIDoc CreateAPIDoc()
        {
            return CreateDAL<IDALAPIDoc>(path, "DALAPIDoc");
        }

        public static IDALCategory CreateCategory()
        {
            return CreateDAL<IDALCategory>(path, "DALCategory");
        }

        public static IDALDomain CreateDomain()
        {
            return CreateDAL<IDALDomain>(path, "DALDomain");
        }

        public static IDALError CreateOrder()
        {
            return CreateDAL<IDALError>(path, "DALError");
        }
        private static T CreateDAL<T>(string path, string className)
        {
            string absClassName = string.Format("{0},{1}", path, className);

            return (T)Assembly.Load(path).CreateInstance(className);
        }
    }
}
