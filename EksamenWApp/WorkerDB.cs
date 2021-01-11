namespace EksamenWApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Worker")]
    public partial class WorkerDB
    {

        public int WorkerId { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkerName { get; set; }

        [Required]
        [StringLength(50)]
        public string WorkerProf { get; set; }

        
        public virtual ICollection<RequestDB> Requests { get; set; }
    }
}
