using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeStars
{
    public class Step6: IStep
    {
        private int[] number;
        private int count = 0;
        public void Do(TextWriter writer)
        {
            
            for (int a1 = 0; a1 <= 8; a1++)
                for (int a2 = 0; a2 <= 8; a2++)
                    for (int a3 = 0; a3 <= 8; a3++)
                        for (int a4 = 0; a4 <= 8; a4++)
                            for (int a5 = 0; a5 <= 8; a5++)
                                for (int a6 = 0; a6 <= 8; a6++)
                                    for (int a7 = 0; a7 <= 8; a7++)
                                        for (int a8 = 0; a8 <= 8; a8++)
                                        {
                                            number = new int[] { a1, a2, a3, a4, a5, a6, a7, a8 };
                                            count += check();
                                        }
            writer.WriteLine(count);
        }

        private int check()
        {
            int lSum = 0;
            int rSum = number.Sum(a => a);


            for (int i = 0; i <= 7; i++)
            {
                lSum += number[i];
                rSum -= number[i];
                if (lSum == rSum)
                    return 1;
            }
            return 0;
        }
    }
}
