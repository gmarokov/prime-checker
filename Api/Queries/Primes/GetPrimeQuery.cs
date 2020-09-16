using MediatR;

namespace Api.Queries.Primes
{
    public class GetPrimeQuery : IRequest<Result<GetPrimeResponse>>
    {
        public int Number { get; set; }
    }
}