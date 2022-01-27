using System;
using CHETUPROJECT.Data;
using CHETUPROJECT.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(CHETUPROJECT.Areas.Identity.IdentityHostingStartup))]
namespace CHETUPROJECT.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DataDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("DataDbContextConnection")));

                services.AddDefaultIdentity<AuthUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<DataDbContext>();
            });
        }
    }
}