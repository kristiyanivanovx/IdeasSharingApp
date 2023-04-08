using Domain.Common;

namespace Domain.Entities
{
	public class Idea : AuditableEntity
	{
		public Guid IdeaId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		public DateTime CreatedDate { get; set; }

		public Guid CategoryId { get; set; }

		public Category Category { get; set; }
	}
}