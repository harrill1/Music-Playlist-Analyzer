using System;
using System.Collections.Generic;
using System.IO;

namespace MusicPlaylistAnalyzer
{
    public static class MusicInfoLoader
    {
        private static int NumItemsInRow = 8;

        public static List<MusicInfo> Load(string csvDataFilePath) {
            List<MusicInfo> musicInfoList = new List<MusicInfo>();

            try
            {
                using (var reader = new StreamReader(csvDataFilePath))
                {
                    int lineNumber = 0;
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        lineNumber++;
                        if (lineNumber == 1) continue;

                        var values = line.Split('\t');

                        if (values.Length != NumItemsInRow)
                        {
                            throw new Exception($"Row {lineNumber} contains {values.Length} values. It should contain {NumItemsInRow}.");
                        }
                        try
                        {
                            int name = String.Parse(values[0]);
                            int artist = String.Parse(values[1]);
                            int album = String.Parse(values[2]);
                            int genre = String.Parse(values[3]);
                            int size = Int32.Parse(values[4]);
                            int time = Int32.Parse(values[5]);
                            int year = Int32.Parse(values[6]);
                            int plays = Int32.Parse(values[7]);

                            MusicInfo musicInfo = new MusicInfo(name, artist, album, genre, size, time, year, plays);
                            musicInfoList.Add(musicInfo);
                        }
                        catch (FormatException e)
                        {
                            throw new Exception($"Row {lineNumber} contains invalid data. ({e.Message})");
                        }
                    }
                }
            } catch (Exception e){
                throw new Exception($"Unable to open {csvDataFilePath} ({e.Message}).");
            }

            return musicInfoList;
        }
    }
}



