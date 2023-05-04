using hairSalonScheduler.Repositories;
using Microsoft.EntityFrameworkCore;

namespace hairSalonScheduler.Tests
{
    public class UserRepositoryTests
    {
        private async Task<SalonDbContext> GetDbContextAsync()
        {
            var options = new DbContextOptionsBuilder<SalonDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            var dbContext = new SalonDbContext(options);
            dbContext.Users.Add(new User { Id = 1, /* other properties */ });
            dbContext.Users.Add(new User { Id = 2, /* other properties */ });

            await dbContext.SaveChangesAsync();

            return dbContext;
        }

        [Fact]
        public async Task GetAllUsersAsync_ShouldReturnAllUsers()
        {
            // Arrange
            var dbContext = await GetDbContextAsync();
            var userRepository = new UserRepository(dbContext);

            // Act
            var users = await userRepository.GetAllUsersAsync();

            // Assert
            Assert.NotNull(users);
            Assert.Equal(2, users.Count());
        }

        // Add more tests for UserRepository methods...
    }
}