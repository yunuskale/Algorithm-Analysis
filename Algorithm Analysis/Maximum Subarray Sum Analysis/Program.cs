// Proje Adı: Maximum Subarray Sum Analysis

using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int[] sizes = { 1000, 10000, 100000 , 1000000, 10000000}; // Test edilecek dizi boyutları

        foreach (var size in sizes)
        {
            int[] array = GenerateRandomArray(size);

            Console.WriteLine($"Dizi Boyutu: {size}");

            // Kadane Algoritması ile Zaman Ölçümü
            Stopwatch sw = Stopwatch.StartNew();
            int maxSum = MaxSubarraySum(array);
            sw.Stop();

            Console.WriteLine($"En Büyük Alt Dizi Toplamı: {maxSum}");
            Console.WriteLine($"Geçen Süre: {sw.ElapsedMilliseconds} ms");

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
            array[i] = random.Next(-1000, 1000); // Pozitif ve negatif sayılar içerebilir
        }
        return array;
    }

    // Kadane Algoritması: En Büyük Alt Dizi Toplamını Bulma
    static int MaxSubarraySum(int[] array)
    {
        int maxSum = int.MinValue;
        int currentSum = 0;

        foreach (var num in array)
        {
            currentSum += num;
            if (currentSum > maxSum)
                maxSum = currentSum;

            if (currentSum < 0)
                currentSum = 0;
        }

        return maxSum;
    }
}
