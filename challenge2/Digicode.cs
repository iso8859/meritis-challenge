using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Digicode : BaseChallenge
{
    public class DataDigiCode
    {
        public int index;
        public int size;
        public int valeur;
        public bool figure4, figure3;
        public override string ToString() => valeur.ToString();
    }
    public override void Run()
    {
        Console.WriteLine("--- Challenge2");
        List<DataDigiCode> codes = new List<DataDigiCode>();
        int index = 0;
        ReadTextFile("challenge2\\digicode.txt", items =>
        {
            codes.Add(new DataDigiCode() { index = index, valeur = int.Parse(items[0]), size = items[0].Length, figure3 = items[0].Contains("3"), figure4 = items[0].Contains("4") });
            index++;
        });

        // Trouver les codes
        List<DataDigiCode> goodSize = codes.Where(x => x.size == 6 && x.valeur % 7 == 0 && x.valeur % 2 == 0).ToList();
        foreach (var item in goodSize)
        {
            if (item.index + 1 < codes.Count && codes[item.index + 1].figure4)
            {
                bool figure3 = false;
                for (int i = 0; i < 3; i++)
                {
                    if (codes[item.index - i - 1].figure3)
                    {
                        figure3 = true;
                        break;
                    }
                }
                if (!figure3)
                {
                    Console.WriteLine(item.valeur);
                }
            }
        }
    }
}
