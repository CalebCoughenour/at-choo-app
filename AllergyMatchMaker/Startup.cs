using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using AllergyMatchMaker.Models;
using System;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;

namespace AllergyMatchMaker.Solution
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

          services.AddDbContext<AllergyMatchMakerContext>(opt =>
              opt.UseMySql(Configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(Configuration["ConnectionStrings:DefaultConnection"])));
          services.AddControllers();
          
          services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<AllergyMatchMakerContext>()
            .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 0;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
            });
          //Swagger
          services.AddSwaggerGen(c=>
          {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
            Version = "v1",
            Title = "At'Choo User DB",
            Description ="Database for storing At'Choo users",
            Contact = new OpenApiContact
            {
              Name ="Meron G.Tekie, Caleb Coughenour, Mark McConnell, Marcus Lorenzo, Jake Edgar & Evgeniya Meshuris"
              // Email ="ramenimo@gmail.com"
            
              
            }
            });
          });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Enable middleware
            app.UseSwagger(c =>
            {
              c.SerializeAsV2 =true;

            });
            app.UseSwaggerUI(c =>
            {
              c.SwaggerEndpoint("/swagger/v1/swagger.json"," API V1");
              c.RoutePrefix = string.Empty;
            });

            // app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}