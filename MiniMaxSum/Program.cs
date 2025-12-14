using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'miniMaxSum' function below.
     *
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static void miniMaxSum(List<int> arr)
    {
        long totalSum = arr.Select(x => (long)x).Sum();
        int minValue = arr.Min();
        int maxValue = arr.Max();

        long minSum = totalSum - maxValue;
        long maxSum = totalSum - minValue;
        Console.WriteLine($"{minSum} {maxSum}");
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        RunTests();
        //List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        //Result.miniMaxSum(arr);
    }

    public static void RunTests()
    {
        Console.WriteLine("Testler Başlatılıyor...\n");

        // Senaryo 1: Basit Sayılar
        RunSingleTest(
            input: new List<int> { 1, 2, 3, 4, 5 },
            expectedOutput: "10 14",
            testName: "Küçük Sayılar Testi"
        );

        // Senaryo 2: Büyük Sayılar (HackerRank Örneği)
        RunSingleTest(
            input: new List<int> { 793810624, 895642170, 685903712, 623789054, 468592370 },
            expectedOutput: "2572095760 2999145560",
            testName: "Büyük Sayılar (Overflow) Testi"
        );

        // Senaryo 3: Aynı Sayılar
        RunSingleTest(
            input: new List<int> { 5, 5, 5, 5, 5 },
            expectedOutput: "20 20",
            testName: "Eşit Sayılar Testi"
        );
    }

    public static void RunSingleTest(List<int> input, string expectedOutput, string testName)
    {
        // 1. Konsol çıktısını (Console.WriteLine) yakalamak için sanal bir yazıcı oluşturuyoruz.
        var originalConsoleOut = Console.Out; // Eski konsolu yedekle
        using (var stringWriter = new StringWriter())
        {
            Console.SetOut(stringWriter); // Konsolu sanal yazıcıya yönlendir

            // 2. Metodu çalıştır
            Result.miniMaxSum(input);

            // 3. Çıktıyı al ve temizle (boşlukları sil)
            var actualOutput = stringWriter.ToString().Trim();

            // 4. Konsolu eski haline getir (sonucu ekrana basabilmek için)
            Console.SetOut(originalConsoleOut);

            // 5. Karşılaştırma yap
            if (actualOutput == expectedOutput)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[BAŞARILI] {testName}");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[HATA] {testName}");
                Console.WriteLine($"   Beklenen: {expectedOutput}");
                Console.WriteLine($"   Gelen   : {actualOutput}");
            }
            Console.ResetColor();
        }
    }
}


