using ClientOrganizer.Model;
using System;
using System.Data.Entity.Migrations;

namespace ClientOrganizer.DataAccess.Migrations
{

    internal sealed class Configuration : DbMigrationsConfiguration<ClientOrganizer.DataAccess.ClientOrganizerDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ClientOrganizer.DataAccess.ClientOrganizerDbContext context)
        {
            context.Clients.AddOrUpdate(c => c.PartyId,
                new Client
                {
                    PartyId = 369388,
                    PartyCode = 20781886,
                    FullName = " John Smith",
                    TaxCode = 0105984470125,
                    CountryCode = "MKD",
                    RegistrationDate = new DateTime(2000,01,01),
                    ClientType = "Физички лица"
                },
                new Client
                {
                    PartyId = 369389,
                    PartyCode = 20781887,
                    FullName = " Jan Gates",
                    TaxCode = 0105984470128,
                    CountryCode = "MKD",
                    RegistrationDate = new DateTime(1999,01,02),
                    ClientType = "Физички лица"
                }
            );
        }
    }
}
