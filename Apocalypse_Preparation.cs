using System;
using System.Collections.Generic;
using System.Linq;

namespace FirstProblem
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] queue = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> textiles = new Queue<int>(queue);

            int[] stack = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> medicaments = new Stack<int>(stack);

            Dictionary<string, int> countByMedicaments = new Dictionary<string, int>();

            while (textiles.Any() && medicaments.Any())
            {
                if (((int)textiles.Peek() + (int)medicaments.Peek()) == 30)
                {
                    textiles.Dequeue();
                    medicaments.Pop();
                    if (!countByMedicaments.ContainsKey("Patch"))
                    {
                        countByMedicaments.Add("Patch", 0);
                    }
                    countByMedicaments["Patch"]++;
                }
                else if (((int)textiles.Peek() + (int)medicaments.Peek()) == 40)
                {
                    textiles.Dequeue();
                    medicaments.Pop();
                    if (!countByMedicaments.ContainsKey("Bandage"))
                    {
                        countByMedicaments.Add("Bandage", 0);
                    }
                    countByMedicaments["Bandage"]++;
                }
                else if (((int)textiles.Peek() + (int)medicaments.Peek()) == 100)
                {
                    textiles.Dequeue();
                    medicaments.Pop();
                    if (!countByMedicaments.ContainsKey("MedKit"))
                    {
                        countByMedicaments.Add("MedKit", 0);
                    }
                    countByMedicaments["MedKit"]++;
                }
                else
                {
                    if (((int)textiles.Peek() + (int)medicaments.Peek()) > 100)
                    {
                        int newValue = ((int)textiles.Peek() + (int)medicaments.Peek()) - 100;
                        if (!countByMedicaments.ContainsKey("MedKit"))
                        {
                            countByMedicaments.Add("MedKit", 0);
                        }
                        countByMedicaments["MedKit"]++;

                        textiles.Dequeue();
                        medicaments.Pop();
                        medicaments.Push(medicaments.Pop() + newValue);
                    }
                    else if (((int)textiles.Peek() + (int)medicaments.Peek()) < 100)
                    {
                        textiles.Dequeue();
                        medicaments.Push(medicaments.Pop() + 10);
                    }

                }



            }


            if (!textiles.Any() && !medicaments.Any())
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (!textiles.Any())
            {
                Console.WriteLine("Textiles are empty.");
            }
            else if (!medicaments.Any())
            {
                Console.WriteLine("Medicaments are empty.");
            }

            if (countByMedicaments.Any())
            {
                foreach (var item in countByMedicaments.OrderByDescending(item => item.Value).ThenBy(item => item.Key))
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }

            if (medicaments.Any())
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }

            if (textiles.Any())
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }
    }
}
