using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gymnasieskola3.Models
{
    public partial class TblAvdelningar
    {
        public TblAvdelningar()
        {
            TblAvdelningPersonal = new HashSet<TblAvdelningPersonal>();
        }

        public int AvdelningId { get; set; }
        public string Avdelningsnamn { get; set; }

        public virtual ICollection<TblAvdelningPersonal> TblAvdelningPersonal { get; set; }
    }
}
