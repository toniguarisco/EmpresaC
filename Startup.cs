using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiRestDesarrollo.Business.Implementations;
using ApiRestDesarrollo.Business.Interface;
using ApiRestDesarrollo.Data;
using ApiRestDesarrollo.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;


namespace ApiRestDesarrollo
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
            byte[] llave = Encoding.UTF8.GetBytes("PASAREMODEARROLLOCAPAZQUIENABE");
            //services.AddDbContextPool<postgresContext>(options =>
            //{
            //    options.UseNpgsql(Configuration["Data:ConnectionString"]);
            //});
            services.AddDbContext<postgresContext>(options =>
            options.UseNpgsql(Configuration["Data:ConnectionString"]));
            services.AddControllers();
            services.AddScoped<IcommanderRepo, SqlComander>();
            services.AddScoped<IUsuarios, UsuarioImplementation>();
            services.AddScoped<IMonedero, MonederoImplementacion>();
            services.AddScoped<IPost, PostImplementacion>();
            services.AddScoped<IPortal, PortalImplementation>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSwaggerGen();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
            opt => opt.TokenValidationParameters = new TokenValidationParameters { 
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = "ucab.com",
                ValidAudience = "ucab.com",
                IssuerSigningKey = new SymmetricSecurityKey(llave),
                ClockSkew = TimeSpan.Zero
            } );

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseAuthentication();
        }
    }
}
