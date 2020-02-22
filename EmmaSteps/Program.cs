using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmmaSteps
{
    class Program
    {
        public static int cloud = 0;
        public static int jump = 0;
        public static string path = $"path : 0";
        static void Main(string[] args)
        {
            List<int> inputList = new List<int>() { };
            Console.Write("Please input step (0:safe, 1:avoid) [Ex: 0100010] >> ");
            string input = Console.ReadLine();
            foreach (var ch in input)
            {
                if (ch != '0' && ch != '1') {
                    Console.WriteLine("Wrong input! Please try again.");
                    inputList = new List<int>() { };
                    break;
                }
                else { inputList.Add(Int32.Parse(ch.ToString())); }
            }
            if (inputList.Count > 0) { 
                if (inputList[0] == 1) { Console.WriteLine("First step should be safed! Please try again."); }
                else { 
                    if (inputList.Count > 0) {
                        do {
                            if ((cloud + 2) < inputList.Count)
                            {
                                if (inputList[cloud] == inputList[cloud + 2]) { available(2); }
                                else if (inputList[cloud] == inputList[cloud + 1]) { available(1); }
                                else{
                                    cloud = inputList.Count;//to end
                                    Console.WriteLine("Jump is available 1 or 2 steps. Please try again.");
                                }
                            }
                        } while (cloud < inputList.Count-1);
                        Console.Write(path);
                        Console.WriteLine($"\ntotal jump : {jump}");
                    }
                }
            }
        }
        internal static void available (int i)
        {
            cloud += i;
            path += $"->{cloud}";
            jump++;
        }
    }
}
