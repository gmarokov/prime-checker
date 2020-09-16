using System.Threading;
using System.Threading.Tasks;
using Api.Queries.Primes;
using Xunit;

namespace Tests.Queries
{
    public class GetPrimeQueryHandlerTests
    {
        [Fact]
        public async Task Handler_Returns_SuccessResult()
        {
            //Arrange
            var sut = new GetPrimeQueryHandler();

            //Act
            var result = await sut.Handle(new GetPrimeQuery { Number = 1 }, new CancellationToken());

            //Assert
            Assert.NotNull(result);
            Assert.True(result.WasSuccessful);
            Assert.False(result.Value.IsGivenNumberPrime);
            Assert.Equal(2, result.Value.NextPrimeNumber);
        }
    }
}