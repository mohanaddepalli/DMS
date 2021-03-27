using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DocumentManagementDAL
{
  public partial class DMSEntities : DbContext
  {
    public DMSEntities()
        : base("name=DMSEntities")
    {
      Database.SetInitializer(new DMSDBInitializer());
    }

    public virtual DbSet<Document> Documents { get; set; }
    public virtual DbSet<Status> Status { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
      modelBuilder.Entity<Status>()
          .HasMany(e => e.Documents)
          .WithRequired(e => e.Status)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<Status>()
          .HasMany(e => e.Users)
          .WithRequired(e => e.Status)
          .WillCascadeOnDelete(false);

      modelBuilder.Entity<User>()
          .Property(e => e.Password)
          .IsFixedLength();

      modelBuilder.Entity<User>()
          .HasMany(e => e.Documents)
          .WithRequired(e => e.User)
          .WillCascadeOnDelete(false);
    }
  }
}
