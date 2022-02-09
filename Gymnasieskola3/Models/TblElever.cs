using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gymnasieskola3.Models
{
    public partial class TblElever
    {
        public TblElever()
        {
            TblKursbetyg = new HashSet<TblKursbetyg>();
        }

        public int ElevId { get; set; }
        public long Personnummer { get; set; }
        public string Eförnamn { get; set; }
        public string Eefternamn { get; set; }
        public int FklassId { get; set; }

        public virtual TblKlasser Fklass { get; set; }
        public virtual ICollection<TblKursbetyg> TblKursbetyg { get; set; }
    }
}
