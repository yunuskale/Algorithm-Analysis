// Proje Adı: Kth Element Performance Analysis

using System;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        int[] sizes = { 1000, 5000, 10000, 50000 }; // Test edilecek dizi boyutları
        int k = 10; // k. en küçük eleman

        foreach (var size in sizes)
        {
            int[] array = GenerateRandomArray(size);

            Console.WriteLine($"Dizi Boyutu: {size}, k: {k}");

            // Yöntem 1: Diziyi Sıralayarak k. Elemanı Bulma
            int[] array1 = (int[])array.Clone();
            Stopwatch sw1 = Stopwatch.StartNew();
            int kthElement1 = FindKthSmallestBySorting(array1, k);
            sw1.Stop();
            Console.WriteLine($"Yöntem 1: {kthElement1}, Süre: {sw1.ElapsedMilliseconds} ms");

            // Yöntem 2: Insertion Mantığı ile k. En Küçüğü Bulma
            int[] array2 = (int[])array.Clone();
            Stopwatch sw2 = Stopwatch.StartNew();
            int kthElement2 = FindKthSmallestByPartialSort(array2, k);
            sw2.Stop();
            Console.WriteLine($"Yöntem 2: {kthElement2}, Süre: {sw2.ElapsedMilliseconds} ms");

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

    // Yöntem 1: Bubble Sort ile Diziyi Tamamen Sıralayıp k. Elemanı Bulma
    static int FindKthSmallestBySorting(int[] array, int k)
    {
        BubbleSort(array);
        return array[k - 1];
    }

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

    // Yöntem 2: K Elemanlık Bir Bölümü Sıralayıp Kalanları İnceleyerek k. Elemanı Bulma
    static int FindKthSmallestByPartialSort(int[] array, int k)
    {
        // İlk k elemanı insertion sort ile sırala
        for (int i = 1; i < k; i++)
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

        // Geri kalan elemanları kontrol et
        for (int i = k; i < array.Length; i++)
        {
            if (array[i] < array[k - 1])
            {
                array[k - 1] = array[i];

                // k-1 elemanını yerleştirmek için tekrar insertion sort yap
                int key = array[k - 1];
                int j = k - 2;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }
                array[j + 1] = key;
            }
        }

        return array[k - 1];
    }
}
