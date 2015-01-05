using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeStars
{
    /// <summary>
    /// На реалити-шоу для музыкальных исполнителей 2 судьи оценивают ежедневно работу и выступления каждого участника, 
    /// при этом они фиксируют свои оценки в специальный блокнот вручную. 
    /// Они заносят три значения: количество баллов, которое необходимо снять с участника за ошибки, 
    /// общую оценку работы за день и свой логин. Чтобы подвести итоги очередного этапа конкурса, 
    /// судьи сводят все свои наблюдения в один отчет, но в их блокнотах очень много записей, 
    /// поэтому они хотели бы иметь приложение, которое будет автоматически записывать результаты. 
    /// Проблема в том, что в записях, несмотря на тщательность заполнения, имеются ошибки: 
    /// значения штрафных баллов за ошибки и общая оценка перепутаны местами. 
    /// Это необходимо учитывать в логике программы. 
    /// На входе программы текстовый файл с тремя столбиками, значение количества штрафных баллов всегда отрицательное (не 0). 
    /// Результат работы – целое среднее значение штрафных баллов, сумма оценок и логин допустившего наибольшее количество ошибок судьи.
    /// Ответ: -97 49266 pluto
    /// </summary>
    public class Step9: IStep
    {
        class Line
        {
            public int Fine;
            public int Mark;
            public string Name;
            public bool WasError;
        }

        List<Line> lines = new List<Line>();

        public void Do(TextWriter writer)
        {
            var text = File.ReadAllText("46.txt");
            foreach (string str in text.Split(new [] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries))
                lines.Add(parse(str));

            var avgFine = lines.Average(a => a.Fine);
            var sumMark = lines.Sum(a => a.Mark);
            var name = lines.GroupBy(a => a.Name)
                .Select(a => new {name = a.Key, errors = a.Where(b => b.WasError).Count()})
                .OrderByDescending(a => a.errors)
                .First()
                .name;

            string msg = string.Format("{0:F0} {1} {2}", avgFine, sumMark, name);

            writer.WriteLine(msg);
        }

        private Line parse(string str)
        {
            string[] line = str.Split(' ');
            var result = new Line() {Name = line[2]};
            int val1 = int.Parse(line[0]);
            int val2 = int.Parse(line[1]);
            
            if (val2 < 0)
            {
                result.Fine = val2;
                result.Mark = val1;
                result.WasError = true;
            }
            else
            {
                result.Fine = val1;
                result.Mark = val2;
            }
            return result;
        }

    }
}
