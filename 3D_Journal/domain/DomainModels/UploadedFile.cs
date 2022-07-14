using System;
using System.Collections.Generic;
using System.Text;

namespace domain.DomainModels
{
    public class UploadedFile:BaseEntity
    {
        public string Path { get; set; }
        public virtual Project Project { get; set; }
    }
}
