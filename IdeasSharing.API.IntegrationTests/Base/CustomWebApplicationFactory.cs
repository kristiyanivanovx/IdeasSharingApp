﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeasSharing.API.IntegrationTests.Base
{
	public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
	{
		protected override void ConfigureWebHost(IWebHostBuilder builder)
		{
			builder.ConfigureServices(services =>
			{
				services.AddDbContext<IdeasSharingDbContext>(options =>
				{
					options.UseInMemoryDatabase("IdeasSharingDbContextInMemoryTest");
				});

				var sp = services.BuildServiceProvider();

				using (var scope = sp.CreateScope())
				{
					var scopedServices = scope.ServiceProvider;
					var context = scopedServices.GetRequiredService<IdeasSharingDbContext>();
					var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TProgram>>>();

					context.Database.EnsureCreated();

					try
					{
						Utilities.InitializeDbForTests(context);
					}
					catch (Exception ex)
					{
						logger.LogError(ex, $"An error occurred seeding the database with test messages. Error: {ex.Message}");
					}
				};
			});
		}

		public HttpClient GetAnonymousClient()
		{
			return CreateClient();
		}
	}
}
