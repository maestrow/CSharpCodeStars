using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeStars
{
    public class Step3: IStep
    {
        private List<HashSet<int>> groups;

        public void Do(TextWriter writer)
        {
            var text = File.ReadAllText("17.data");

            groups = new List<HashSet<int>>();
            foreach (string row in text.Split(new [] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries))
            {
                List<int> pair = row.Split(' ').Select(a => int.Parse(a)).ToList();
                checkPair(pair[0], pair[1]);
            }

            writer.WriteLine(groups.Count);
        }

        private void checkPair(int a, int b)
        {
            var g1 = groups.SingleOrDefault(g => g.Any(i => i == a));
            var g2 = groups.SingleOrDefault(g => g != g1 && g.Any(i => i == b));

            if (g1 != null && g2 != null)
            {
                g1.UnionWith(g2);
                groups.Remove(g2);
            }
            else if (g1 != null)
            {
                g1.Add(b);
            }
            else if (g2 != null)
            {
                g2.Add(a);
            }
            else
            {
                groups.Add(new HashSet<int>(new List<int> { a, b }));
            }
        }
    }
}
