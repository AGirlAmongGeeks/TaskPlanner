using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class Family : Core.Model.BaseModel
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
