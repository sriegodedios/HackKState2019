using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace APICompilerProject
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        public string PythonInterpreter(int x, int y)
        {
            string pythonInterpreter = @"C:\ProgramData\Microsoft\Windows\Start Menu\Programs\Python 3.7";
            string fileName = "test.py";
            //int x = 2;
            //int y = 5;

            ProcessStartInfo start = new ProcessStartInfo(fileName);
            start.UseShellExecute = false;
            start.RedirectStandardOutput = true;
            start.Arguments = fileName + " " + x + " " + y;

            Process process = new Process();
            process.StartInfo = start;
            process.Start();

            StreamReader stream = process.StandardOutput;
            string result = stream.ReadLine();
            return result;
        }
    }
}
