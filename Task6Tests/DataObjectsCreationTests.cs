using CustomDAO.DAOBaseObjects;
using CustomDAO.DAOImplementation;
using CustomDAO.DAOObjects;
using System;
using System.Collections.Generic;
using Xunit;

namespace Task6Tests
{
    /// <summary>
    /// Data object creation tests
    /// </summary>
    public class DataObjectsCreationTests
    {
        /// <summary>
        /// Tests for object creation
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="firstName">first name</param>
        /// <param name="groupID">group id</param>
        /// <param name="lastName">last name</param>
        /// <param name="sex">sex</param>
        /// <param name="dateofbirth">date of bith</param>
        /// <param name="ex_student">object to compare</param>
        [Theory]
        [MemberData(nameof(Data11))]
        public void Student_Object_Creation_Test(int id, string firstName, int groupID, string lastName, int sex, DateTime dateofbirth, Student ex_student)
        {
            Student t_student = new Student() { ID = id, FirstName = firstName, GroupID = groupID, LastName = lastName, Sex = sex, DateofBirth = DateTime.Today};
            Assert.True(ex_student.Equals(t_student));
        }

        /// <summary>
        /// Data for  Student_Object_Creation_Test method
        /// </summary>
        public static IEnumerable<object[]> Data11 =>
        new List<object[]>
        {
            new object[] { 55, "Dima", 1, "Baranovsky", 0, DateTime.Now,  new Student() {ID = 55, FirstName = "Dima", GroupID = 1, LastName ="Baranovsky", Sex = 0, DateofBirth = DateTime.Today },},
            new object[] {55, "Katya", 1, "Kovalsky", 1, DateTime.Now,  new Student() {ID = 55, FirstName = "Katya", GroupID = 1, LastName ="Kovalsky", Sex = 1, DateofBirth = DateTime.Today },},
        };

        /// <summary>
        /// Test exam object creation
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="groupID">group id</param>
        /// <param name="sessionId">session id</param>
        /// <param name="subjectId">subject id</param>
        /// <param name="examDate">exam date</param>
        /// <param name="iscredit">is credit bool</param>
        /// <param name="ex_exam">object to compare</param>
        [Theory]
        [MemberData(nameof(Data12))]
        public void Exam_Object_Creation_Test(int id, int groupID, int sessionId, int subjectId, DateTime examDate, bool iscredit, Exam ex_exam)
        {
            Exam t_exam = new Exam() { ID = id, GroupId = groupID, SessionID = sessionId, SubjectID = subjectId, ExamDate = examDate, IsCredit = iscredit };
            Assert.True(ex_exam.Equals(t_exam));
        }

        /// <summary>
        /// Data for Exam_Object_Creation_Test method
        /// </summary>
        public static IEnumerable<object[]> Data12 =>
        new List<object[]>
        {
            new object[] { 1, 1, 1, 1, DateTime.Today, true, new Exam() {ID = 1, GroupId = 1, SessionID = 1, SubjectID = 1, ExamDate = DateTime.Today, IsCredit = true },},
            new object[] { 1, 2, 1, 2, DateTime.Today, false, new Exam() {ID = 1, GroupId = 2, SessionID = 1, SubjectID = 2, ExamDate = DateTime.Today, IsCredit = false},},
        };

        /// <summary>
        /// Tests for grade object creation
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="groupID">group id</param>
        /// <param name="sessionId">session id</param>
        /// <param name="examid">exam id</param>
        /// <param name="studentid">student id</param>
        /// <param name="markl">mark id</param>
        /// <param name="ex_grade">object to compare</param>
        [Theory]
        [MemberData(nameof(Data13))]
        public void Grade_Object_Creation_Test(int id, int groupID, int sessionId, int examid, int studentid,  int markl, Grade ex_grade)
        {
            Grade t_grade = new Grade() { ID = id, GroupID = groupID, SessionID = sessionId, ExamID = examid, StudentID = studentid, Mark = markl };
            Assert.True(ex_grade.Equals(t_grade));
        }

        /// <summary>
        /// Data for Grade_Object_Creation_Testt method
        /// </summary>
        public static IEnumerable<object[]> Data13 =>
        new List<object[]>
        {
            new object[] { 1, 1, 1, 1, 1, 1, new Grade() {ID = 1, Mark = 1, ExamID = 1, GroupID = 1, SessionID = 1, StudentID = 1},},
            new object[] { 2, 1, 1, 1, 1, 1, new Grade() { ID = 2, Mark = 1, ExamID = 1, GroupID = 1, SessionID = 1, StudentID = 1},},
        };

        /// <summary>
        /// Tests for group object creation
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">name</param>
        /// <param name="ex_group">obj to compare</param>
        [Theory]
        [MemberData(nameof(Data14))]
        public void Group_Object_Creation_Test(int id, string name, Group ex_group)
        {
            Group t_groupe = new Group() { ID = id, Name = name };
            Assert.True(ex_group.Equals(t_groupe));
        }

        /// <summary>
        /// Data for Group_Object_Creation_Test method
        /// </summary>
        public static IEnumerable<object[]> Data14 =>
        new List<object[]>
        {
            new object[] { 1, "TT-1", new Group() { ID = 1, Name = "TT-1"},},
            new object[] { 2, "TT-2", new Group() { ID = 2, Name = "TT-2"},},
        };

        /// <summary>
        /// Tests for subject object creation
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="name">name</param>
        /// <param name="ex_subject">obj to compare</param>
        [Theory]
        [MemberData(nameof(Data15))]
        public void Subject_Object_Creation_Test(int id, string name, Subject ex_subject)
        {
            Subject t_subject = new Subject() { ID = id, Name = name };
            Assert.True(ex_subject.Equals(t_subject));
        }

        /// <summary>
        /// Data for Subject_Object_Creation_Test method
        /// </summary>
        public static IEnumerable<object[]> Data15 =>
        new List<object[]>
        {
            new object[] { 1, "Math", new Subject() { ID = 1, Name = "Math"},},
            new object[] { 2, "Physics", new Subject() { ID = 2, Name = "Physics"},},
        };

        /// <summary>
        /// Tests for session object creation
        /// </summary>
        /// <param name="id">id</param>
        /// <param name="start">start date</param>
        /// <param name="finish">finish date</param>
        /// <param name="ex_session">obj to compare</param>
        [Theory]
        [MemberData(nameof(Data16))]
        public void Session_Object_Creation_Test(int id, DateTime start, DateTime finish, Session ex_session)
        {
            Session t_session = new Session() { ID = id, StartDate = start, EndDate = finish};
            Assert.True(ex_session.Equals(t_session));
        }

        /// <summary>
        /// Data for Session_Object_Creation_Test method
        /// </summary>
        public static IEnumerable<object[]> Data16 =>
        new List<object[]>
        {
            new object[] { 1, DateTime.Today, DateTime.Today, new Session() { ID = 1, StartDate = DateTime.Today, EndDate= DateTime.Today},},
            new object[] { 2, DateTime.Today, DateTime.Today, new Session() { ID = 2, StartDate = DateTime.Today, EndDate= DateTime.Today},},
        };
    }
}
