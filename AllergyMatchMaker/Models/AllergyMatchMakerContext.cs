using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace AllergyMatchMaker.Models
{
    public class AllergyMatchMakerContext : IdentityDbContext<ApplicationUser>
    { 
      public AllergyMatchMakerContext(DbContextOptions<AllergyMatchMakerContext> options) 
        : base(options) {  }

      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
      {
        // optionsBuilder.UseLazyLoadingProxies();
      }
    }
}