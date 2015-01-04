using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeStars
{
    /// <summary>
    /// Билет на твой первый концерт в Лужниках содержит 6 цифр от 0 до 3. 
    /// Сколько среди всех билетов "счастливых", т.е. таких, для которых сумма первых 3 цифр равна сумме последних 3 цифр?
    /// </summary>
    public class Step5: IStep
    {
        private const int max = 3;

        public void Do(TextWriter writer)
        {
            int n = 0;
            for (int a=0; a<4; a++)
                for (int b=0; b<4; b++)
                    for (int c=0; c<4; c++)
                        for (int d=0; d<4; d++)
                            for (int e=0; e<4; e++)
                                for (int f=0; f<4; f++)
                                    if (a + b + c == d + e + f)
                                        n++;
            
            writer.WriteLine(n);
        }
    }
}
