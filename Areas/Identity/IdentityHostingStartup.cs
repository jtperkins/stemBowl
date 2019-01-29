using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using stembowl.Areas.Identity.Data;

[assembly: HostingStartup(typeof(stembowl.Areas.Identity.IdentityHostingStartup))]
namespace stembowl.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<stembowlIdentityDbContext>(options =>
                    options.UseMySql(
                        context.Configuration.GetConnectionString("connectionString")));

                services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<stembowlIdentityDbContext>();
            });
        }
    }
}