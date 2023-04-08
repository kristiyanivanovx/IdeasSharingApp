namespace App.ViewModels
{
	public class CategoryIdeasViewModel
	{
		public Guid CategoryId { get; set; }

		public string Name { get; set; } = string.Empty;

		public ICollection<IdeaNestedViewModel>? Ideas { get; set; }
	}
}
