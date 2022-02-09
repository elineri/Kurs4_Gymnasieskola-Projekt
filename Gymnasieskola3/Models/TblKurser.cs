using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gymnasieskola3.Models
{
    public partial class TblKurser
    {
        public TblKurser()
        {
            TblKursbetyg = new HashSet<TblKursbetyg>();
        }

        public int KursId { get; set; }
        public string Kursnamn { get; set; }

        public virtual ICollection<TblKursbetyg> TblKursbetyg { get; set; }
    }
}
