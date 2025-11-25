using System.Net.Http.Headers;
using System.Text.Json;
using DotNetRepoViewer;

string url = "https://api.github.com/orgs/dotnet/repos";

using HttpClient client = new HttpClient();

// GitHub kräver en "User-Agent" header.
// Utan denna returneras felmeddelande 403 Forbidden.
client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("DotNetRepoViewer", "1.0"));

Console.WriteLine("Laddar data från GitHub...");

try
{
	// Hämta datan som en ström (Stream) för att spara minne jämfört med att hämta hela strängen.
	await using Stream stream = await client.GetStreamAsync(url);

	// Deserialisera JSON-strömmen direkt till en lista av Repository-objekt.
	var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(stream);

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
}
catch (Exception ex)
{
	Console.WriteLine($"Ett fel uppstod: {ex.Message}");
}

Console.WriteLine("Tryck på en tangent för att avsluta.");
Console.ReadKey();