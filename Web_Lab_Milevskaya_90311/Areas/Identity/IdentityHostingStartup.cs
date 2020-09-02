﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Web_Lab_Milevskaya_90311.DAL.Data;
using Web_Lab_Milevskaya_90311.DAL.Entities;

[assembly: HostingStartup(typeof(Web_Lab_Milevskaya_90311.Areas.Identity.IdentityHostingStartup))]
namespace Web_Lab_Milevskaya_90311.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}