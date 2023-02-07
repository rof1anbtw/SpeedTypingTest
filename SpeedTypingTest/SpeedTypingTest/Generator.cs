using System;

namespace SpeedTypingTest
{
    class Generator
    {
        public static string GetRandomPhrase()
        {
            string[] phrases = GetPhrases();

            Random rand = new Random();
            int phraseIndex = rand.Next(0, phrases.Length);

            return phrases[phraseIndex];
        }

        private static string[] GetPhrases()
        {
            string[] phrases = new string[]
            {
            "Вена Влет Горстка Десятерик Законсервировать Кибернетик Напалм Радиостанция Сочинитель Фельетон.",
            "Бал Галактика Золить Капельдинер Прорисовать Путеукладчик Скидать Частник Школьничать Шуруп.",
            "Американистика Выговориться Героичный Завладеть Запретить Канцер Насупиться Сбросить Электропроводка Эскалапия."
            };

            return phrases;
        }
    }
}