namespace EksamenWApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Room")]
    public partial class RoomDB
    {
        
        public RoomData()
        {
            Requests = new HashSet<RequestDB>();
        }

        public int Room_No { get; set; }

        public int RoomId { get; set; }

        public int Building_No { get; set; }

        [Required]
        [StringLength(30)]
        public string Room_Type { get; set; }

      
        public virtual ICollection<RequestDB> Requests { get; set; }
    }
}