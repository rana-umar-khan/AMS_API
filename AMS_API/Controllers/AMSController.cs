using AMS.BO;
using AMS.DAL;
using Newtonsoft.Json;
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

        //http://localhost:30878/api/AMS/UpdateTeacher?teacher=tchr
        [HttpGet]
        public Object UpdateTeacher(string teacher)
        {
            //Check this
            TeacherDTO tchr = JsonConvert.DeserializeObject<TeacherDTO>(teacher);

            int c = TeacherDAO.Save(tchr);

            bool status = true;
            if (c > 1)
                status = true;
            else
                status = false;

            var Status = new { IsUpdated = status };
            return Status;
        }


        //http://localhost:30878/api/AMS/IsAttendanceMarked?CouId=1&Date=date
        [HttpGet]
        public Object IsAttendanceMarked(int CouId, string Date)
        {
            AttendanceDTO stuAtt = AttendanceDAO.GetAttendancesByCouId(CouId).First();
            List<AttendanceHistoryDTO> attHisList = AttendanceHistoryDAL.GetAttendanceHistorysByAttId(stuAtt.AttId);

            bool toReturn = false;

            foreach (AttendanceHistoryDTO ah in attHisList)
            {
                if (ah.HisDateTime.Date.ToString().Equals(Date))
                    toReturn = true;
            }

            var IsMarked = new { IsSaved = toReturn };
            return IsMarked;
        }


        //http://localhost:30878/api/AMS/SaveAttendance?history=xyz
        [HttpGet]
        public Object SaveAttendance(string history)
        {
            //Check this
            List<AttendanceHistoryDTO> attHis = JsonConvert.DeserializeObject<List<AttendanceHistoryDTO>>(history);

            for (int i = 0; i < attHis.Count; i++)
            {
                AttendanceHistoryDTO ahd = attHis.ElementAt(i);
                AttendanceHistoryDAL.Save(ahd);

                AttendanceDTO atndnc = AttendanceDAO.GetAttendanceById(ahd.AttId);
                if (ahd.HisIsPresent)
                    atndnc.AttPresents++;
                else
                    atndnc.AttAbsents++;
                AttendanceDAO.Save(atndnc);
            }

            var IsSaved = new { IsSaved = true };
            return IsSaved;
        }


    }
}
