using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gymnasieskola3.Models
{
    public partial class TblKursbetyg
    {
        public int KursbetygsId { get; set; }
        public int FkursId { get; set; }
        public int FpersonalId { get; set; }
        public int FelevId { get; set; }
        public int? Fbetyg { get; set; }
        public DateTime? KursStartdatum { get; set; }
        public DateTime? KursSlutdatum { get; set; }
        public DateTime? BetygsDatum { get; set; }

        public virtual TblBetyg FbetygNavigation { get; set; }
        public virtual TblElever Felev { get; set; }
        public virtual TblKurser Fkurs { get; set; }
        public virtual TblPersonal Fpersonal { get; set; }
    }
}
