using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakes_and_Ladders
{
    class Program
    {
        private SnakesLadders test = new SnakesLadders();
        static void Main(string[] args)
        {
            Program kataTestClass = new Program();
            string result = kataTestClass.test.play(1, 1);
            Console.WriteLine(result);
            result = kataTestClass.test.play(1, 5);
            Console.WriteLine(result);
            result = kataTestClass.test.play(6, 2);
            Console.WriteLine(result);
            result = kataTestClass.test.play(1, 1);
            Console.WriteLine(result);
            result = kataTestClass.test.play(2, 6);
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}

