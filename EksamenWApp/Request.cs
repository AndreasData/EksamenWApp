

namespace EksamenWApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Request")]
    public partial class RequestDB
    {
        public int RequestId { get; set; }

        public int? RoomId { get; set; }

        public int? WorkerId { get; set; }

        [Required]
        [StringLength(50)]
        public string Requestinfo { get; set; }

        public virtual RoomDB Room { get; set; }

        public virtual WorkerDB Worker { get; set; }
    }
}
