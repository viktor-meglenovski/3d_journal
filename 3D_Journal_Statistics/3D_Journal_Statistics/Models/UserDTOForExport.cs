using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _3D_Journal_Statistics.Models
{
    public class UserDTOForExport
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Likes { get; set; }
        public int Projects { get; set; }
        public int Income { get; set; }
    }
}
