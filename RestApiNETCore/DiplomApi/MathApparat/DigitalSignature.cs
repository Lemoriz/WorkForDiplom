namespace DiplomApi.MathApparat
{
    using System;
    using System.Collections.Generic;

    using System.Numerics;

    internal class DigitalSignature
    {
        char[] characters = new char[] { '#', '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', '-' };

        /// <summary>
        /// Проверка на простое число.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public bool IsTheNumberSimple(long n)
        {
            if (n < 2)
                return false;

            if (n == 2)
                return true;

            for (long i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        /// <summary>
        /// RSA шифрование.
        /// </summary>
        /// <param name="hash"></param>
        /// <param name="e"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<string> RSA_Endoce(byte[] hash, long e, long n)
        {
            List<string> result = new List<string>();

            BigInteger bi;

            for (int i = 0; i < hash.Length; i++)
            {
                bi = new BigInteger(hash[i]);
                bi = BigInteger.Pow(bi, (int)e);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                result.Add(bi.ToString());
            }

            return result;
        }

        /// <summary>
        /// RSA расшифровка.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="d"></param>
        /// <param name="n"></param>
        /// <returns></returns>
        public List<string> RSA_Dedoce(List<string> input, long d, long n)
        {
            List<string> result = new List<string>();

            BigInteger bi;

            foreach (string item in input)
            {

                bi = new BigInteger(Convert.ToDouble(item));
                bi = BigInteger.Pow(bi, (int)d);

                BigInteger n_ = new BigInteger((int)n);

                bi = bi % n_;

                result.Add(bi.ToString());
            }

            return result;
        }

        /// <summary>
        /// Вычисление параметра d, d должно быть взаимно простым с m.
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        public long Calculate_d(long m)
        {
            long d = m - 1;

            for (long i = 2; i <= m; i++)
                if ((m % i == 0) && (d % i == 0)) //если имеют общие делители
                {
                    d--;
                    i = 1;
                }

            return d;
        }

        /// <summary>
        /// Вычисление параметра е.
        /// </summary>
        /// <param name="d"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public long Calculate_e(long d, long m)
        {
            long e = 10;

            while (true)
            {
                if ((e * d) % m == 1)
                    break;
                else
                    e++;
            }

            return e;
        }
    }
}
