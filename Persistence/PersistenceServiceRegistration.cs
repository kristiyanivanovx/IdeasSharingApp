using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;

namespace Persistence
{
	public static class PersistenceServiceRegistration
	{
		public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddDbContext<IdeasSharingDbContext>(options =>
				options.UseSqlServer(
					configuration.GetConnectionString("IdeasSharingConnectionString")));

			services.AddScoped(typeof(IAsyncRepository<>), typeof(BaseRepository<>));
			services.AddScoped<ICategoryRepository, CategoryRepository>();
			services.AddScoped<IIdeaRepository, IdeaRepository>();
			services.AddScoped<ILikeRepository, LikeRepository>();

			return services;
		}
	}
}
