# DotNetRepoViewer - Laboratory 4

This is a C# console application developed for the assignment "Laboratory 4: Consume Web API". The application demonstrates how to consume external REST services, deserialize JSON responses, and present the data to the user.

## 📝 Description

The program performs two main tasks sequentially:

1.  **Fetch GitHub Repositories (Pass Level / G):**
    The application connects to the GitHub API to retrieve a list of repositories belonging to the `.NET Foundation`. For each project, it displays the name, description, URL, number of watchers, and the last push date.

2.  **Fetch Location Data (High Pass Level / VG):**
    The application connects to the Zippopotam API to retrieve geographical information (city, latitude, longitude) for the postal code `07645` (Montvale, New Jersey, USA).

## 🚀 Technologies

* .NET (C#)
* `System.Net.Http` (HttpClient) for HTTP requests.
* `System.Text.Json` for JSON deserialization.

## ⚙️ Installation and Usage

No specific configuration or API keys are required to run this application.

1.  Clone this repository or download the source code.
2.  Open the solution file `Labb4_KonsumeraAPI.sln` in Visual Studio.
3.  Build the solution.
4.  Run the application by pressing `F5` or clicking **Start**.

## 📡 APIs Used

* **GitHub API:** `https://api.github.com/orgs/dotnet/repos`
    * Used to list repositories.
    * *Note:* A User-Agent header is included in the request as required by GitHub policies.
* **Zippopotam API:** `https://api.zippopotam.us/us/07645`
    * Used for the additional assignment task to fetch data for Montvale, NJ.