using System;
using System.Collections.Generic;

namespace StringCollections
{
    public class Program
    {
        private static void Main(string[] args)
        {
            string [] variasStrings = { "uma", "duas", "três", "três", "quatro"};

            List<string> list = new List<string>();
            Stack<string> stack = new Stack<string>();
            Queue<string> queue = new Queue<string>();
            // Repetição de chave
            HashSet<string> set = new HashSet<string>();

            IEnumerable<string>[] collections = { list, stack, queue, set };

            foreach (string s in variasStrings)
            {
                // Vai imprimir pela ordem que está no array
                list.Add(s);
                // Vai imprimir pela ordem inversa do array
                stack.Push(s);
                // Vai imprimir pela ordem que está no array
                queue.Enqueue(s);
                // Vai imprimir pela ordem que está no array e retira o que está repetido
                set.Add(s);
            }

            foreach (IEnumerable<string> collection in collections)
            {
                Console.WriteLine(collection.GetType().Name);
                foreach (string s in collection)
                {
                    Console.WriteLine($"\t{s}");
                }
            }
        }
    }
}