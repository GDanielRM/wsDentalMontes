using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using wsDentalMontes.Model;

namespace wsDentalMontes.Contexts
{
    public partial class DBDataContext:DbContext
    {
        public DBDataContext() { }

        public DBDataContext(DbContextOptions<DBDataContext> options)
            :base(options)
        { }

        public DbSet<StatusEntity> Status { get; set; }
        public DbSet<PatientEntity> Patient { get; set; }
        public DbSet<PersonEntity> Person { get; set; }
        public DbSet<CityEntity> City { get; set; }
        public DbSet<NeighborhoodEntity> Neighborhood { get; set; }
        public DbSet<StreetEntity> Street { get; set; }
        public DbSet<PhoneNumberEntity> PhoneNumber { get; set; }
        public DbSet<PhoneNumberTypeEntity> PhoneNumberType { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = GetConfiguration();
                //optionsBuilder.UseSqlServer(configuration.GetSection("Connection").GetSection("ConnectionString").Value);
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\LOCAL_DANIEL;Initial Catalog=DentalMontes;Integrated Security=True;User ID=sa;Password=Rhaegal0423");
            }
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
