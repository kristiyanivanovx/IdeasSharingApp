using Application.Contracts.Persistence;
using Application.Features.Ideas;
using Application.Features.Ideas.Commands.DeleteIdea;
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
using Xunit;

namespace IdeasSharing.Application.UnitTests.Ideas.Commands
{
	public class DeleteIdeaCommandHandlerTests
	{
		private readonly IMapper _mapper;
		private readonly Mock<IIdeaRepository> _mockIdeaRepository;

		public DeleteIdeaCommandHandlerTests()
		{
			_mockIdeaRepository = RepositoryMocks.GetIdeaRepository();
			var configurationProvider = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MappingProfile>();
			});

			_mapper = configurationProvider.CreateMapper();
		}

		[Fact]
		public async Task Handle_ValidIdea_Deleted()
		{
			// Arrange
			var handler = new DeleteIdeaCommandHandler(_mapper, _mockIdeaRepository.Object);

			var developmentAppGuid = Guid.Parse("{489c3a8c-915a-44e4-8eb1-3877d21f6d7e}");

			// Act
			await handler.Handle(new DeleteIdeaCommand() { IdeaId = developmentAppGuid }, CancellationToken.None);

			var allIdeas = await _mockIdeaRepository.Object.GetListAllAsync();

			// Assert
			allIdeas.Count.ShouldBe(1);
		}
	}
}
