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
     * Complete the 'countResponseTimeRegressions' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY responseTimes as parameter.
     */

    public static int countResponseTimeRegressions(List<int> responseTimes)
    {
        int n = responseTimes.Count;

        if (n == 0) { return 0; }

        long sum = responseTimes[0];
        int count = 0;

        for (int i = 0; i < n; i++)
        {
            double average = (double)sum / i;

            if (responseTimes[i] > average)
            {
                count++;
            }

            sum += responseTimes[i];
        }

        return count;

    }
}
