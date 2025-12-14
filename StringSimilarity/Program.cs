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
     * Complete the 'stringSimilarity' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING s as parameter.
     */

    public static long stringSimilarity(string s) // Changed return type to long to handle large sums
    {
        //int n = s.Length;
        //int totalSimilarity = n; //start with length of the string itself cause it matches itself
        //for (int i = 1; i < n; i++)
        //{
        //    int j = 0;
        //    while (i + j < n && s[j] == s[i + j])
        //    {
        //        totalSimilarity++;
        //        j++;
        //    }
        //}
        //return totalSimilarity;

        //using z-algorithm to optimize the solution
        int n = s.Length;
        if (n == 0) return 0;

        int[] z = new int[n];
        long totalSimilarity = n; //start with length of the string itself cause it matches itself
        int L = 0, R = 0;

        for (int i = 1; i < n; i++)
        {
            if (i <= R)
            {
                z[i] = Math.Min(R - i + 1, z[i - L]);
            }

            while (i + z[i] < n && s[z[i]] == s[i + z[i]])
            {
                z[i]++;
            }

            if (i + z[i] - 1 > R)
            {
                L = i;
                R = i + z[i] - 1;
            }

            totalSimilarity += z[i];
        }

        return totalSimilarity;
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            string s = Console.ReadLine();

            long result = Result.stringSimilarity(s); // Note: Changed to long to match the return type

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
