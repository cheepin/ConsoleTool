using System;
using System.IO;

using System.Collections.Generic;
using System.Linq;
namespace FileCopy
{
	//C:\Users\fujit\Downloads\news.txt
	class Program
	{
		static void Main()
		{
			Console.Write("コピー元のファイルのパスを入力してください\n");
			String path = Console.ReadLine();
			var file = File.OpenRead(path);
			StreamReader str = new StreamReader(file);

			List<string> inputStrings = new List<string>();
			String inputed = "";
			while(inputed != "End")
			{
				Console.Write("新しく作成するファイルの名前を入力してください\n");
				inputed = Console.ReadLine();
				List<string> inputList = inputed.Split(',').ToList();

				while(inputList.Count!=0)
				{
					var newPath = '\\'+inputList[0] +'.'+ path.Substring(path.LastIndexOf('\\')).Split('.')[1];
					var newPath2 = path.Remove(path.LastIndexOf('\\')) +newPath;
					if(inputList[0]!="End")
					{
						Console.Write($"{newPath2}を作成しました\n");
						File.Copy(path,newPath2);
						inputList.RemoveAt(0);
				
					}
					else
					{
						break;
					}
				}
				

				
			}
			Console.Read();
		}
	}


	public static class ConsoleKeyInfoEx
	{
		public static void WriteConsole(this ConsoleKeyInfo info)
		{
			Console.Write(info.Key);
		}

		public static void WriteConsole(this List<string> info)
		{
			info.ForEach(X=>Console.Write(X));
		}
	}

}
