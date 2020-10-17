using Bellhop.Core.Enums;
using System;
using System.Collections.Generic;

namespace Bellhop.Core.Models
{
	public class Message : BaseEntity
	{
		public DateTime CreationDate { get; set; }
		
		public Guid AuthorId { get; set; }
		
		public Account Author { get; set; }

		public string Text { get; set; }

		public ContentTypeEnum ContentType { get; set; }

		public ICollection<Chanel> Chanels { get; set; } = new List<Chanel>();
	}
}
