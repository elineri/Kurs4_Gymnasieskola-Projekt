using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gymnasieskola3.Models
{
    public partial class TblAvdelningPersonal
    {
        public int Apid { get; set; }
        public int FpersonalId { get; set; }
        public int FavdelningId { get; set; }

        public virtual TblAvdelningar Favdelning { get; set; }
        public virtual TblPersonal Fpersonal { get; set; }
    }
}
