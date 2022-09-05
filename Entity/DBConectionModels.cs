using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace wsDentalMontes.Model
{
    public class DBConectionModel
    {
        public SqlConnection conection;
        public DBConectionModel()
        {
            var configuration = GetConfiguration();
            conection = new SqlConnection(configuration.GetSection("Connection").GetSection("ConnectionString").Value);
        }

        public IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            return builder.Build();
        }
    }
}
