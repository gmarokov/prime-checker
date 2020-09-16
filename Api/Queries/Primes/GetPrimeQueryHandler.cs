using System.Threading;
using System.Threading.Tasks;
using Api.Utilities;
using MediatR;

namespace Api.Queries.Primes
{
    public class GetPrimeQueryHandler : IRequestHandler<GetPrimeQuery, Result<GetPrimeResponse>>
    {
        public async Task<Result<GetPrimeResponse>> Handle(GetPrimeQuery request, CancellationToken cancellationToken)
        {
            var nextPrime = MathUtility.FindNextPrimeNumber(request.Number);
            var result = new GetPrimeResponse()
            {
                IsGivenNumberPrime = nextPrime == request.Number,
                NextPrimeNumber = nextPrime
            };

            return await Task.Run(() => Result<GetPrimeResponse>.Success(result));
        }
    }
}