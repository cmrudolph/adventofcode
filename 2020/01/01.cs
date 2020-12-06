using System;
using System.IO;
using System.Linq;

var numbers = File.ReadAllLines("01.txt").Select(int.Parse).ToArray();

for (int i = 0; i < numbers.Length; i++)
{
    for (int j = i; j < numbers.Length; j++)
    {
        if (numbers[i] + numbers[j] == 2020)
        {
            Console.WriteLine(numbers[i] * numbers[j]);
        }
    }
}

for (int i = 0; i < numbers.Length; i++)
{
    for (int j = i; j < numbers.Length; j++)
    {
        for (int k = j; k < numbers.Length; k++)
        {
            if (numbers[i] + numbers[j] + numbers[k] == 2020)
            {
                Console.WriteLine(numbers[i] * numbers[j] * numbers[k]);
            }
        }
    }
}

