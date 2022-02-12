using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Gymnasieskola3
{
    public partial class TblKursSchema
    {
        public int KursSchemaId { get; set; }
        public int? FkursId { get; set; }
        public DateTime? KursStartdatum { get; set; }
        public DateTime? KursSlutdatum { get; set; }
    }
}
