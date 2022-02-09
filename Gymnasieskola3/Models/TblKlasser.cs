using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gymnasieskola3.Models
{
    public partial class TblKlasser
    {
        public TblKlasser()
        {
            TblElever = new HashSet<TblElever>();
        }

        public int KlassId { get; set; }
        public string Klassnamn { get; set; }

        public virtual ICollection<TblElever> TblElever { get; set; }
    }
}
