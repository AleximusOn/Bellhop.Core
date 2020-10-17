using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Bellhop.Core.Models
{
	public class Account : IdentityUser<Guid>
	{
		public ICollection<ChanelMember> Chanels { get; set; }
	}
}
