using ClientOrganizer.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ClientOrganizer.DataAccess
{
    public class ClientOrganizerDbContext : DbContext
    {
        public ClientOrganizerDbContext() : base("ClientOrganizerDb")
        {

        }

        public DbSet<Client> Clients { get; set; }

        // Ef automatically pluralizes the table names, but we want the data table names to be singular 
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Client>()
            .Property(f => f.RegistrationDate)
            .HasColumnType("date");

            modelBuilder.Entity<Client>()
                .Property(x => x.PartyId)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
}
