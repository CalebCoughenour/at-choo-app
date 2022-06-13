using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AllergyMatchMaker.Models
{
  public class AllergyMatchMakerContextFactory : IDesignTimeDbContextFactory<AllergyMatchMakerContext>
  {
    AllergyMatchMakerContext IDesignTimeDbContextFactory<AllergyMatchMakerContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<AllergyMatchMakerContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new AllergyMatchMakerContext(builder.Options);
    }
  }
}