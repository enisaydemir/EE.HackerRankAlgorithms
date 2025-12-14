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
     * Complete the 'timeConversion' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING s as parameter.
     */

    public static string timeConversion(string s)
    {
        //07:05:45PM expected output: 19:05:45
        string period = s.Substring(8, 2);
        string hourPart = s.Substring(0, 2);
        int hour = int.Parse(hourPart);
        if (period == "AM")
        {
            if (hour == 12)
            {
                hour = 0;
            }
        }
        else // PM
        {
            if (hour != 12)
            {
                hour += 12;
            }
        }
        string hourString = hour.ToString("D2");
        string convertedTime = hourString + s.Substring(2, 6);
        return convertedTime;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string s = Console.ReadLine();

        string result = Result.timeConversion(s);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
