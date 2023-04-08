using Api.Middleware;
using Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.OpenApi.Models;
using Persistence;

namespace Api
{
	public static class StartupExtensions
	{
		public static WebApplication ConfigureServices(this WebApplicationBuilder builder)
		{
			AddSwagger(builder.Services);

			builder.Services.AddApplicationServices();
			builder.Services.AddPersistenceServices(builder.Configuration);

			builder.Services.AddControllers();
			builder.Services.AddCors(options =>
			{
				options.AddPolicy("Open", builder =>
					builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
			});

			return builder.Build();
		}

		public static WebApplication ConfigurePipeline(this WebApplication app)
		{
			if (app.Environment.IsDevelopment())
			{
				// reset database in dev environment
				//app.ResetDatabaseAsync().GetAwaiter().GetResult();

				app.UseSwagger();
				app.UseSwaggerUI(config =>
				{
					config.SwaggerEndpoint("/swagger/v1/swagger.json", "Ideas Sharing API");
				});
			}

			app.UseHttpsRedirection();
			
			app.UseRouting();

			app.UseCustomExceptionHandler();

			app.UseCors("Open");

			app.MapControllers();

			return app;
		}

		public static async Task ResetDatabaseAsync(this WebApplication app)
		{
			using var scope = app.Services.CreateScope();

			try
			{
				var context = scope.ServiceProvider.GetService<IdeasSharingDbContext>();
				if (context != null)
				{
					await context.Database.EnsureDeletedAsync();
					await context.Database.MigrateAsync();
				}
			}
			catch (Exception ex)
			{

				// add logging
				Console.WriteLine(ex.ToString());
			}
		}

		private static void AddSwagger(IServiceCollection services)
		{
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo
				{
					Version = "v1",
					Title = "Ideas Sharing API",
				});
			});
		}
	}
}
