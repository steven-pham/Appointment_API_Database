using AppointmentApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AppointmentApp.Data
{
    public class AppointmentContext : DbContext
    {
        // an empty constructor
        public AppointmentContext() { }

        // base(options) calls the base class's constructor,
        // in this case, our base class is DbContext
        public AppointmentContext(DbContextOptions<AppointmentContext> options) : base(options) { }

        // Use DbSet<Student> to query or read and 
        // write information about A Student
        public DbSet<Appointment> Appointment { get; set; }
        public static System.Collections.Specialized.NameValueCollection AppSettings { get; }

        // configure the database to be used by this context
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
           .AddJsonFile("appsettings.json")
           .Build();

            // schoolSIMSConnection is the name of the key that
            // contains the has the connection string as the value
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("AppointmentAppConnection"));
        }
    }
}
