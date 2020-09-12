using CustomDAO.DAOBaseObjects;
using CustomDAO.DAOImplementation;
using CustomDAO.DAOObjects;
using CustomDAO.FactoryPattern;
using System;
using System.Collections.Generic;
using Xunit;

namespace Task6Tests
{
    public class FactoryTest
    {
        /// <summary>
        /// Test for factory instances creation
        /// </summary>
        /// <param name="objj"></param>
        [Theory]
        [MemberData(nameof(Data11))]
        public void Factoty_Test(object objj)
        {
            IDAOBaseElement obj = DAOFactory.getInstance().CreateInstance(objj.GetType().Name);
            Type t = obj.GetType();
            Type tt = objj.GetType();
            Assert.IsType(tt, obj);
        }

        /// <summary>
        /// Data for Factoty_Test method
        /// </summary>
        public static IEnumerable<object[]> Data11 =>
        new List<object[]>
        {
            new object[] { new Student() {ID = 55, FirstName = "Dima", GroupID = 1, LastName ="Baranovsky", Sex = 0, DateofBirth = DateTime.Now},},
            new object[] { new Exam() {ID = 1, GroupId = 2, SessionID = 1, SubjectID = 2, ExamDate = DateTime.Today, IsCredit = false},},
            new object[] { new Grade() {ID = 1, Mark = 1, ExamID = 1, GroupID = 1, SessionID = 1, StudentID = 1},},
            new object[] { new Group() { ID = 1, Name = "TT-1"},},
            new object[] { new Subject() { ID = 1, Name = "Math"},},
            new object[] { new Session() { ID = 1, StartDate = DateTime.Today, EndDate= DateTime.Today},},
        };
    }
}
