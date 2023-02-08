using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace лаба3 {
    internal class Program {
        static void Main(string[] args) {
            int min = 10000, max = 0;
            string[] strings = File.ReadAllLines("data.txt");
            for (int i = 0; i < strings.Length; i++) {
                int digit = Convert.ToInt32(strings[i]);
                if (digit < min && digit % 37 == 0)
                    min = digit;
                if (digit > max && digit % 73 == 0)
                    max = digit;
            }

            int parCount = 0;
            int buffIndex = 0;
            int minSumma = 0;
            for (int i = 0; i < strings.Length; i++) {
                int digit = Convert.ToInt32(strings[i]);
                if(min > max) {
                    if (digit < min && digit > max) { 
                        buffIndex = i;
                        continue; 
                    } 
                } 
                else { 
                    if (digit > min && digit < max) {
                        buffIndex = i;
                        continue;
                    } 
                }

                if(buffIndex == i - 1 || buffIndex == i + 1) {
                    parCount++;
                    if(minSumma == 0 || minSumma > digit + Convert.ToInt32(strings[buffIndex]))
                        minSumma = digit + Convert.ToInt32(strings[buffIndex]);
                }
            }
            Console.WriteLine(parCount);
            Console.WriteLine(minSumma);
            Console.ReadKey();
        }
    }
}
