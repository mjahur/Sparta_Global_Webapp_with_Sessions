namespace Social
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SocialModel : DbContext
    {
        public SocialModel()
            : base("name=SocialModel1")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Description> Descriptions { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
        public virtual DbSet<Universe> Universes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Description>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Description)
                .HasForeignKey(e => e.description_descriptionID);

            modelBuilder.Entity<Group>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Group)
                .HasForeignKey(e => e.group_groupID);

            modelBuilder.Entity<Universe>()
                .HasMany(e => e.Groups)
                .WithOptional(e => e.Universe)
                .HasForeignKey(e => e.universe_universeID);

            modelBuilder.Entity<Universe>()
                .HasMany(e => e.Users)
                .WithOptional(e => e.Universe)
                .HasForeignKey(e => e.universe_universeID);
        }
    }
}
