using System;
using System.IO;
using System.Linq;

namespace StackMenu
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = args[0];
            
            var arr = File.ReadLines(path).First().Split(" ").Select(s => (s));
            var stack = new Stack<string>();
            if (stack.Count() == 0)
            {
                foreach (var e in arr)
                {
                    stack.Push(e); 
                }
            }
            LetsIterate(stack);

            ShowMenu();
            int num = Int32.Parse(Console.ReadLine());

            while (num != 3)
            {
                switch (num)
                {
                    case 1:
                        Console.WriteLine("Введите значение: ");
                        string st = Console.ReadLine();
                        stack.Push(st);
                        LetsIterate(stack);
                        ShowMenu();
                        num = Int32.Parse(Console.ReadLine());
                        break;
                    case 2:
                        stack.Pop();
                        LetsIterate(stack);
                        ShowMenu();
                        num = Int32.Parse(Console.ReadLine());
                        break;
                }
            }
            File.WriteAllText(path, String.Join(" ",stack.ToArray().Reverse()));
            
        }

        

        static void LetsIterate<T>(Stack<T> stack)
        {
            Console.Write("Стек: ");
            foreach (var element in stack)
            {
                Print(element);
            }
        }

        static void Print<T>(T element)
        {
            Console.Write($"{element} ");
        }

        static void ShowMenu()
        {
            Console.WriteLine("\n1. Добавить элемент.\n2. Удалить элемент.\n3. Выход.\nВведите число, чтобы совершить операцию: ");
        }

    }
}