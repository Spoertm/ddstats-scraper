using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DdstatsScraper.Responses
{
	public class DdstatsResponse
	{
		[JsonProperty("player_id")]
		public int PlayerId { get; set; }

		[JsonProperty("player_name")]
		public string PlayerName { get; set; }

		[JsonProperty("total_pages")]
		public int TotalPages { get; set; }

		[JsonProperty("total_game_count")]
		public int TotalGameCount { get; set; }

		[JsonProperty("page_number")]
		public int PageNumber { get; set; }

		[JsonProperty("page_size")]
		public int PageSize { get; set; }

		[JsonProperty("game_count")]
		public int GameCount { get; set; }

		[JsonProperty("games")]
		public List<Game> Games { get; set; }
	}

	public class Game
	{
		[JsonProperty("player_name")]
		public string PlayerName { get; set; }

		[JsonProperty("id")]
		public int Id { get; set; }

		[JsonProperty("player_id")]
		public int PlayerId { get; set; }

		[JsonProperty("player_game_time")]
		public int PlayerGameTime { get; set; }

		[JsonProperty("granularity")]
		public int Granularity { get; set; }

		[JsonProperty("game_time")]
		public double GameTime { get; set; }

		[JsonProperty("death_type")]
		public string DeathType { get; set; }

		[JsonProperty("gems")]
		public int Gems { get; set; }

		[JsonProperty("homing_daggers")]
		public int HomingDaggers { get; set; }

		[JsonProperty("daggers_fired")]
		public int DaggersFired { get; set; }

		[JsonProperty("daggers_hit")]
		public int DaggersHit { get; set; }

		[JsonProperty("accuracy")]
		public double Accuracy { get; set; }

		[JsonProperty("enemies_alive")]
		public int EnemiesAlive { get; set; }

		[JsonProperty("enemies_killed")]
		public int EnemiesKilled { get; set; }

		[JsonProperty("time_stamp")]
		public DateTime TimeStamp { get; set; }

		[JsonProperty("replay_player_id")]
		public int ReplayPlayerId { get; set; }

		[JsonProperty("replay_player_name")]
		public string ReplayPlayerName { get; set; }

		[JsonProperty("spawnset")]
		public string Spawnset { get; set; }

		[JsonProperty("version")]
		public string Version { get; set; }

		[JsonProperty("level_two_time")]
		public double LevelTwoTime { get; set; }

		[JsonProperty("level_three_time")]
		public double LevelThreeTime { get; set; }

		[JsonProperty("level_four_time")]
		public double LevelFourTime { get; set; }

		[JsonProperty("levi_down_time")]
		public double LeviDownTime { get; set; }

		[JsonProperty("orb_down_time")]
		public double OrbDownTime { get; set; }

		[JsonProperty("homing_daggers_max_time")]
		public double HomingDaggersMaxTime { get; set; }

		[JsonProperty("enemies_alive_max_time")]
		public double EnemiesAliveMaxTime { get; set; }

		[JsonProperty("homing_daggers_max")]
		public int HomingDaggersMax { get; set; }

		[JsonProperty("enemies_alive_max")]
		public int EnemiesAliveMax { get; set; }

		[JsonProperty("is_replay")]
		public bool IsReplay { get; set; }
	}
}
