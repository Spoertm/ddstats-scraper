using DdstatsScraper.Responses;
using System.Collections.Generic;
using System.Linq;

namespace DdstatsScraper
{
	public static class RunAnalyzer
	{
		private const float _level2Threshold = 30, _level3Threshold = 100, _level4Threshold = 200, _leviDownThreshold = 350, _orbDownThreshold = 375;

		public static List<AllStatsResponse> GetAllStats(Game[] games)
		{
			List<AllStatsResponse> statList = new()
			{
				new("Fastest level 2", FastestLevel2(games)),
				new("Fastest level 3", FastestLevel3(games)),
				new("Fastest level 4", FastestLevel4(games)),
				new("Fastest levi down", FastestLeviDown(games)),
				new("Fastest orb down", FastestOrbDown(games)),
				new("Longest run", LongestRun(games)),
				new("Longest pacifist run", LongestPacifist(games)),
				new("Highest homing peak run", HighestHomingPeak(games)),
				new("Longest no farm run", LongestNoFarm(games)),
			};

			return statList;
		}

		public static StatResponse FastestLevel2(Game[] games)
		{
			double fastestLevel2 = double.MaxValue;
			int index = 0;
			for (int i = 0; i < games.Length; i++)
			{
				if (games[i].LevelTwoTime < _level2Threshold || games[i].LevelTwoTime > fastestLevel2)
					continue;

				fastestLevel2 = games[i].LevelTwoTime;
				index = i;
			}

			return new(games[index], fastestLevel2);
		}

		public static StatResponse FastestLevel3(Game[] games)
		{
			double fastestLevel3 = double.MaxValue;
			int index = 0;
			for (int i = 0; i < games.Length; i++)
			{
				if (games[i].LevelThreeTime < _level3Threshold || games[i].LevelThreeTime > fastestLevel3)
					continue;

				fastestLevel3 = games[i].LevelThreeTime;
				index = i;
			}

			return new(games[index], fastestLevel3);
		}

		public static StatResponse FastestLevel4(Game[] games)
		{
			double fastestLevel4 = double.MaxValue;
			int index = 0;
			for (int i = 0; i < games.Length; i++)
			{
				if (games[i].LevelFourTime < _level4Threshold || games[i].LevelFourTime > fastestLevel4)
					continue;

				fastestLevel4 = games[i].LevelFourTime;
				index = i;
			}

			return new(games[index], fastestLevel4);
		}

		public static StatResponse FastestLeviDown(Game[] games)
		{
			double fastestLeviDown = double.MaxValue;
			int index = 0;
			for (int i = 0; i < games.Length; i++)
			{
				if (games[i].LeviDownTime < _leviDownThreshold || games[i].LeviDownTime > fastestLeviDown)
					continue;

				fastestLeviDown = games[i].LeviDownTime;
				index = i;
			}

			return new(games[index], fastestLeviDown);
		}

		public static StatResponse FastestOrbDown(Game[] games)
		{
			double fastestOrbDown = double.MaxValue;
			int index = 0;
			for (int i = 0; i < games.Length; i++)
			{
				if (games[i].OrbDownTime < _orbDownThreshold || games[i].OrbDownTime > fastestOrbDown)
					continue;

				fastestOrbDown = games[i].OrbDownTime;
				index = i;
			}

			return new(games[index], fastestOrbDown);
		}

		public static StatResponse LongestRun(Game[] games)
		{
			Game? game = games.OrderByDescending(g => g.GameTime).FirstOrDefault();
			return new(game, game?.GameTime);
		}

		public static StatResponse LongestPacifist(Game[] games)
		{
			Game? game = games.Where(g => g.EnemiesKilled == 0).OrderByDescending(g => g.GameTime).FirstOrDefault();
			return new(game, game?.GameTime);
		}

		public static StatResponse HighestHomingPeak(Game[] games)
		{
			Game? game = games.OrderByDescending(g => g.HomingDaggersMax).FirstOrDefault();
			return new(game, game?.HomingDaggersMax);
		}

		public static StatResponse LongestNoFarm(Game[] games)
		{
			double longestNoFarm = 0;
			int index = 0;
			for (int i = 0; i < games.Length; i++)
			{
				if (games[i].LevelFourTime < 265 || games[i].LevelThreeTime < 150 || games[i].GameTime < longestNoFarm)
					continue;

				longestNoFarm = games[i].GameTime;
				index = i;
			}

			return new(games[index], longestNoFarm);
		}
	}
}
