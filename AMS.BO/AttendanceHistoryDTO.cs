using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMS.BO
{
    public class AttendanceHistoryDTO
    {
        public int HisId { get; set; }
        public string HisDateTime { get; set; }
        public bool HisIsPresent { get; set; }
        public int AttId { get; set; }
    }
}
