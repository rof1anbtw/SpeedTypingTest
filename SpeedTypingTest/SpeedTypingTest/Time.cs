﻿using System;
using System.Diagnostics;

namespace SpeedTypingTest
{
    class Time
    {
        Stopwatch stopwatch = new Stopwatch();
        int nbWordsTyped;

        public void Start()
        {
            stopwatch.Start();
        }

        public void Stop()
        {
            stopwatch.Stop();
        }

        public int GetTimeElapsedInSeconds()
        {
            return (int)stopwatch.Elapsed.TotalSeconds;
        }

        public float GetTimeElapsedInMinutes()
        {
            return GetTimeElapsedInSeconds() / 60f;
        }
    }
}