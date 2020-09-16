using System;

namespace Api.Utilities
{
    public class MathUtility
    {
        public static bool IsPrimeNumber(int num)
        {
            if (num <= 1) return false;
            var limit = Math.Sqrt(num);

            for (int i = 2; i <= limit; i++)
                if (num % i == 0) return false;

            return true;
        }

        public static int FindNextPrimeNumber(int num)
        {
            while (true)
            {
                if (IsPrimeNumber(num)) return num;
                num++;
            }
        }
    }
}