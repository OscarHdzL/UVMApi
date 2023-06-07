using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Datos.Contexto
{
    //public  class ApplicationDbContext: DbContext
    //{
    //    public ApplicationDbContext(DbContextOptions options) : base(options)
    //    {

    //    }


    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        if (!optionsBuilder.IsConfigured)
    //        {
    //            IConfigurationRoot Configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    //                                               .AddJsonFile("appsettings.json", optional: false).Build();
    //            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("LibroFimpes"));
    //        }
    //    }
    //}

}
