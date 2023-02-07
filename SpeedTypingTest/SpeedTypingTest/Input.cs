using System;

namespace SpeedTypingTest
{
    static class Input
    {
        public static char GetUserChar()
        {
            return Console.ReadKey(true).KeyChar;
        }

    }
}