using System.Text.Json.Serialization;

namespace DotNetRepoViewer
{
	public class Repository
	{
		// Attributet [JsonPropertyName] används för att mappa fältnamnen i JSON-datan till egenskaperna i denna klass.
		// Detta är nödvändigt eftersom JSON ofta använder små bokstäver (t.ex. "name"), 
		// medan C#-konventionen är stor bokstav (PascalCase).

		[JsonPropertyName("name")]
		public string? Name { get; set; }

		[JsonPropertyName("description")]
		public string? Description { get; set; }

		// Mappar JSON-fältet "html_url" till ett mer beskrivande namn i C#-koden.
		[JsonPropertyName("html_url")]
		public string? GitHubUrl { get; set; }

		[JsonPropertyName("homepage")]
		public string? Homepage { get; set; }

		[JsonPropertyName("watchers")]
		public int Watchers { get; set; }

		[JsonPropertyName("pushed_at")]
		public DateTime LastPush { get; set; }
	}
}