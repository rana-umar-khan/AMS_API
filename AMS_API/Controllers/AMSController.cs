using AMS.BO;
using AMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AMS_API.Controllers
{
    public class AMSController : ApiController
    {

        //http://localhost:30878/api/AMS/GetTeachherByUsername?name=ali
        [HttpGet]
        public Object GetTeachherByUsername(string name)
        {
            TeacherDTO tchr=  TeacherDAO.GetTeachherByUsername(name);        
            var Teacher=new { teacher=tchr};
            return Teacher;
        }


        //http://localhost:30878/api/AMS/GetCoursesByTeaId?id=1
        [HttpGet]
        public Object GetCoursesByTeaId(int id)
        {
            List<CourseDTO> cour= CourseDAO.GetCoursesByTeaId(id);
            var Courses = new {courses=cour };
            return Courses;
        }


        //http://localhost:30878/api/AMS/GetAttendanceHistorysByAttId?id=1
        [HttpGet]
        public Object GetAttendanceHistorysByAttId(int id)
        {
            List<AttendanceHistoryDTO> att= AttendanceHistoryDAL.GetAttendanceHistorysByAttId(id);
            var History = new { history=att };
            return History;
        }


        //http://localhost:30878/api/AMS/GetStudentsByCouId?id=1
        [HttpGet]
        public Object GetStudentsByCouId(int id)
        {
            List<StudentDTO> stud= StudentDAO.GetStudentsByCouId(id);
            var Students = new { students = stud };
            return Students;
        }

    }
}
