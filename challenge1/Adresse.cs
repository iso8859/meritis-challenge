using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Adresse : BaseChallenge
{
    public class Adresse0
    {
        public long consommation;
        public string? adresse;
    }

    public override void Run()
    {
        Adresse0 adr = new Adresse0() { consommation = 0 };
        ReadTextFile("challenge1\\adresse.txt", items =>
        {
            long consommation = long.Parse(items[0]);
            if (consommation > adr.consommation)
            {
                adr.consommation = consommation;
                adr.adresse = String.Join(' ', items, 1, items.Length - 1);
            }
        });

        Console.WriteLine("--- Challenge1");
        Console.WriteLine("Adresse avec la plus grande consommation: " + adr.adresse);
    }
}