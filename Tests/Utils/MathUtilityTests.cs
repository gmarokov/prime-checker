using System.Collections.Generic;
using System.IO;
using Api.Utilities;
using Xunit;

namespace Tests.Utils
{
    public class MathUtilityTests
    {
        [Fact]
        public void IsPrimeNumber_Returns_True_ForKnownPrimeNumbers()
        {
            string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            var listOfKnownPrimes = File.ReadAllLines($"{projectPath}/Resources/primes-to-100k.txt");

            foreach (var num in listOfKnownPrimes)
            {
                //Arrange & Act
                var isPrime = MathUtility.IsPrimeNumber(int.Parse(num));

                //Assert
                Assert.True(isPrime);
            };
        }

        [Theory]
        [MemberData(nameof(ListOfNextPrimeNumbers))]
        public void FindNextPrimeNumber_Returns_NextPrimeNumber_ForKnownNumbers(int number, int nextPrime)
        {
            //Arrange & Act
            var next = MathUtility.FindNextPrimeNumber(number);

            //Assert
            Assert.True(next == nextPrime);
        }

        public static IEnumerable<object[]> ListOfNextPrimeNumbers =>
            new List<object[]>
            {
                new object[] { 4, 5 },
                new object[] { 6, 7 },
                new object[] { 8, 11 },
                new object[] { 9, 11 },
                new object[] { 10, 11 },
                new object[] { 15, 17 },
                new object[] { 21, 23 },
                new object[] { 26, 29 },
                new object[] { 35, 37 },
                new object[] { 42, 43 },
                new object[] { 55, 59 },
                new object[] { 65, 67 }
            };
    }
}