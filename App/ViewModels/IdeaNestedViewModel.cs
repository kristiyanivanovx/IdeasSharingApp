namespace App.ViewModels
{
	public class IdeaNestedViewModel
	{
		public Guid IdeaId { get; set; }

		public string Name { get; set; } = string.Empty;

		public string? Description { get; set; }

		public DateTime CreatedDate { get; set; }

		public Guid CategoryId { get; set; }
	}
}
