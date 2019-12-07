﻿using System;

namespace MusicPlaylistAnalyzer
{
    class Program
    {
        static void Main(string[] args)
        {
			if (args.Length != 2)
			{
				Console.WriteLine("MusicPlaylistAnalyzer <music_playlist_file_path> <report_file_path>");
				Environment.Exit(1);
			}

			string csvDataFilePath = args[0];
			string reportFilePath = args[1];

			List<MusicInfo> musicInfoList = null;
			try
			{
				musicInfoList = MusicInfoLoader.Load(csvDataFilePath);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Environment.Exit(2);
			}

			var report = MusicInfoReport.GenerateText(musicInfoList);

			try
			{
				System.IO.File.WriteAllText(reportFilePath, report);
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
				Environment.Exit(3);
			}
    }
}
