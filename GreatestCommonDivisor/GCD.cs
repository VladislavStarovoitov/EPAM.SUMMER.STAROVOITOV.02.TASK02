using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace GreatestCommonDivisor
{
    public static class GCD
    {
        public static long EuclideanECDWithTime(out int result, int a, int b)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            result = EuclideanECD(a, b);
            time.Stop();
            return time.ElapsedTicks;
        }

        public static long EuclideanECDWithTime(out int result, int a, int b, int c)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            result = EuclideanECD(a, b);
            result = EuclideanECD(result, c);
            time.Stop();
            return time.ElapsedTicks;
        }

        public static long EuclideanECDWithTime(out int result, params int[] numbers)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = EuclideanECD(result, numbers[i]);
            }
            time.Stop();
            return time.ElapsedTicks;
        }

        public static long BinaryGCDWithTime(out int result, int a, int b)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            result = BinaryGCD(a, b);
            time.Stop();
            return time.ElapsedTicks;
        }

        public static long BinaryGCDWithTime(out int result, int a, int b, int c)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            result = BinaryGCD(a, b);
            result = BinaryGCD(result, c);
            time.Stop();
            return time.ElapsedTicks;
        }

        public static long BinaryGCDWithTime(out int result, params int[] numbers)
        {
            System.Diagnostics.Stopwatch time = new System.Diagnostics.Stopwatch();
            time.Start();
            result = numbers[0];
            for (int i = 1; i < numbers.Length; i++)
            {
                result = BinaryGCD(result, numbers[i]);
            }
            time.Stop();
            return time.ElapsedTicks;
        }

        private static int EuclideanECD(int a, int b)
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

        private static int BinaryGCD(int a, int b)
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

        private static void Swap(ref int left, ref int right)
        {
            int temp;
            temp = left;
            left = right;
            right = temp;
        }
    }
}
