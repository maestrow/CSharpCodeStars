using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeStars
{
    /// <summary>
    /// На международном музыкальном фестивале участники говорят на множестве разных языков. 
    /// Чтобы все могли понимать друг друга, организаторы предложили использовать автоматические переводчики, 
    /// но переводчики есть не для всех пар языков. В текстовом файле в каждой строке содержится (через пробел) имя переводчика, 
    /// с какого языка и на какой он может переводить. Какое минимальное количество переводчиков необходимо, чтобы переводить с Исландского на Албанский?
    /// </summary>
    public class Step4: IStep
    {
        private const string From = "Исландский";
        private const string To = "Албанский";
        private List<Tuple<string, string>> langs = new List<Tuple<string, string>>();
        private HashSet<string> store = new HashSet<string>();
        private int min = 0;

        public void Do(TextWriter writer)
        {
            string file = File.ReadAllText("21.data");

            langs = file.Split(new[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries)
                .Select(a => a.Split(' '))
                .Select(a => new Tuple<string, string>(a[1], a[2]))
                .ToList();

            store.Add(From);

            while (!store.Any(a => a == To))
            {
                IEnumerable<string> to = langs.Where(a => store.Contains(a.Item1)).Select(a => a.Item2).ToList();
                store.UnionWith(to);

                //writer.WriteLine(store.Aggregate((a, b) => string.Format("{0}\n{1}", a, b)));
                //writer.WriteLine();

                min++;
            }

            writer.WriteLine(min);
        }
    }
}
