using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GreatestCommonDivisor
{
    /// <summary>
    /// Provides static methods that compute greater common divisor
    /// </summary>
    public static class GCD
    {
        /// <summary>
        /// Computes greater common divisor by Euclid algorithm
        /// </summary>
        /// <param name="a">first number</param>
        /// <param name="b">second number</param>
        /// <returns>Greater common divisor</returns>
        public static int EuclideanGCD(int a, int b)
        {
            a = a < 0 ? -a : a;
            b = b < 0 ? -b : b;
            if (b > a)
            {
                Swap(ref a, ref b);
            }
            while (b != 0)
            {
                a = a % b;
                Swap(ref a, ref b);
            }
            return a;
        }

        /// <summary>
        /// Computes greater common divisor by Euclid algorithm
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="c">Third number</param>
        /// <returns>Greater common divisor</returns>
        public static int EuclideanGCD(int a, int b, int c)
        {
            int result = EuclideanGCD(a, b);
            result = EuclideanGCD(result, c);
            return result;
        }

        /// <summary>
        /// Computes greater common divisor by Euclid algorithm
        /// </summary>
        /// <param name="numbers">Array of numbers</param>
        /// <returns>Greater common divisor</returns>
        public static int EuclideanGCD(params int[] numbers)
        {
            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = EuclideanGCD(result, numbers[i]);
            }
            return result;
        }

        /// <summary>
        /// Computes greater common divisor by Euclid algorithm and counts ticks
        /// </summary>
        /// <param name="timeTicks">The variable that stores the ticks of the method execution</param>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greater common divisor</returns>
        public static int EuclideanGCDWithTime(out long timeTicks, int a, int b)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            int result = EuclideanGCD(a, b);
            time.Stop();
            timeTicks = time.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Computes greater common divisor by Euclid algorithm and counts ticks
        /// </summary>
        /// <param name="timeTicks">The variable that stores the ticks of the method execution</param>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <param name="c">Third number</param>
        /// <returns>Greater common divisor</returns>
        public static int EuclideanGCDWithTime(out long timeTicks, int a, int b, int c)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            var result = EuclideanGCD(a, b, c);
            time.Stop();
            timeTicks = time.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Computes greater common divisor by Euclid algorithm and counts ticks
        /// </summary>
        /// <param name="timeTicks">The variable that stores the ticks of the method execution</param>
        /// <param name="numbers">Array of numbers</param>
        /// <returns>Greater common divisor</returns>
        public static int EuclideanGCDWithTime(out long timeTicks, params int[] numbers)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            int result = EuclideanGCD(numbers);
            time.Stop();
            timeTicks = time.ElapsedTicks;
            return result;
        }

        /// <summary>
        /// Computes greater common divisor by binary Euclid algorithm
        /// </summary>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greater common divisor</returns>
        public static int BinaryGCD(int a, int b)
        {
            a = a < 0 ? -a : a;
            b = b < 0 ? -b : b;
            if (a == b || b == 0)
                return a;
            if (a == 0)
                return b;
            if ((a & 1) == 0)
            {
                if ((b & 1) == 1)
                    return BinaryGCD(a >> 1, b);
                else
                    return BinaryGCD(a >> 1, b >> 1) << 1;
            }
            if ((b & 1) == 0)
            {
                return BinaryGCD(a, b >> 1);
            }
            if (a > b)
                return BinaryGCD((a - b) >> 1, b);
            return BinaryGCD((b - a) >> 1, a);
        }

        public static int BinaryGCD(int a, int b, int c)
        {
            int result = BinaryGCD(a, b);
            result = BinaryGCD(result, c);
            return result;
        }

        public static int BinaryGCD(params int[] numbers)
        {
            int result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = BinaryGCD(result, numbers[i]);
            }
            return result;
        }

        /// <summary>
        /// Computes greater common divisor by binary Euclid algorithm and counts tick
        /// </summary>
        /// <param name="timeTicks">The variable that stores the ticks of the method execution</param>
        /// <param name="a">First number</param>
        /// <param name="b">Second number</param>
        /// <returns>Greater common divisor</returns>
        public static int BinaryGCDWithTime(out long timeTicks, int a, int b)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            int result = BinaryGCD(a, b);
            time.Stop();
            timeTicks = time.ElapsedTicks;
            return result;
        }

        public static int BinaryGCDWithTime(out long timeTicks, int a, int b, int c)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            int result = BinaryGCD(a, b, c);
            time.Stop();
            timeTicks = time.ElapsedTicks;
            return result;
        }

        public static int BinaryGCDWithTime(out long timeTicks, params int[] numbers)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            int result = BinaryGCD(numbers);
            time.Stop();
            timeTicks = time.ElapsedTicks;
            return result;
        }

        private static void Swap(ref int left, ref int right)
        {
            int temp;
            temp = left;
            left = right;
            right = temp;
        }
    }
}
