using Application.Contracts.Persistence;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class IdeaRepository : BaseRepository<Idea>, IIdeaRepository
	{
		public IdeaRepository(IdeasSharingDbContext dbContext) : base(dbContext)
		{
		}

		public Task<bool> IsIdeaNameAndDescriptionUnique(string name, string? description)
		{
			if (description == null) 
			{
				var nameMatches = _dbContext.Ideas.Any(i => i.Name == name);
				return Task.FromResult(nameMatches);
			}

			var nameAndDescriptionMatches = _dbContext.Ideas.Any(i => i.Name == name && i.Description == description);
			return Task.FromResult(nameAndDescriptionMatches);
		}
	}
}
