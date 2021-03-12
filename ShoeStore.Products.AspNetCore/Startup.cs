using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShoeStore.Products.Infrastructure;

namespace ShoeStore.Products.AspNetCore
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
            //services.AddAuthentication("Bearer")
            //    .AddIdentityServerAuthentication("Bearer", options =>
            //    {
            //        options.ApiName = "productsAPI";
            //        options.Authority = "https://localhost:5001";
            //    });

            //services.AddCors(
            //    options => options.AddPolicy("shoestore-admin",
            //    builder => builder.AllowAnyOrigin()
            //                      .AllowAnyMethod()
            //                      .AllowAnyHeader()
            //));
            services.AddMvc();
            services.AddDbContext<ProductsDbContext>(options =>
            options.UseSqlServer(Configuration.GetValue<string>("ss-products-db-connection-string")));            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            //app.UseAuthentication();
            //app.UseAuthorization();
            //app.UseCors("shoestore-admin");           
            app.UseEndpoints(endpoints => endpoints.MapDefaultControllerRoute());
        }
    }
}
