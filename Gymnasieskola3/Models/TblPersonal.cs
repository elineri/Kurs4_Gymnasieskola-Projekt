using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gymnasieskola3.Models
{
    public partial class TblPersonal
    {
        public TblPersonal()
        {
            TblAvdelningPersonal = new HashSet<TblAvdelningPersonal>();
            TblKursbetyg = new HashSet<TblKursbetyg>();
        }

        public int PersonalId { get; set; }
        public string Pförnamn { get; set; }
        public string Pefternamn { get; set; }
        public string Befattning { get; set; }
        public int Lön { get; set; }
        public DateTime? Startdatum { get; set; }
        public DateTime? Slutdatum { get; set; }

        public virtual ICollection<TblAvdelningPersonal> TblAvdelningPersonal { get; set; }
        public virtual ICollection<TblKursbetyg> TblKursbetyg { get; set; }
    }
}
