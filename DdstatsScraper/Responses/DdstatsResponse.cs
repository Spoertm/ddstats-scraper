using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace DdstatsScraper.Responses;

public record DdstatsResponse
{
	[JsonPropertyName("player_id")]
	public int PlayerId { get; set; }

	[JsonPropertyName("player_name")]
	public required string PlayerName { get; set; }

	[JsonPropertyName("total_pages")]
	public int TotalPages { get; set; }

	[JsonPropertyName("total_game_count")]
	public int TotalGameCount { get; set; }

	[JsonPropertyName("page_number")]
	public int PageNumber { get; set; }

	[JsonPropertyName("page_size")]
	public int PageSize { get; set; }

	[JsonPropertyName("game_count")]
	public int GameCount { get; set; }

	[JsonPropertyName("games")]
	public List<Game> Games { get; set; } = [];
}

public record Game
{
	[JsonPropertyName("player_name")]
	public required string PlayerName { get; set; }

	[JsonPropertyName("id")]
	public int Id { get; set; }

	[JsonPropertyName("player_id")]
	public int PlayerId { get; set; }

	[JsonPropertyName("player_game_time")]
	public int PlayerGameTime { get; set; }

	[JsonPropertyName("granularity")]
	public int Granularity { get; set; }

	[JsonPropertyName("game_time")]
	public double GameTime { get; set; }

	[JsonPropertyName("death_type")]
	public required string DeathType { get; set; }

	[JsonPropertyName("gems")]
	public int Gems { get; set; }

	[JsonPropertyName("homing_daggers")]
	public int HomingDaggers { get; set; }

	[JsonPropertyName("daggers_fired")]
	public int DaggersFired { get; set; }

	[JsonPropertyName("daggers_hit")]
	public int DaggersHit { get; set; }

	[JsonPropertyName("accuracy")]
	public double Accuracy { get; set; }

	[JsonPropertyName("enemies_alive")]
	public int EnemiesAlive { get; set; }

	[JsonPropertyName("enemies_killed")]
	public int EnemiesKilled { get; set; }

	[JsonPropertyName("time_stamp")]
	public DateTime TimeStamp { get; set; }

	[JsonPropertyName("replay_player_id")]
	public int ReplayPlayerId { get; set; }

	[JsonPropertyName("replay_player_name")]
	public string? ReplayPlayerName { get; set; }

	[JsonPropertyName("spawnset")]
	public required string Spawnset { get; set; }

	[JsonPropertyName("version")]
	public required string Version { get; set; }

	[JsonPropertyName("level_two_time")]
	public double LevelTwoTime { get; set; }

	[JsonPropertyName("level_three_time")]
	public double LevelThreeTime { get; set; }

	[JsonPropertyName("level_four_time")]
	public double LevelFourTime { get; set; }

	[JsonPropertyName("levi_down_time")]
	public double LeviDownTime { get; set; }

	[JsonPropertyName("orb_down_time")]
	public double OrbDownTime { get; set; }

	[JsonPropertyName("homing_daggers_max_time")]
	public double HomingDaggersMaxTime { get; set; }

	[JsonPropertyName("enemies_alive_max_time")]
	public double EnemiesAliveMaxTime { get; set; }

	[JsonPropertyName("homing_daggers_max")]
	public int HomingDaggersMax { get; set; }

	[JsonPropertyName("enemies_alive_max")]
	public int EnemiesAliveMax { get; set; }

	[JsonPropertyName("is_replay")]
	public bool IsReplay { get; set; }
}
