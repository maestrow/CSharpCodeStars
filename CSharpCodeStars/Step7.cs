using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeStars
{
    /// <summary>
    /// Спеть со звездой – настоящая удача для начинающего исполнителя! 
    /// Но неужели твое имя будет стоять вторым на диске, плакатах… 
    /// Твое честолюбие не позволит этому случиться, ведь ты уже в шаге от статуса суперзвезды! 
    /// Кажется, конфликт неизбежен. 
    /// Чтобы споры за первенство не поставили крест на совместной работе, звукоинженер предложил определить, сколько работы вложил каждый из исполнителей в песню. 
    /// Твои партии в записи он пометил буквами x,y,z,w, а партии приглашенной звезды - a,b,c,d. Также в расшифровке записи присутствуют другие случайные символы, 
    /// обозначающие партии бэк-вокала, которые можно игнорировать. Принадлежность к конкретному исполнителю тем сильнее, чем длиннее максимальная 
    /// подпоследовательность партии этого исполнителя. 
    /// Давай узнаем, чье же имя окажется первым – определи на сколько процентов песня твоя.
    /// Ответ: 70
    /// </summary>
    public class Step7: IStep
    {
        class Star
        {
            public string Name { get; set; }
            public string Pattern { get; set; }
            public int CurrentLen { get; set; }
            public int MaxLen { get; set; }
        }

        private List<Star> stars = new List<Star>()
        {
            new Star() { Name = "Me", Pattern = "xyzw"},
            new Star() { Name = "Star", Pattern = "abcd"}
        };

        private Star current;

        private int? _total;
        private int total 
        {
            get
            {
                if (!_total.HasValue)
                    _total = stars.Sum(a => a.MaxLen);
                return _total.Value;
            }
        }

        public void Do(TextWriter writer)
        {
            var text = File.ReadAllText("106.data");
            for (int i = 0; i < text.Length; i++)
            {
                check(text[i]);
            }
            correctLen();
            var msg = stars
                .OrderByDescending(a => a.MaxLen)
                .Select(a => string.Format("{0} {1} {2:P}", a.Name, a.MaxLen, (double)a.MaxLen / (double)total))
                .Aggregate((a, b) => a + "\n" + b);
            writer.WriteLine(msg);
            
        }

        private void check(char ch)
        {
            if (!checkStar(ch, current))
            {
                foreach (var star in stars.Where(a => a != current))
                {
                    if (checkStar(ch, star))
                        return;
                }
            }
        }

        private bool checkStar(char ch, Star star)
        {
            if (star != null && star.Pattern.Contains(ch))
            {
                if (star != current)
                {
                    if (current != null)
                        correctLen();
                    current = star;
                }

                star.CurrentLen++;
                return true;
            }
            return false;
        }

        private void correctLen()
        {
            if (current.CurrentLen > current.MaxLen)
                current.MaxLen = current.CurrentLen;
            current.CurrentLen = 0;
        }

        
    }
}
