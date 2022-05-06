using System;
using System.IO;
using System.Numerics;
using System.Text;

internal class Program
{
    static void Main(string[] args)
    {
        //new Download().Run();
        foreach (var challenge in new BaseChallenge[] { new Adresse(), new Digicode(), new Password(), new Download() })
        {
            challenge.Run();
        }
    }
}
