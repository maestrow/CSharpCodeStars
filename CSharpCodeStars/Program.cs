using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeStars
{
    class Program
    {
        static void Main(string[] args)
        {
            IStep step = new Step11();
            step.Do(Console.Out);
            Console.WriteLine("ok.");
            Console.ReadKey();
        }
    }
}
