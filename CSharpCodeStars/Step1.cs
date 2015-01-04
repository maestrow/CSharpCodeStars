using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace CSharpCodeStars
{
    /// <summary>
    /// На съемках твоего первого клипа не обойтись без массовки – 103 симпатичных девушек разного роста, одетых в разноцветные костюмы. 
    /// Но как их лучше разместить в кадре? 
    /// Чтобы найти удачный ракурс, тебе придется попробовать все возможные расстановки для героинь твоего видео. 
    /// Сколько часов потребуется на просмотр всех расстановок, если на просмотр одной расстановки требуется 10 секунд?
    /// </summary>
    public class Step1: IStep
    {
        public void Do(TextWriter writer)
        {
            BigInteger result = Factorial(103) * 10 /60 /60;
            writer.WriteLine(result.ToString("F"));
        }

        private BigInteger Factorial(BigInteger n)
        {
            BigInteger f = 1;

            for (BigInteger i = 2; i <= n; i++)
            {
                checked
                {
                    f *= i;
                }
            }
            return f;
        }
    }
}
