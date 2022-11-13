using System;
using System.Collections.Generic;
using System.Linq;

namespace AgHW6_T2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            byte studentsTotal = GetStudentsTotal();
            List<string> studentsList = GetStudentsList(studentsTotal);
            PrintResult(studentsList);
            Console.ReadKey();
        }
        static byte GetStudentsTotal()
        {
            byte studentsTotal = GetByte("количество учеников в классе", minValue: 1, maxValue: 20);
            return studentsTotal;
        }
        static List<string> GetStudentsList(byte studentsTotal)
        {
            List<string> studentsList = new List<string>();
            for (int i = 0; i < studentsTotal; i++)
            {
                studentsList.Add(GetSurname());
            }
            return studentsList;
        }
        static string GetSurname()
        {
            string surname = Console.ReadLine();
            return surname;
        }
        static void RemoveVowelFromList(List<string> listStrings)
        {
            char[] vowelLetters = {'А', 'Е','Ё','И','О','У','Э','Ю','Я' };
            for (int i = 0; i < listStrings.Count; i++)
            {
                string str = listStrings[i];
                char ch = str[0];
                if (vowelLetters.Contains(listStrings[i][0]))
                {
                    listStrings.RemoveAt(i);
                    i--;
                }
            }
        }
        static void PrintResult(List<string> listStrings)
        {
            Console.WriteLine("Начинающиеся с согласной буквы фамилии:");
            RemoveVowelFromList(listStrings);
            foreach (string str in listStrings)
            {
                Console.WriteLine(str);
            }
        }
        //-- Methods from library
        static byte GetByte(string prompt = "", byte minValue = byte.MinValue, byte maxValue = byte.MaxValue)
        {
            string inputStr = string.Empty;
            while (true)
            {
                Console.WriteLine($"Введите {prompt}");
                Console.Write($"(Целое число от {minValue} до {maxValue}): ");
                inputStr = Console.ReadLine();
                if (byte.TryParse(inputStr, out byte value))
                    if (value >= minValue && value <= maxValue)
                    {
                        return value;
                    }
            }
        }
    }
}
