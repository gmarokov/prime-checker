using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Api;
using Api.Controllers;
using Api.Queries.Primes;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Tests.Controllers
{
    public class PrimesControllerTests
    {
        private readonly Mock<IMediator> Mediator;

        public PrimesControllerTests()
        {
            Mediator = new Mock<IMediator>();
        }

        [Fact]
        public async Task Get_PrimeNumber_Returns_OkObjectResult_WithGetPrimeResponse()
        {
            //Arrange
            var expectedObj = new GetPrimeResponse()
            {
                IsGivenNumberPrime = It.IsAny<bool>(),
                NextPrimeNumber = It.IsAny<int>()
            };

            Mediator.Setup(x => x.Send(It.IsAny<GetPrimeQuery>(), new CancellationToken()))
                .ReturnsAsync(Result<GetPrimeResponse>.Success(expectedObj));

            var controller = new PrimesController(Mediator.Object);

            //Act
            var res = await controller.Get(1) as OkObjectResult;
            var contentObj = res.Value as Res<GetPrimeResponse>;

            //Assert
            Assert.True(res.StatusCode == 200);
            Assert.NotNull(contentObj);
            Assert.True(contentObj.WasSuccessful);
            Assert.NotNull(contentObj.Data);
        }

        [Fact]
        public async Task Get_PrimeNumber_Returns_BadRequestObjectResult_WithErrors()
        {
            //Arrange
            var errorsList = new List<string>()
            {
                "Unexpected error"
            };

            Mediator.Setup(x => x.Send(It.IsAny<GetPrimeQuery>(), new CancellationToken()))
                .ReturnsAsync(Result<GetPrimeResponse>.Fail(errorsList));

            var controller = new PrimesController(Mediator.Object);

            //Act
            var res = await controller.Get(1) as BadRequestObjectResult;
            var contentObj = res.Value as Res<GetPrimeResponse>;

            //Assert
            Assert.True(res.StatusCode == 400);
            Assert.NotNull(contentObj);
            Assert.False(contentObj.WasSuccessful);
            Assert.NotEmpty(contentObj.ErrorMessage);
            Assert.Equal(contentObj.ErrorMessage, errorsList.FirstOrDefault());
            Assert.Null(contentObj.Data);
        }
    }
}
