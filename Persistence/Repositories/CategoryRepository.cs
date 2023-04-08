using Application.Contracts.Persistence;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
	public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
	{
		public CategoryRepository(IdeasSharingDbContext dbContext) : base(dbContext)
		{
		}

		public async Task<List<Category>> GetAllCategoriesWithIdeas()
		{
			return await _dbContext.Set<Category>()
				.Include(p => p.Ideas)
				.ToListAsync();
		}
	}
}
