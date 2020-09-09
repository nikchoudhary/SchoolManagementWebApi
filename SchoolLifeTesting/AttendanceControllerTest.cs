using NUnit.Framework;
using Moq;
using SchoolLife.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SchoolLife.Controllers;
using SchoolLife.Repository;
using Microsoft.AspNetCore.Mvc;


namespace SchoolLifeTesting
{
    public class AttendancesControllerTesting
    {
        ManagementContext db;

        [SetUp]
        public void Setup()
        {
            var emp = new List<Attendance>
            {
                new Attendance{RollNo=1,Attendance1="32",Result=45},
                new Attendance{RollNo=3,Attendance1="52",Result=86},
                new Attendance{RollNo=1,Attendance1="29",Result=96},

            };

            var salData = emp.AsQueryable();
            var mockSet = new Mock<DbSet<Attendance>>();
            mockSet.As<IQueryable<Attendance>>().Setup(m => m.Provider).Returns(salData.Provider);
            mockSet.As<IQueryable<Attendance>>().Setup(m => m.Expression).Returns(salData.Expression);
            mockSet.As<IQueryable<Attendance>>().Setup(m => m.ElementType).Returns(salData.ElementType);
            mockSet.As<IQueryable<Attendance>>().Setup(m => m.GetEnumerator()).Returns(salData.GetEnumerator());

            var mockContext = new Mock<ManagementContext>();
            mockContext.Setup(c => c.Attendance).Returns(mockSet.Object);
            db = mockContext.Object;

        }



        [Test]
        public void GetDetailsTest()
        {
            var res = new Mock<AttendanceRep>(db);
            AttendancesController obj = new AttendancesController(res.Object);
            var data = obj.Get(1);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }

        [Test]
        public void Add_Valid_Detail()
        {
            var res = new Mock<AttendanceRep>(db);
            AttendancesController obj = new AttendancesController(res.Object);
            Attendance emp = new Attendance { RollNo = 1, Attendance1 = "59", Result = 96 };

            var data = obj.Post(emp);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }





        [Test]
        public void GetDetailTest()
        {
            AttendanceRep res = new AttendanceRep(db);
            AttendancesController obj = new AttendancesController(res);
            IActionResult data = obj.Get(1);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }

        [Test]
        public void Update_Valid_Detail()
        {
            AttendanceRep res = new AttendanceRep(db);
            AttendancesController obj = new AttendancesController(res);

            Attendance emp = new Attendance { RollNo = 1, Attendance1 = "32", Result = 96 };
            var data = obj.Put(1, emp);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }
        [Test]
        public void Delete_Valid_Detail()
        {
            AttendanceRep res = new AttendanceRep(db);
            AttendancesController obj = new AttendancesController(res);
            var data = obj.Delete(1);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}