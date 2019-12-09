namespace banjiguanli.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ClassEntities : DbContext
    {
        public ClassEntities()
            : base("name=banjiguanli")
        {
        }

        public virtual DbSet<ActionLinks> ActionLinks { get; set; }
        public virtual DbSet<banji> banji { get; set; }
        public virtual DbSet<kechenganpai> kechenganpai { get; set; }
        public virtual DbSet<SideBars> SideBars { get; set; }
        public virtual DbSet<Stdent> Stdent { get; set; }
        public virtual DbSet<subject> subject { get; set; }
        public virtual DbSet<teacher> teacher { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ActionLinks>()
                .Property(e => e.Controller)
                .IsUnicode(false);

            modelBuilder.Entity<ActionLinks>()
                .Property(e => e.Action)
                .IsUnicode(false);

            modelBuilder.Entity<SideBars>()
                .Property(e => e.Controller)
                .IsUnicode(false);

            modelBuilder.Entity<SideBars>()
                .Property(e => e.Action)
                .IsUnicode(false);
        }
    }
}
