using CustomDAO.DAOImplementation;
using CustomDAO.DAOObjects;
using System;
using System.Collections.Generic;
using Xunit;

namespace Task6Tests
{
    public class CRUDTests
    {
        /// <summary>
        /// Tests Addition and Reading from DB 
        /// </summary>
        /// <param name="ex_student">student class to add</param>
        [Theory]
        [MemberData(nameof(Data11))]
        public void CRUD_Creation_And_Reading_Test(Student ex_student)
        {
            UniversityContext universityContext = new UniversityContext();

            universityContext.Students.Add(ex_student);
            Student t_student = universityContext.Students.Get(ex_student.ID);
            
            Assert.Equal(ex_student, t_student);
            universityContext.Students.Delete(ex_student);
        }

        /// <summary>
        /// Data for CRUD_Creation_And_Reading_Test method
        /// </summary>
        public static IEnumerable<object[]> Data11 =>
       new List<object[]>
       {
            new object[] { new Student() {ID = 55, FirstName = "Dima", GroupID = 1, LastName ="Baranovsky", Sex = 0, DateofBirth = DateTime.Now},},
            new object[] { new Student() {ID = 55, FirstName = "Katya", GroupID = 1, LastName ="Kovalsky", Sex = 1, DateofBirth = DateTime.Now},},
            new object[] { new Student() {ID = 55, FirstName = "Zina", GroupID = 1, LastName ="Mironova", Sex = 1, DateofBirth = DateTime.Now},},
       };


        /// <summary>
        /// Tests Udpate method for DB
        /// </summary>
        /// <param name="ex_student">what to change</param>
        /// <param name="change">replacment</param>
        [Theory]
        [MemberData(nameof(Data12))]
        public void CRUD_Update_Test(Student ex_student, Student change)
        {
            UniversityContext universityContext = new UniversityContext();

            universityContext.Students.Add(ex_student);
            Student t_student = universityContext.Students.Get(ex_student.ID);

            universityContext.Students.Update(55, change);

            Assert.Equal(change, universityContext.Students.Get(55));
            universityContext.Students.Delete(change);
        }

        /// <summary>
        /// Data for CRUD_Update_Test memthod
        /// </summary>
        public static IEnumerable<object[]> Data12 =>
        new List<object[]>
        {
           new object[] { new Student() {ID = 55, FirstName = "Dima", GroupID = 1, LastName ="Baranovsky", Sex = 0, DateofBirth = DateTime.Now},
           new Student() {ID = 55, FirstName = "Kirill", GroupID = 1, LastName ="Baranovsky", Sex = 0, DateofBirth = DateTime.Now}, },
            new object[] { new Student() {ID = 55, FirstName = "Katya", GroupID = 1, LastName ="Kovalsky", Sex = 1, DateofBirth = DateTime.Now},
            new Student() {ID = 55, FirstName = "Katya", GroupID = 1, LastName ="Serikova", Sex = 1, DateofBirth = DateTime.Now}, },
            new object[] { new Student() {ID = 55, FirstName = "Zina", GroupID = 1, LastName ="Mironova", Sex = 1, DateofBirth = DateTime.Now},
             new Student() {ID = 55, FirstName = "Kirill", GroupID = 1, LastName ="Baranovsky", Sex = 0, DateofBirth = DateTime.Now}, },
        };

        /// <summary>
        /// Tests Delete method for DB
        /// </summary>
        /// <param name="ex_student">object to be deleted</param>
        [Theory]
        [MemberData(nameof(Data13))]
        public void CRUD_Delete_Test(Student ex_student)
        {
            UniversityContext universityContext = new UniversityContext();

            universityContext.Students.Add(ex_student);
            universityContext.Students.Delete(ex_student);
            Assert.Throws<ArgumentException>(() => universityContext.Students.Get(55));
        }

        /// <summary>
        /// Data for CRUD_Delete_Test memthod
        /// </summary>
        public static IEnumerable<object[]> Data13 =>
        new List<object[]>
        {
           new object[] { new Student() {ID = 55, FirstName = "Dima", GroupID = 1, LastName ="Baranovsky", Sex = 0, DateofBirth = DateTime.Now},
          },
            new object[] { new Student() {ID = 55, FirstName = "Katya", GroupID = 1, LastName ="Kovalsky", Sex = 1, DateofBirth = DateTime.Now},},
            new object[] { new Student() {ID = 55, FirstName = "Zina", GroupID = 1, LastName ="Mironova", Sex = 1, DateofBirth = DateTime.Now},},
        };
    }
}
