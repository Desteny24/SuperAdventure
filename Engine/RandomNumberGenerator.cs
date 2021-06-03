using System;
using System.Security.Cryptography;

namespace Engine
{
    public class RandomNumberGenerator
    {
        // Simple version, with less randomness.
        //
        // If you want to use this version, 
        // you can delete (or comment out) the NumberBetween function above,
        // and rename this from SimpleNumberBetween to NumberBetween
        private static readonly Random _simpleGenerator = new Random();

        public static int SimpleNumberBetween(int minimumValue, int maximumValue)
        {
            return _simpleGenerator.Next(minimumValue, maximumValue + 1);
        }

    }
}