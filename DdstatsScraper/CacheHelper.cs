using DdstatsScraper.Responses;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace DdstatsScraper
{
	public static class CacheHelper
	{
		private const string _playerCacheFolderName = "PlayerCache";

		public static async Task<DdstatsResponse?> GetPlayerData(uint playerId)
		{
			Directory.CreateDirectory(_playerCacheFolderName);
			string cachePath = Path.Combine(_playerCacheFolderName, $"{playerId}.json");
			if (File.Exists(cachePath))
			{
				Console.WriteLine("Found player cache.");
				return JsonConvert.DeserializeObject<DdstatsResponse>(await File.ReadAllTextAsync(cachePath));
			}

			Console.WriteLine("Requesting player data...");
			const int pageSize = int.MaxValue;
			using HttpClient client = new();
			string responseString = await client.GetStringAsync($"https://ddstats.com/api/v2/game/recent?player_id={playerId}&page_size={pageSize}&page_num=1");
			DdstatsResponse? response = JsonConvert.DeserializeObject<DdstatsResponse>(responseString);
			if (response?.Games is null)
			{
				Console.WriteLine("Failed to request data.");
				return null;
			}

			if (response?.GameCount < 1)
				return response;

			await File.WriteAllTextAsync(cachePath, responseString);
			return response;
		}
	}
}
