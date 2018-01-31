using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data.Duties
{
    public class Duty
    {
        public int UserId { get; set; }
        public int TaskId { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime Deadline { get; set; }
    }
}
