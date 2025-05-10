using DdstatsScraper.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DdstatsScraper;

public static class RunAnalyzer
{
	private const float _level2Threshold = 30, _level3Threshold = 100, _level4Threshold = 200, _leviDownThreshold = 350, _orbDownThreshold = 375;

	public static List<AllStatsResponse> GetAllStats(Game[] games)
	{
		List<AllStatsResponse> statList =
		[
			new("Fastest level 2", FastestStat(games, game => game.LevelTwoTime, _level2Threshold)),
			new("Fastest level 3", FastestStat(games, game => game.LevelThreeTime, _level3Threshold)),
			new("Fastest level 4", FastestStat(games, game => game.LevelFourTime, _level4Threshold)),
			new("Fastest levi down", FastestStat(games, game => game.LeviDownTime, _leviDownThreshold)),
			new("Fastest orb down", FastestStat(games, game => game.OrbDownTime, _orbDownThreshold)),
			new("Longest run", LongestRun(games)),
			new("Longest pacifist run", LongestPacifist(games)),
			new("Highest homing peak run", HighestHomingPeak(games)),
			new("Longest no farm run", LongestNoFarm(games)),
		];

		return statList;
	}

	private static StatResponse FastestStat(Game[] games, Func<Game, double> func, float threshold)
	{
		double fastestStat = double.MaxValue;
		int index = 0;
		for (int i = 0; i < games.Length; i++)
		{
			double current = func(games[i]);
			if (current < threshold || current > fastestStat)
				continue;

			fastestStat = current;
			index = i;
		}

		return new(games[index], fastestStat);
	}

	private static StatResponse LongestRun(Game[] games)
	{
		Game? game = games.OrderByDescending(g => g.GameTime).FirstOrDefault();
		return new(game, game?.GameTime);
	}

	private static StatResponse LongestPacifist(Game[] games)
	{
		Game? game = games.Where(g => g.EnemiesKilled == 0).OrderByDescending(g => g.GameTime).FirstOrDefault();
		return new(game, game?.GameTime);
	}

	private static StatResponse HighestHomingPeak(Game[] games)
	{
		Game? game = games.OrderByDescending(g => g.HomingDaggersMax).FirstOrDefault();
		return new(game, game?.HomingDaggersMax);
	}

	private static StatResponse LongestNoFarm(Game[] games)
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
