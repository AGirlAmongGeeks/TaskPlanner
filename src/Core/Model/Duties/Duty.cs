using Core.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Data
{
    public class Duty : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int UserId { get; set; }
        public bool Enabled { get; set; }
        public bool TaskNeverEnds { get; set; }
        public DutyType TaskType { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
    }
}
