using Application.Contracts.Persistence;
using Application.Features.Ideas;
using Application.Features.Ideas.Commands.CreateIdea;
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

namespace IdeasSharing.Application.UnitTests.Ideas.Queries
{
	public class GetIdeasListQueryHandlerTests
	{
		private readonly IMapper _mapper;
		private readonly Mock<IIdeaRepository> _mockIdeaRepository;

		public GetIdeasListQueryHandlerTests()
		{
			_mockIdeaRepository = RepositoryMocks.GetIdeaRepository();
			var configurationProvider = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile<MappingProfile>();
			});

			_mapper = configurationProvider.CreateMapper();
		}

		[Fact]
		public async Task Handle_GetIdeasList()
		{
			// Arrange
			var handler = new GetIdeasListQueryHandler(_mapper, _mockIdeaRepository.Object);

			// Act
			var allIdeas = await handler.Handle(new GetIdeasListQuery(), CancellationToken.None);

			// Assert
			allIdeas.Count.ShouldBe(2);
		}
	}
}
