using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpCodeStars
{
    /// <summary>
    /// Может ли музыкальный шедевр написать робот? Гениальный Доктор Композитус утверждает, что его робот Монструс Креативус 2000 сделает это в два счета! Тебе предстоит проверить его работу, ведь, возможно, старик Композитус уже просто сошел с ума. Для написания шедевра робот использует язык !#. Каждая команда языка – один символ, доступные команды:
    /// Z – положить ноль на верхушку стека
    /// + - сложить два числа на верхушке стека
    /// * - умножить два числа на верхушке стека
    /// ! – вывести на печать букву, номер которой лежит на верхушке стека (a – 0, b – 1 и т.д.)
    /// # - увеличить верхушку стека на 1
    /// % - ничего не делать
    /// ~ - напечатать пробел
    /// Во входном файле содержится программа на языке !#. Определи, что напечатает эта программа.
    /// </summary>
    public class Step11:  IStep
    {
        public void Do(TextWriter writer)
        {
            string letters = "abcdefghigklmnopqrstuvwxyz";
            string result = "";
            Stack<int> stack = new Stack<int>();
            var data = File.ReadAllText("69.data");
            for (int i = 0; i < data.Length; i++)
            {
                switch (data[i])
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
                        result += letters[stack.Pop()];
                        break;
                    case '#':
                        stack.Push(stack.Pop() + 1);
                        break;
                    case '%':
                        break;
                    case '~':
                        result += " ";
                        break;
                }
            }

            writer.WriteLine(result);
        }
    }
}
