using Bellhop.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bellhop.Data
{
	public partial class AppDbContext : IdentityDbContext<Account, IdentityRole<Guid>, Guid>
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);

			ConfigureEntities(builder);
		}

		public DbSet<Chanel> Chanels { get; set; }

		public DbSet<Message> Messages { get; set; }

		public DbSet<ChanelMember> ChanelMembers { get; set; }
	}
}
