namespace ConsoleApplication1
{
	using System;
	using System.Diagnostics;
	using System.IO;

	public class Program
    {
        public static void Main(string[] args)
        {
			Console.WriteLine("Enter the path to files for join:");
			var path = Console.ReadLine();

			var files = Directory.GetFiles(path);

			Console.WriteLine("Start merging files...");
			var stopWatch = new Stopwatch();
			stopWatch.Start();

			Console.WriteLine("Enter name of the resulting file:");
			var newFileName = Console.ReadLine();
			JoinMp3File(path, files, newFileName);

			stopWatch.Stop();
			Console.WriteLine(string.Format("Done merging in {0} sec.", stopWatch.Elapsed));
		}

		private static void JoinMp3File(string path, string[] filesToJoin, string newFile)
		{
			using (var fileStream = File.OpenWrite(Path.Combine(path, newFile)))
			{
				foreach (var file in filesToJoin)
				{
					var buffer = File.ReadAllBytes(Path.Combine(path, file));
					fileStream.Write(buffer, 0, buffer.Length);
				}

				fileStream.Flush();
			}
		}
    }
}
