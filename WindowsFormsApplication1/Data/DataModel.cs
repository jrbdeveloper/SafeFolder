namespace SafeFolder.Data
{
    using System.Data.Entity;

    public partial class DataModel : DbContext
    {
        public DataModel()
            : base("name=DataModel")
        {
        }

        public virtual DbSet<AddressBook> AddressBooks { get; set; }
        public virtual DbSet<Configuration> Configurations { get; set; }
        public virtual DbSet<FileRecipient> FileRecipients { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<OwnerProfile> OwnerProfiles { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<AddressBook>()
        //        .Property(e => e.EmailAddress)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<AddressBook>()
        //        .HasMany(e => e.FileRecipients)
        //        .WithRequired(e => e.AddressBook)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<Configuration>()
        //        .Property(e => e.Name)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Configuration>()
        //        .Property(e => e.LocalFilePath)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<Configuration>()
        //        .Property(e => e.ServicePath)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<File>()
        //        .Property(e => e.Name)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<File>()
        //        .Property(e => e.Path)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<File>()
        //        .HasMany(e => e.FileRecipients)
        //        .WithRequired(e => e.File)
        //        .WillCascadeOnDelete(false);

        //    modelBuilder.Entity<OwnerProfile>()
        //        .Property(e => e.FirstName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<OwnerProfile>()
        //        .Property(e => e.LastName)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<OwnerProfile>()
        //        .Property(e => e.EmailAddress)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<OwnerProfile>()
        //        .Property(e => e.Password)
        //        .IsUnicode(false);

        //    modelBuilder.Entity<OwnerProfile>()
        //        .HasMany(e => e.Configurations)
        //        .WithRequired(e => e.OwnerProfile)
        //        .WillCascadeOnDelete(false);
        //}
    }
}
