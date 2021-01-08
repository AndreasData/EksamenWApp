namespace EksamenWApp
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
            : base("name=DatabaseContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Worker> Workers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Request>()
                .Property(e => e.Requestinfo)
                .IsUnicode(false);

            modelBuilder.Entity<Room>()
                .Property(e => e.Room_Type)
                .IsUnicode(false);

            modelBuilder.Entity<Worker>()
                .Property(e => e.WorkerName)
                .IsUnicode(false);

            modelBuilder.Entity<Worker>()
                .Property(e => e.WorkerProf)
                .IsUnicode(false);
        }
    }
}
