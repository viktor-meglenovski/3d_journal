using System;
using System.Collections.Generic;
using System.Text;

namespace domain.DTO
{
    public class UserDtoForExport
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
