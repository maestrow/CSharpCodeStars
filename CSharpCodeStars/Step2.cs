using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharpCodeStars
{
    /// <summary>
    /// Случайно к тебе попало письмо с текстом будущего хита от твоего главного соперника за первое место в хит-парадах! 
    /// Но, к сожалению, все сообщение оказалось закодированным. 
    /// Твои помощники определили, что в песне используется два смысловых слова - Yo и Nice - причем, 
    /// Nice означает конец очередной буквы, а количество предшествующих слов Yo определяет порядковый номер буквы в алфавите. 
    /// Два подряд идущих слова Nice обозначают конец слова. 
    /// В приведенном файле также содержатся другие слова-паразиты, которые не несут смысловой нагрузки, 
    /// и бессмысленные знаки препинания (которые тем не менее используются для разделения слов). 
    /// Расшифруй текст песни, содержащийся в файле. 
    /// Если ты сделаешь все правильно, ты получишь текст только из букв и пробелов, без лишних пробелов и знаков препинания.
    /// </summary>
    public class Step2: IStep
    {
        private const string Nice = "Nice";
        private const string Yo = "Yo";
        private string Stream { get; set; }

        private int LetterNumber { get; set; }

        private string Result { get; set; }

        private int Pos { get; set; }

        public void Do(TextWriter writer)
        {
            Stream = File.ReadAllText("65.result");
            Pos = 0;
            Result = string.Empty;

            while (Pos < Stream.Length)
            {
                if (check(Yo))
                    LetterNumber++;
                else if (check(Nice))
                {
                    if (LetterNumber == 0)
                        Result += ' ';
                    else
                    {
                        Result += (char)(LetterNumber + 96);
                        LetterNumber = 0;
                    }
                }
                Pos++;
            }
            writer.WriteLine(Result);
        }

        private bool check(string str)
        {
            if (Pos - str.Length < 0)
                return false;
            return Stream.Substring(Pos - str.Length, str.Length) == str;
        }

    }
}
