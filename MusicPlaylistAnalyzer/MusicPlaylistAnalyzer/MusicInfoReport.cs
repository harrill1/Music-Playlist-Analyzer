using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MusicPlaylistAnalyzer
{
    public static class MusicInfoReport
    {
        public static string GenerateText(List<CrimeStats> musicInfoList)
        {
            string report = "Music Playlist Report\n\n";

            if (musicInfoList.Count() < 1)
            {
                report += "No data is available.\n";

                return report;
            }

            var over200Plays = (from musicInfo in musicInfoList select musicInfo.Plays > 200 select musicInfo);

            report += $"Songs that received 200 or more plays:\n";
            if (over200Plays > 0)
			{
                foreach (var play in over200Plays)
				{
                    report += play + "\n"
				}
				report += "\n";
                
			} else
			{
				report += "not available\n";
			}


            report += "Number of Alternative songs:\n";
            var alternativeSongs = from musicInfo in musicInfoList where musicInfo.Genre == "alternative" select musicInfo;
            if (alternativeSongs.Count() > 0)
            {
                report += alternativeSongs.count + "\n";
            }
            else
            {
                report += "not available\n";
            }

			report += "Number of Hip-Hop/Rap songs:\n";
			var rapSongs = from musicInfo in musicInfoList where musicInfo.Genre == "Hip-Hop" | musicInfo.Genre == "Rap" select musicInfo;
			if (rapSongs.Count() > 0)
			{
				report += rapSongs.count + "\n";
			}
			else
			{
				report += "not available\n";
			}

			report += "Songs from the album Welcome to the Fishbowl: ";
			var fishbowlSongs = from musicInfo in musicInfoList where musicInfo.Album == "Welcome to the Fishbowl" select musicInfo;
			if (fishbowlSongs > 0)
			{
				foreach (var song in fishbowlSongs)
				{
					report += song + "\n"
				}
				report += "\n";

			}
			else
			{
				report += "not available\n";
			}
			report += "Songs from before 1970:\n";
			var pre1970Songs = from musicInfo in musicInfoList where musicInfo.Year <= 1970 select musicInfo;
			if (pre1970Songs > 0)
			{
				foreach (var song in pre1970Songs)
				{
					report += song + "\n"
				}
				report += "\n";

			}
			else
			{
				report += "not available\n";
			}

			report += "Song names longer than 85 characters:\n";
			var longNamedSongs = from musicInfo in musicInfoList where musicInfo.Name.Length > 85 select musicInfo;
			if (longNamedSongs > 0)
			{
				foreach (var song in longNamedSongs)
				{
					report += song + "\n"
				}
				report += "\n";

			}
			else
			{
				report += "not available\n";
			}

            report += "Longest song: "

			var longNamedSongs = from musicInfo in musicInfoList where musicInfo.Name.Length > 85 order by musicInfo.Name.Length decending select musicInfo;


			report += longNamedSongs[0];

            return report;
        }
    }
}
