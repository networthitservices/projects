using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;
using networthitservices.models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json.Serialization;

namespace networthitservices.api
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
            // Add framework services.
            //services.AddDbContext<networthitservicesContext>(options => options.UseSqlServer("Server=localhost;Database=networthitservices;Trusted_Connection=True;MultipleActiveResultSets=true;User ID=sa;Password=okpuno"));
            services.AddDbContext<NetworthitservicesContext>(options => options.UseSqlServer(Configuration.GetConnectionString("NetWorthITServDB")));

            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new DefaultContractResolver()); ;
            //services.AddCors();
            services.AddCors(options => options.AddPolicy("Cors",
            builder =>
            {
                builder.
                AllowAnyOrigin().
                AllowAnyMethod().
                AllowAnyHeader();
            }));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors( options => options.WithOrigins("http://localhost:9000").AllowAnyMethod());
            app.UseMvc();
        }
    }
}
