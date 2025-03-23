// Proje Adı: Bubble Sort Performance Analysis

using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int[] sizes = { 1000, 5000, 10000, 50000, 100000 }; // Test edilecek dizi boyutları

        foreach (var size in sizes)
        {
            int[] array = GenerateRandomArray(size);

            Console.WriteLine($"Dizi Boyutu: {size}");

            // Bubble Sort Zaman Ölçümü
            int[] arrayCopy = (int[])array.Clone();
            Stopwatch sw = Stopwatch.StartNew();
            BubbleSort(arrayCopy);
            sw.Stop();
            Console.WriteLine($"Bubble Sort Süre: {sw.ElapsedMilliseconds} ms");

            Console.WriteLine("--------------------------------------");
        }
    }

    // Rastgele dizi oluşturma
    static int[] GenerateRandomArray(int size)
    {
        Random random = new Random();
        int[] array = new int[size];
        for (int i = 0; i < size; i++)
        {
            array[i] = random.Next(0, 100000);
        }
        return array;
    }

    // Bubble Sort algoritması
    static void BubbleSort(int[] array)
    {
        int n = array.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (array[j] > array[j + 1])
                {
                    (array[j], array[j + 1]) = (array[j + 1], array[j]);
                }
            }
        }
    }
}
