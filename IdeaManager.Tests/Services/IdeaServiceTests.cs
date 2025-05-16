using Xunit;
using Moq;
using IdeaManager.Core.Entities;
using IdeaManager.Core.Services; 

namespace IdeaManager.Tests.Services
{
    public class IdeaServiceTests
    {
        [Fact]
        public void AddIdea_ValidIdea_CallsRepositoryAddAndReturnsTrue()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Idea>>();
            var service = new IdeaService(mockRepo.Object);
            var idea = new Idea { Title = "Nouvelle idée", Description = "Description" };

            // Act
            var result = service.AddIdea(idea);

            // Assert
            Assert.True(result);
            mockRepo.Verify(r => r.Add(It.Is<Idea>(i => i.Title == "Nouvelle idée")), Times.Once);
        }

        [Fact]
        public void AddIdea_EmptyTitle_DoesNotCallRepositoryAddAndReturnsFalse()
        {
            // Arrange
            var mockRepo = new Mock<IRepository<Idea>>();
            var service = new IdeaService(mockRepo.Object);
            var idea = new Idea { Title = "", Description = "Description" };

            // Act
            var result = service.AddIdea(idea);

            // Assert
            Assert.False(result);
            mockRepo.Verify(r => r.Add(It.IsAny<Idea>()), Times.Never);
        }
    }
}
