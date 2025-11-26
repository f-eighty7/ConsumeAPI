using System.Text.Json.Serialization;

namespace DotNetRepoViewer
{
	// Huvudklassen för svaret från Zippopotam
	public class ZippopotamResponse
	{
		[JsonPropertyName("post code")]
		public string? PostCode { get; set; }

		[JsonPropertyName("country")]
		public string? Country { get; set; }

		[JsonPropertyName("country abbreviation")]
		public string? CountryAbbreviation { get; set; }

		[JsonPropertyName("places")]
		public List<Place>? Places { get; set; }
	}

	// En hjälpklass eftersom "places" är en lista inuti svaret
	public class Place
	{
		[JsonPropertyName("place name")]
		public string? PlaceName { get; set; }

		[JsonPropertyName("longitude")]
		public string? Longitude { get; set; }

		[JsonPropertyName("latitude")]
		public string? Latitude { get; set; }

		[JsonPropertyName("state")]
		public string? State { get; set; }
	}
}