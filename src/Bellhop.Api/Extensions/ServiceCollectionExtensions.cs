using System;
using Bellhop.Core.Models;
using Bellhop.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bellhop.Api.Extensions
{
	public static class ServiceCollectionExtensions
	{
		public static void AddContext(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<AppDbContext>(o =>
				o.UseNpgsql(configuration.GetConnectionString("default")));

			services.AddIdentity<Account, IdentityRole<Guid>>()
				.AddEntityFrameworkStores<AppDbContext>()
				.AddDefaultTokenProviders();
		}
	}
}
