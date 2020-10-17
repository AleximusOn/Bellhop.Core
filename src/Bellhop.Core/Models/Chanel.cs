using System;
using System.Collections.Generic;

namespace Bellhop.Core.Models
{
	public class Chanel : BaseEntity
	{
		public string Name { get; set; }

		public string SysName { get; set; }

		public ICollection<ChanelMember> Members { get; set; } = new List<ChanelMember>();
	}
}
