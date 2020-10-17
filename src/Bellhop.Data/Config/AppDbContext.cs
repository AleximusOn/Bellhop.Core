using Bellhop.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace Bellhop.Data
{
	public partial class AppDbContext
	{
		private void ConfigureEntities(ModelBuilder builder)
		{
			builder.HasDefaultSchema("Bellhop");

			#region Identity

			builder.Entity<Account>().ToTable("Accounts");
			builder.Entity<IdentityRole<Guid>>().ToTable("Roles");
			builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RolesClaims");
			builder.Entity<IdentityUserRole<Guid>>().ToTable("AccountsRoles");
			builder.Entity<IdentityUserLogin<Guid>>().ToTable("AccountLogins");
			builder.Entity<IdentityUserClaim<Guid>>().ToTable("AccountClaims");
			builder.Entity<IdentityUserToken<Guid>>().ToTable("AccountTokens");

			#endregion

			builder.Entity<ChanelMember>()
				.HasKey(cm => new { cm.ChanelId, cm.MemberId });
		}
	}
}
