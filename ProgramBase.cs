using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace JamHelpers
{
    public abstract class ProgramBase
    {
        public TextReader Input;
        public TextWriter Output;

        public int CaseNo;
        public int CaseCount;

        public string ReadLine()
        {
            return Input.ReadLine();
        }

        public string[] ReadMultiLine()
        {
            int count = ReadLine().ToInt();
            string[] result = new string[count];
            for (int i = 0; i < count; i++)
                result[i] = ReadLine();
            return result;
        }

        public void WriteLine(object s)
        {
            Output.WriteLine(s.ToStringInv());
            Console.WriteLine(s.ToStringInv());
        }

        public void Write(object s)
        {
            Output.Write(s.ToStringInv());
            Console.Write(s.ToStringInv());
        }

        public void DebugWrite(object s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(s.ToStringInv());
            Console.ResetColor();
        }

        public void DebugWriteLine(object s)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s.ToStringInv());
            Console.ResetColor();
        }

        public void WriteAnswer(object o)
        {
            WriteLine(CaseStr + " " + o.ToStringInv());
        }

        public string CaseStr { get { return "Case #" + CaseNo + ":"; } }

        public abstract void RunCase();

        public virtual void RunFile()
        {
            CaseCount = Input.ReadLine().ToInt();
            for (CaseNo = 1; CaseNo <= CaseCount; CaseNo++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Case " + CaseNo + "/" + CaseCount);
                Console.ResetColor();
                RunCase();
            }
        }

        public virtual void Run()
        {
            const string dir = "../../";
            var files = Directory.EnumerateFiles(dir, "input.txt").Concat(Directory.EnumerateFiles(dir, "*.in")).ToArray();
            foreach (var inputFile in files)
            {
                var outputFile = Path.ChangeExtension(inputFile, ".out");
                Console.ForegroundColor = ConsoleColor.Red;
                if (inputFile == "input.txt")
                    Console.WriteLine("Practice");
                else
                    Console.WriteLine("Real - " + Path.GetFileName(inputFile));
                Console.WriteLine();
                using (Input = new StreamReader(inputFile))
                using (Output = new StreamWriter(outputFile))
                {
                    RunFile();
                }
                Console.WriteLine();
            }

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Finished");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
