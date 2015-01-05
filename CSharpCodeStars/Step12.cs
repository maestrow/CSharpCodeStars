using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeStars
{
    /// <summary>
    /// В новой версии Монструс Креативус 3500 для написания музыкальных шедевров использует более продвинутый язык программирования !++. 
    /// К командам !# добавляются более сложные команды:
    /// $ - поменять местами два верхних элемента стека
    /// @ - дублировать верхний элемент стека
    /// - - уменьшить верхушку стека на 1
    /// [ - установить метку в программе
    /// &lt; - если верхушка стека не равна 0, то возврат на последнюю метку в программе (верхушка стека при этом удаляется), иначе – продолжение выполнения программы
    /// ` - удалить верхний элемент стека
    /// Во входном файле содержится программа на языке !++. Определи, что напечатает эта программа. Возможно, это уже настоящий хит.
    /// </summary>
    public class Step12: IStep
    {
        private TextWriter _writer;
        public void Do(TextWriter writer)
        {
            _writer = writer;
            string letters = "abcdefghigklmnopqrstuvwxyz";
            List<int> labels = new List<int>(); // метки (см. "[" и "<")
            string result = "";
            Stack<int> stack = new Stack<int>();
            var data = File.ReadAllText("73.data");
            char currentOp;
            for (int i = 0; i < data.Length; i++)
            {
                currentOp = data[i];
                switch (currentOp)
                {
                    case 'Z':
                        stack.Push(0);
                        break;
                    case '+':
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    case '*':
                        stack.Push(stack.Pop() * stack.Pop());
                        break;
                    case '!':
                        //writer.WriteLine(letters[stack.Peek()] + "-------------------------");
                        result += letters[stack.Pop()];
                        break;
                    case '#':
                        stack.Push(stack.Pop() + 1);
                        break;
                    case '%':
                        break;
                    case '~':
                        //writer.Write(' ');
                        result += " ";
                        break;
                    case '$':
                        var b = stack.Pop();
                        var a = stack.Pop();
                        stack.Push(b);
                        stack.Push(a);
                        break;
                    case '@':
                        stack.Push(stack.Peek());
                        break;
                    case '-':
                        stack.Push(stack.Pop()-1);
                        break;
                    case '[':
                        labels.Add(i);
                        break;
                    case '<':
                        stack.Pop();
                        if (stack.Peek() != 0)
                        {
                            i = labels.Last();
                        }
                        break;
                    case '`':
                        stack.Pop();
                        break;
                }

                //dump(currentOp, stack);
            }

            writer.WriteLine(result);
        }

        private void dump(char ch, Stack<int> stack)
        {
            var msg = stack.Select(a => a.ToString()).DefaultIfEmpty().Aggregate((a, b) => string.Format("{0} {1}", a, b));
            _writer.WriteLine(ch + ": " + msg);
        }
    }
}
