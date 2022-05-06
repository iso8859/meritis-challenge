using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

public class Password : BaseChallenge
{
    public override void Run()
    {
        Console.WriteLine("--- Challenge3 (long)");

        List<int> seed = new List<int>();

        ReadTextFile("challenge3\\password.txt", items => {
            seed.Add(int.Parse(items[0]));
        });

        int find = 987654321;
        int max = seed.Max();
        Console.WriteLine(DateTime.Now);
        Console.WriteLine($"Max = {max}");
        bool exit = false;
        Parallel.For(0, seed.Count, i => // Utiliser tous les coeurs de la machine
           {
               for (int j = 0; j < seed.Count && !exit; j++)
               {
                   if (i != j)
                   {
                       int ij = seed[i] + seed[j];
                       if (ij + max >= find)
                       {
                           for (int k = 0; k < seed.Count && !exit; k++)
                           {
                               if (i != k && j != k)
                               {
                                   if (ij + seed[k] == find)
                                   {
                                       Console.WriteLine("a = {0} b = {1} c = {2}", seed[i], seed[j], seed[k]);
                                       // BigInteger a = 3008582, b = 930086315, c = 54559424;
                                       // Utiliser des BigInteger car la multiplication dépasse la capacité de tous les types numériques natifs de .NET
                                       BigInteger a = seed[i], b = seed[j], c = seed[k];
                                       var x = a * b * c;
                                       Console.WriteLine($"a * b * c = {x}");
                                       Console.WriteLine($"a * b * c % {find} = {x % find}");
                                       Console.WriteLine(DateTime.Now);
                                       exit = true;
                                   }
                               }
                           }
                       }
                       // else on abandonne car la somme sera toujours < 987654321
                   }
               }
           });
    }
}
