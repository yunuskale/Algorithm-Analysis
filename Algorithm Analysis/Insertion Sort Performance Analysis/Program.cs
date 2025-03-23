// Proje Adı: Insertion Sort Performance Analysis

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

            // Insertion Sort Zaman Ölçümü
            int[] arrayCopy = (int[])array.Clone();
            Stopwatch sw = Stopwatch.StartNew();
            InsertionSort(arrayCopy);
            sw.Stop();
            Console.WriteLine($"Insertion Sort Süre: {sw.ElapsedMilliseconds} ms");

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

    // Insertion Sort algoritması
    static void InsertionSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int j = i - 1;

            while (j >= 0 && array[j] > key)
            {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = key;
        }
    }
}
