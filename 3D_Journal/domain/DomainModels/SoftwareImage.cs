using System;
using System.Collections.Generic;
using System.Text;

namespace domain.DomainModels
{
    public class SoftwareImage : Image
    {
        virtual public Software Software { get; set; }
        //public Guid SoftwareId { get; set; }
    }
}
