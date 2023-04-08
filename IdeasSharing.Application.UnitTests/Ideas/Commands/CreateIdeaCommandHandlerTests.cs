using Application.Contracts.Persistence;
using Application.Features.Categories.Commands.CreateCategory;
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

namespace IdeasSharing.Application.UnitTests.Ideas.Commands
{
    public class CreateIdeaCommandHandlerTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IIdeaRepository> _mockIdeaRepository;

        public CreateIdeaCommandHandlerTests()
        {
            _mockIdeaRepository = RepositoryMocks.GetIdeaRepository();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfile>();
            });

            _mapper = configurationProvider.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidIdea_AddedToIdeasRepo()
        {
            // Arrange
            var handler = new CreateIdeaCommandHandler(_mapper, _mockIdeaRepository.Object);

			var financeCategoryGuid = Guid.Parse("{9095f861-9771-40d8-b761-9d9210ca7a26}");

            var command = new CreateIdeaCommand() { Name = "Test idea", Description = "123", CategoryId = financeCategoryGuid, CreatedDate = DateTime.Now };

			// Act
			await handler.Handle(command, CancellationToken.None);

            var allIdeas = await _mockIdeaRepository.Object.GetListAllAsync();

			// Assert
			allIdeas.Count.ShouldBe(3);
        }
    }
}
