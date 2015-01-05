using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeStars
{
    /// <summary>
    /// Крутой журнал Growing Stones попросил у тебя демо этого релиза, чтобы первыми написать рецензию на него. 
    /// Наконец, ты получаешь по электронной почте письмо от главного редактора, но вот беда: 
    /// в тексте автор заменил все буквы на другие буквы, а остальные знаки оставили без изменений, 
    /// чтобы конкуренты не могли украсть его мнение. Также он приложил к письму файл, 
    /// представляющий собой частотный словарь исходного текста, т.е. перечень букв в порядке убывания 
    /// частоты их появления в тексте. Первая строчка входного файла содержит частотный словарь 
    /// (символы латинского алфавита в порядке убывания частоты, возможно, менее 26-ти, если некоторые буквы в файле не встречались), 
    /// остальные строчки – сам текст статьи. Расшифруй текст рецензии, сохранив все знаки препинания.
    /// </summary>
    public class Step10: IStep
    {
        private const string ignore = " ,.\"-";
        Dictionary<char, int> count = new Dictionary<char, int>();
        
        public void Do(TextWriter writer)
        {
            string[] file = File.ReadAllLines("50.data");
            string text = file[1];

            for (int i = 0; i < text.Length; i++)
            {
                if (!ignore.Contains(text[i]))
                    add(text[i]);
            }

            writer.WriteLine(decode(text, getDict(file[0], count)));
        }

        private void add(char ch)
        {
            if (!count.ContainsKey(ch))
                count[ch] = 0;
            count[ch]++;
        }

        private static Dictionary<char, char> getDict(string chars, Dictionary<char, int> count)
        {
            int j = 0;
            return count.OrderByDescending(a => a.Value).ToDictionary(a => a.Key, a => chars[j++]);
        }

        private string decode(string text, Dictionary<char, char> dict)
        {
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];
                if (dict.ContainsKey(ch))
                    result += dict[ch];
                else
                    result += ch;
            }
            return result;
        }
    }
}
