﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson5
      /*  Разработать класс Message, содержащий следующие статические методы для обработки текста:
        а) Вывести только те слова сообщения, которые содержат не более n букв.
        б) Удалить из сообщения все слова, которые заканчиваются на заданный символ.
        в) Найти самое длинное слово сообщения.
        г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        Продемонстрируйте работу программы на текстовом файле с вашей программой.
      */
{
    static class Message
    {
        static public string text;

        static Message()
        {
            text = "Никто никогда не видел лица, что скрыто за маской Юрнеро. Остаётся гадать, каков он на вид." +
                   "Однажды Юрнеро бросил вызов нечистому на руку лорду и был изгнан с древнего острова Масок." +
                   "Кара спасла ему жизнь: скорой ночью остров исчез под волнами, ведомыми мстительной магией." +
                   "Лишь Юрнеро отныне хранит обычаи острова: древние ритуалы и искусство боя на мечах." +
                   "Непоколебимость и мужество пришли к нему в нескончаемых упражнениях с клинком, а изобретательность в бою он укоренял," +
                   "неутомимо испытывая себя.";
        }

        /// <summary>Выводит слова сообщения, которые содержат не более n букв</summary>
        /// <param name="len">Длинна слова</param>
        static public void GetWordsByLength(int len)
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            //Console.WriteLine("Вывод слов, длинной не более " + len + ": " );
            foreach (string word in words)
            {
                if (word == "")
                    continue;
                if (word.Length <= len)
                    Console.Write(word + " ");
            }
        }

        /// <summary>Удаляет из сообщения все слова, которые заканчиваются на заданный символ</summary>
        /// <param name="ch">Символ для поиска слов</param>
        static public void DeleteWordByEndChar(char ch)
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            //Console.WriteLine("Будут удалены слова, оканчивающиеся на символ '" + ch + "': ");
            foreach (string word in words)
            {
                if (word == "")
                    continue;
                if (word[word.Length - 1] == ch)
                {
                    Console.Write(word + " ");
                    text.Replace(word, "");
                }
            }
            //Console.WriteLine("В результате работы метода, исходный текст изменился на: " + text);
        }

        /// <summary>Находит самое длинное слово сообщения</summary>
        /// <returns></returns>
        static public string FindMaxLengthWord()
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            string maxWord = words[0];
            int max = words[0].Length;

            foreach (string word in words)
            {
                if (word.Length > max)
                {
                    max = word.Length;
                    maxWord = word;
                }
            }
            //Console.WriteLine("Слово с самой большой длинной: " + maxWord);
            return maxWord;
        }

        /// <summary>Формирует строку StringBuilder из самых длинных слов сообщения</summary>
        /// <returns></returns>
        static public StringBuilder GetLongWordsString()
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            StringBuilder result = new StringBuilder();
            int max = Message.FindMaxLengthWord().Length;
            foreach (string word in words)
            {
                if (word.Length == max)
                {
                    result.Append(word.ToLower() + " ");
                }
            }
            //Console.WriteLine("Полученная строка самых длинных слов: " + result);
            return result;
        }

        /// <summary>Производит частотный анализ текста</summary>
        /// <param name="words">Массив слов</param>
        /// <param name="text">Текст</param>
        static public void FrequencyAnalysis(string[] words, string text)
        {
            Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

            string[] textWords = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            foreach (string word in words)
            {
                foreach (string wordInText in textWords)
                {
                    if (word == "")
                        continue;
                    if (wordInText == word)
                    {
                        if (word == "")
                            continue;
                        if (wordFrequency.ContainsKey(word))
                            wordFrequency[word] += 1;
                        else
                            wordFrequency.Add(word, 1);
                    }
                }
            }
            //Console.WriteLine("Частотный анализ текста дал следующий результат: ");
            ICollection<string> keys = wordFrequency.Keys;

            String result = String.Format("{0,-10} {1,-10}\n\n", "Слово", "Частота появления");

            foreach (string key in keys)
                result += String.Format("{0,-10} {1,-10:N0}\n",
                                   key, wordFrequency[key]);
            Console.WriteLine($"\n{result}");
        }
    }
}