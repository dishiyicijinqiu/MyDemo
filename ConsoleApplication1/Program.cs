using Service.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                char[] chars = new char[] { ',' };
                while (true)
                {
                    string read = Console.ReadLine();
                    if (read == "exit")
                        break;
                    try
                    {
                        int[] inputs = read.Split(chars).Select(t => Convert.ToInt32(t)).ToArray();
                        int[] results = GetSameInOrder(inputs);
                        StringBuilder sbResult = new StringBuilder();
                        for (int i = 0; i < results.Length; i++)
                        {
                            if (i == results.Length - 1)
                            {
                                sbResult.AppendFormat("{0}", results[i]);
                                continue;
                            }
                            sbResult.AppendFormat("{0},", results[i]);
                        }
                        if (sbResult.Length == 0)
                        {
                            Console.WriteLine("二货，没有重复的呀");
                            break;
                        }
                        Console.WriteLine(sbResult.ToString());
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("总之有错误，你懂的");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }

        private static int[] GetSameInOrder(int[] inputs)
        {
            List<int> results = new List<int>();
            for (int i = 0; i < inputs.Length; i++)
            {
                int nownum = inputs[i];
                int count = inputs.Count(t => t == nownum);
                if (count > 1)
                {
                    results.Add(nownum);
                }
            }
            return results.ToArray();
        }
    }
}
