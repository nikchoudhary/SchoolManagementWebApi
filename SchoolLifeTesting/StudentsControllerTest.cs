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
    public class StudentsControllerTest
    {
        ManagementContext db;

        [SetUp]
        public void Setup()
        {
            var emp = new List<Students>
            {
                new Students{Class=6,Name="Dummy 1",RollNo=1,Age=12},
                new Students{Class=5,Name="Dummy 2",RollNo=5,Age=14},
                new Students{Class=8,Name="Dummy 3",RollNo=4,Age=16},
               

            };

            var empdata = emp.AsQueryable();
            var mockSet = new Mock<DbSet<Students>>();
            mockSet.As<IQueryable<Students>>().Setup(m => m.Provider).Returns(empdata.Provider);
            mockSet.As<IQueryable<Students>>().Setup(m => m.Expression).Returns(empdata.Expression);
            mockSet.As<IQueryable<Students>>().Setup(m => m.ElementType).Returns(empdata.ElementType);
            mockSet.As<IQueryable<Students>>().Setup(m => m.GetEnumerator()).Returns(empdata.GetEnumerator());

            var mockContext = new Mock<ManagementContext>();
            mockContext.Setup(c => c.Students).Returns(mockSet.Object);
            db = mockContext.Object;

        }



        [Test]
        public void GetDetailsTest()
        {
            var res = new Mock<StudentsRep>(db);
            StudentsController obj = new StudentsController(res.Object);
            var data = obj.Get();
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);

        }

        [Test]
        public void Add_Valid_Detail()
        {
            var res = new Mock<StudentsRep>(db);
            StudentsController obj = new StudentsController(res.Object);
            Students emp = new Students { Class = 6, Name = "Dummy 5", RollNo = 1, Age = 12 };

            var data = obj.Post(emp);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }





        [Test]
        public void GetDetailTest()
        {
            StudentsRep res = new StudentsRep(db);
            StudentsController obj = new StudentsController(res);
            var data = obj.Get(5);
            var okResult = data as ObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }



        [Test]
        public void Update_Valid_Detail()
        {

            Students emp = new Students { Class = 6, Name = "Dummy 6", RollNo = 1, Age = 12 };
            StudentsRep res = new StudentsRep(db);
            StudentsController obj = new StudentsController(res);
            var data = obj.Put(8, emp);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }
        [Test]
        public void Delete_Valid_Detail()
        {
            StudentsRep loandata = new StudentsRep(db);
            StudentsController obj = new StudentsController(loandata);
            var data = obj.Delete(5);
            var okResult = data as OkObjectResult;
            Assert.AreEqual(200, okResult.StatusCode);
        }
    }
}