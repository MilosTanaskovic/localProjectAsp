using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiApp.Email;
using ApplicationLayer.Commands;
using ApplicationLayer.Interfaces;
using EfCommands;
using EfDataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace ApiApp
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<AspProjContext>();
            services.AddTransient<IGetCoursesCommand, EfGetCoursesCommand>();
            services.AddTransient<IGetCourseCommand, EfGetCourseCommand>();
            services.AddTransient<IAddCourseCommand, EfAddCourseCommand>();
            services.AddTransient<IEditCourseCommand, EfEditCourseCommand>();
            services.AddTransient<IDeleteCourseCommand, EfDeleteCourseCommand>();
            services.AddTransient<IGetStudentsCommand, EfGetStudentsCommand>();
            services.AddTransient<IGetStudentCommand, EfGetStudentCommand>();
            services.AddTransient<IAddStudentCommand, EfAddStudentCommand>();
            services.AddTransient<IEditStudentCommand, EfEditStudentCommand>();
            services.AddTransient<IDeleteStudentCommand, EfDeleteStudentCommand>();
            services.AddTransient<IGetTeachersCommand, EfGetTeachersCommand>();
            services.AddTransient<IGetTeacherCommand, EfGetTeacherCommand>();
            services.AddTransient<IDeleteTeacherCommand, EfDeleteTeacherCommand>();
            services.AddTransient<IAddTeacherCommand, EfAddTeacherCommand>();
            services.AddTransient<IEditTeacherCommand, EfEditTeacherCommand>();
            

            var section = Configuration.GetSection("Email");

            var sender = new SmtpEmailSender(section["host"], Int32.Parse(section["port"]), section["fromaddress"], section["password"]);

            services.AddSingleton<IEmailSender>(sender);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "AspProject", Version = "v1" });

            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                //c.RoutePrefix = string.Empty;
            });
        }
    }
}
