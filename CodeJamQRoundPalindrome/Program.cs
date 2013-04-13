using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

/**
 * Problem

Little John likes palindromes, and thinks them to be fair (which is a fancy word for nice). A palindrome is just an integer that reads the same backwards and forwards - so 6, 11 and 121 are all palindromes, while 10, 12, 223 and 2244 are not (even though 010=10, we don't consider leading zeroes when determining whether a number is a palindrome).

He recently became interested in squares as well, and formed the definition of a fair and square number - it is a number that is a palindrome and the square of a palindrome at the same time. For instance, 1, 9 and 121 are fair and square (being palindromes and squares, respectively, of 1, 3 and 11), while 16, 22 and 676 are not fair and square: 16 is not a palindrome, 22 is not a square, and while 676 is a palindrome and a square number, it is the square of 26, which is not a palindrome.

Now he wants to search for bigger fair and square numbers. Your task is, given an interval Little John is searching through, to tell him how many fair and square numbers are there in the interval, so he knows when he has found them all.

Solving this problem

Usually, Google Code Jam problems have 1 Small input and 1 Large input. This problem has 1 Small input and 2 Large inputs. Once you have solved the Small input, you will be able to download any of the two Large inputs. As usual, you will be able to retry the Small input (with a time penalty), while you will get only one chance at each of the Large inputs.

Input

The first line of the input gives the number of test cases, T. T lines follow. Each line contains two integers, A and B - the endpoints of the interval Little John is looking at.

Output

For each test case, output one line containing "Case #x: y", where x is the case number (starting from 1) and y is the number of fair and square numbers greater than or equal to A and smaller than or equal to B.

Limits

Small dataset

1 ≤ T ≤ 100.
1 ≤ A ≤ B ≤ 1000.

First large dataset

1 ≤ T ≤ 10000.
1 ≤ A ≤ B ≤ 1014.

Second large dataset

1 ≤ T ≤ 1000.
1 ≤ A ≤ B ≤ 10100.

Sample


Input 
 	
Output 
 
3
1 4
10 120
100 1000
Case #1: 2
Case #2: 0
Case #3: 2

*/




namespace CodeJamQRoundPalindrome
{
    class Program
    {
        static TextReader tr;
        static TextWriter tw;//= new StreamReader("A-small-attempt3.in");
        static int i = 0;
        static void Main(string[] args)
        {
            tr = new StreamReader("C-large-1.in");
            
            int n = Convert.ToInt16(tr.ReadLine());
            List<TestCase> testCases = new List<TestCase>();
           
            for (; i < n; i++)
            {
                TestCase t = new TestCase();
                string[] temp2 = tr.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                //string[] temp2 = temp.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                t.lowLimit = Convert.ToInt64(temp2[0]);
                t.upperLimit = Convert.ToInt64(temp2[1]);
                testCases.Add(t.processInput());
              
            }
            tw = new StreamWriter("output.txt");
            i = 0;
            for (; i < testCases.Count-1; i++)
            {
                tw.WriteLine("Case #{0}: {1}", (i + 1), testCases[i].output);
            }
            tw.Write("Case #{0}: {1}", (i + 1), testCases[i].output);
            tr.Close();
            tw.Close();
            //Console.ReadLine();
        }


        public class TestCase
        {
            public Int64 lowLimit { get; set; }
            public Int64 upperLimit { get; set; }
            public int output;

            public TestCase processInput()
            {
                for (Int64 i = lowLimit; i <= upperLimit; i++)
                {
                    if(checkPalindrome(i))
                    {
                        double temp = Math.Sqrt(i);
                        if ((temp % 1) == 0 && checkPalindrome(Convert.ToInt64(temp)))
                        {
                            output++;
                        }
                    }
                }
                return this;
            }
            public static bool checkPalindrome(Int64 number)
            {
                string temp = number.ToString();
                while (temp.Length >= 0)
                {
                    if (!temp.EndsWith(temp[0].ToString()))
                        return false;
                    else
                    {
                        temp = temp.Remove(temp.Length - 1, 1);
                        temp = temp.Remove(0, 1);
                        if (temp.Length == 0 || temp.Length ==1)
                            return true;

                    }
                }
                return false;
                /*
                Int64 n = number;

                Int64 dig = 0, rev = 0;
                while (number > 0)
                {
                    dig = number % 10;
                    rev = rev * 10 + dig;
                    number = number / 10;
                }
                if (n == rev)
                    return true;
                else
                    return false;
                 */
            }
        }

    }
    
}

