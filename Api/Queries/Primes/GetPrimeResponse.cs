namespace Api.Queries.Primes
{
    public class GetPrimeResponse
    {
        /// <summary>
        /// If request number is prime or not
        /// </summary>
        /// <value>bool</value>
        public bool IsGivenNumberPrime { get; set; }

        /// <summary>
        /// The next prime number after the requested one
        /// </summary>
        /// <value>int</value>
        public int NextPrimeNumber { get; set; }
    }
}