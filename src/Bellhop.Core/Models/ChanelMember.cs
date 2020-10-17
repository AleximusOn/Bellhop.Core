using System;

namespace Bellhop.Core.Models
{
	public class ChanelMember
	{
		public Guid ChanelId { get; set; }

		public Chanel Chanel { get; set; }

		public Guid MemberId { get; set; }

		public Account Member { get; set; }

	}
}
