using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.BO
{
    public class TeacherDTO
    {
        //{"TeaId":1,"TeaUsername":"ali","TeaPassword":"123","TeaFirstName":"Ali","TeaLastName":"Ahmad","TeaEmail":"123@abc.xyz","TeaContactNo":"03213456789"}
        public int TeaId { get; set; }
        public string TeaUsername { get; set; }
        public string TeaPassword { get; set; }
        public string TeaFirstName { get; set; }
        public string TeaLastName { get; set; }
        public string TeaEmail { get; set; }
        public string TeaContactNo { get; set; }
    }
}
