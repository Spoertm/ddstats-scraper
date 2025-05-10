using DdstatsScraper;
using DdstatsScraper.Responses;
using System;
using System.Collections.Generic;
using System.Linq;

Console.WindowWidth = 120;
while (true)
{
	uint playerId = 0;
	while (playerId == 0)
	{
		Console.Write("Enter your player ID and press enter: ");
		_ = uint.TryParse(Console.ReadLine(), out playerId);
	}

	Console.WriteLine($"\nFetching games for player with ID {playerId}...");
	DdstatsResponse? response = await CacheHelper.GetPlayerData(playerId);
	if (response is null)
	{
		Console.WriteLine("Failed to obtain player data.");
		return;
	}

	Console.WriteLine($"Found {response.TotalGameCount} games for player '{response.PlayerName}'.{Environment.NewLine}");
	if (response.TotalGameCount < 1)
		continue;

	Game[] games = response.Games
		.Where(g => g.Spawnset == "v3")
		.ToArray();

	List<AllStatsResponse> statsList = RunAnalyzer.GetAllStats(games);
	for (int i = 0; i < statsList.Count; i++)
		Console.WriteLine($"{statsList[i].StatName,-24} {(statsList[i].StatResponse.Run == null ? "N/A" : $"https://ddstats.com/games/{statsList[i].StatResponse.Run?.Id}"),-32} {statsList[i].StatResponse.StatValue,20}");

	Console.WriteLine();
}
