using System;
using System.IO;
using CustomDAO.DAOImplementation;
using CustomDAO.DAOObjects;
using FileExtensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class WritingTests
    {
        /// <summary>
        /// Writes file with session results by session id
        /// </summary>
        [TestMethod]
        public void WriteReport1()
        {
            var filepath = Environment.CurrentDirectory + @"\a.xlsx";

            UniversityContext context = new UniversityContext();

            GenerateXLS generate = new GenerateXLS();
            generate.WriteSessionResultForAGroup(context, 1, filepath, "OrderBy");

            long strs= 0;
            using (var reader = new FileStream(filepath, FileMode.Open))
            {
                strs = reader.Length;
            }

            Assert.IsTrue(strs > 0);
        }

        /// <summary>
        /// Writes file with all session results
        /// </summary>
        [TestMethod]
        public void WriteReport2()
        {
            var filepath = Environment.CurrentDirectory + @"\b.xlsx";

            UniversityContext context = new UniversityContext();

            GenerateXLS generate = new GenerateXLS();
            generate.WriteSessionsResults(context, filepath, "OrderBy");

            long strs = 0;
            using (var reader = new FileStream(filepath, FileMode.Open))
            {
                strs = reader.Length;
            }

            Assert.IsTrue(strs > 0);
        }

        /// <summary>
        /// Writes file with all D-Students (4 or less marks) by groups
        /// </summary>
        [TestMethod]
        public void WriteReport3()
        {
            var filepath = Environment.CurrentDirectory + @"\c.xlsx";

            UniversityContext context = new UniversityContext();

            GenerateXLS generate = new GenerateXLS();
            generate.WriteAllDStudents(context, filepath, "OrderBy");

            long strs = 0;
            using (var reader = new FileStream(filepath, FileMode.Open))
            {
                strs = reader.Length;
            }

            Assert.IsTrue(strs > 0);
        }

        /// <summary>
        /// Creates exeption by trying to parse wrong type of order
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void WriteReport4()
        {
            var filepath = Environment.CurrentDirectory + @"\d.xlsx";

            UniversityContext context = new UniversityContext();

            GenerateXLS generate = new GenerateXLS();
            generate.WriteAllDStudents(context, filepath, "Test");

        }
    }
}
