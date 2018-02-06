using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Model
{
    public class FamilyDto
    {
        public Family Family { get; set; }
        public List<FamilyMemberDto> Members { get; set; }
    }
}
