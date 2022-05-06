using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

public abstract class BaseChallenge
{
    public abstract void Run();

    public void ReadTextFile(string fileName, Action<string[]> processLine)
    {
        using (StreamReader sr = new StreamReader(fileName))
        {
            string? line = null;
            while ((line = sr.ReadLine()) != null)
            {
                processLine(line.Split(' '));
            }
        }
    }
}
