using Application.Contracts.Persistence;
using Application.Features.Ideas.Commands.DeleteIdea;
using Application.Features.Ideas.Commands.UpdateIdea;
using Application.Profiles;
using AutoMapper;
using IdeasSharing.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Xunit;

namespace IdeasSharing.Application.UnitTests.Ideas.Commands
{
	public class UpdateIdeaCommandHandlerTests
	{
		private readonly IMapper _mapper;
		private readonly Mock<IIdeaRepository> _mockIdeaRepository;

		public UpdateIdeaCommandHandlerTests()
		{
			_mockIdeaRepository = RepositoryMocks.GetIdeaRepository();
			var configurationProvider = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MappingProfile>();
			});

			_mapper = configurationProvider.CreateMapper();
		}

		[Fact]
		public async Task Handle_ValidIdea_Updated()
		{
			// Arrange
			var handler = new UpdateIdeaCommandHandler(_mapper, _mockIdeaRepository.Object);

			var developmentAppGuid = Guid.Parse("{489c3a8c-915a-44e4-8eb1-3877d21f6d7e}");

			var newIdeaName = "Some other name";

			var newIdeaDescription = "Some other description";

			var updateIdeaCommand = new UpdateIdeaCommand() { IdeaId = developmentAppGuid, Name = newIdeaName, Description = newIdeaDescription };

			// Act
			await handler.Handle(updateIdeaCommand, CancellationToken.None);

			var idea = await _mockIdeaRepository.Object.GetByIdAsync(developmentAppGuid);

			// Assert
			idea.Name.ShouldBe(newIdeaName);
			idea.Description.ShouldBe(newIdeaDescription);
		}
	}
}
