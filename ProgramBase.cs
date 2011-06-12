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

		public string CaseStr { get { return "Case #" + CaseNo + ":"; } }

		public abstract void RunCase();

		public virtual void Run()
		{
			string inputFile;
			string dir = "../../";
			if (File.Exists(dir+"input.in"))
				inputFile = "input.in";
			else inputFile = "input.txt";
			Console.ForegroundColor = ConsoleColor.Red;
			if (inputFile == "input.txt")
				Console.WriteLine("Practice");
			else
				Console.WriteLine("Real");
			Console.WriteLine();
			using (Input = new StreamReader(dir + inputFile))
			using (Output = new StreamWriter(dir + "output.txt"))
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
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine("Finished");
			Console.ResetColor();
			Console.ReadKey();
		}
	}
}
