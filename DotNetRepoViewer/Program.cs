using System.Net.Http.Headers;
using System.Text.Json;
using DotNetRepoViewer;

using HttpClient client = new HttpClient();

// GitHub kräver User-Agent
client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("DotNetRepoViewer", "1.0"));

try
{
	// --- DEL 1: GitHub (G-nivå) ---
	Console.WriteLine("--- HÄMTAR DATA FRÅN GITHUB ---");
	string gitHubUrl = "https://api.github.com/orgs/dotnet/repos";

	await using Stream gitHubStream = await client.GetStreamAsync(gitHubUrl);
	var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(gitHubStream);

	if (repositories != null)
	{
		foreach (var repo in repositories)
		{
			Console.WriteLine($"Name: {repo.Name}");
			Console.WriteLine($"Homepage: {repo.Homepage}");
			Console.WriteLine($"GitHub: {repo.GitHubUrl}");
			Console.WriteLine($"Description: {repo.Description}");
			Console.WriteLine($"Watchers: {repo.Watchers}");
			Console.WriteLine($"Last push: {repo.LastPush}");
			Console.WriteLine();
		}
	}

	// --- DEL 2: Zippopotam (VG-nivå) ---
	Console.WriteLine("--- HÄMTAR DATA FRÅN ZIPPOPOTAM (VG) ---");
	string zipUrl = "https://api.zippopotam.us/us/07645"; // Montvale, NJ

	await using Stream zipStream = await client.GetStreamAsync(zipUrl);
	var zipData = await JsonSerializer.DeserializeAsync<ZippopotamResponse>(zipStream);

	if (zipData != null)
	{
		Console.WriteLine($"Postnummer: {zipData.PostCode}");
		Console.WriteLine($"Land: {zipData.Country} ({zipData.CountryAbbreviation})");

		if (zipData.Places != null && zipData.Places.Count > 0)
		{
			var place = zipData.Places[0];
			Console.WriteLine($"Stad: {place.PlaceName}, {place.State}");
			Console.WriteLine($"Latitud: {place.Latitude}");
			Console.WriteLine($"Longitud: {place.Longitude}");
		}
	}
}
catch (Exception ex)
{
	Console.WriteLine($"Ett fel uppstod: {ex.Message}");
}

Console.WriteLine("\nKörningen är klar. Tryck på en tangent för att avsluta.");
Console.ReadKey();