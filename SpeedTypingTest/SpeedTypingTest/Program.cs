using System;
using System.Threading;

namespace SpeedTypingTest
{
    class Program
    {
        Time time = new Time();
        LeaderBoard newName = new LeaderBoard();
        string randomPhrase;
        int currentUserIndex;
        int nbWords;
        static int nbMistakes;
        static string Name;
        static double timeEl;

        public static void Main(string[] args)
        {
            new Program().Start();
        }

        public void Start()
        {
            randomPhrase = Generator.GetRandomPhrase();
            BeforeStartPresentation();
            Countdown(3);
            Gameplay();
            EndingMessage();
            newName.JsonSave(nbMistakes,timeEl,Name);
        }

        private void BeforeStartPresentation()
        {
            Console.WriteLine("Текст для печати :\r\n");
            Console.WriteLine("\"" + randomPhrase + "\"");
            Console.WriteLine("Введите имя:");
            Name =  Console.ReadLine();
            Console.WriteLine("\r\nНажмите \"Enter\" чтобы начать");
            Console.ReadLine();
        }

        private void Countdown(int seconds)
        {
            Console.WriteLine(seconds);
            while (seconds > 0)
            {
                Thread.Sleep(1000);
                seconds--;
                Console.WriteLine(seconds);
            }
        }

        private void Gameplay()
        {
            time.Start();

            while (!UserHasWrittenAllThePhrase())
            {
                ShowUI();
                char userLetter = Input.GetUserChar();
                char currentLetter = randomPhrase[currentUserIndex];

                if (userLetter == currentLetter)
                {
                    currentUserIndex++;
                }
                else
                {
                    nbMistakes++;
                }
                CheckWordTyped();
            }

            time.Stop();
        }

        private bool UserHasWrittenAllThePhrase()
        {
            return currentUserIndex == randomPhrase.Length;
        }

        private void ShowUI()
        {
            Console.Clear();
            ShowTypingSpeed();
            ShowMistakes();
            ShowPhraseState();
        }

        private void ShowTypingSpeed()
        {
            double timeElapsed = (double)time.GetTimeElapsedInMinutes();
            timeEl= timeElapsed;
            double wpmSpeed = nbWords / timeElapsed;
            wpmSpeed = Math.Round(wpmSpeed);

            if (nbWords == 0)
            {
                Console.WriteLine($"0 c/м");
            }
            else
            {
                Console.WriteLine($"{wpmSpeed} с/м");
            }
            timeEl = timeElapsed;
        }

        private void ShowMistakes()
        {
            Console.WriteLine($"Кол-во ошибок: {nbMistakes}");
        }

        private void ShowPhraseState()
        {
            Console.WriteLine();
            if (currentUserIndex > 0)
            {
                string phraseCompleted = randomPhrase.Substring(0, currentUserIndex);
                Console.Write(phraseCompleted);
            }

            char currentLetter = randomPhrase[currentUserIndex];
            Color.WriteBackground(ConsoleColor.Red, Char.ToString(currentLetter));

            string phraseToBeCompleted = randomPhrase.Substring(currentUserIndex + 1);
            Console.WriteLine(phraseToBeCompleted);
        }

        private void CheckWordTyped()
        {
            if ((currentUserIndex != 0) && (currentUserIndex % 5 == 0))
            {
                nbWords++;
            }
        }

        private void EndingMessage()
        {
            Console.WriteLine("\r\nКонец !");
            Console.WriteLine($"Вы печатали {time.GetTimeElapsedInSeconds()} секунд(у)");
            Console.ReadLine();
        }
    }
}