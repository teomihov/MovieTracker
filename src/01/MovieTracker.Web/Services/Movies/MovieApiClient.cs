using System.Net.Http.Json;
using MovieTracker.Web.Models.Movies;

namespace MovieTracker.Web.Services.Movies;

public sealed class MovieApiClient(HttpClient httpClient)
{
    public async Task<MovieListResponseModel> GetMoviesAsync(int page = 1, int pageSize = 24, CancellationToken cancellationToken = default)
    {
        var response = await httpClient.GetAsync($"api/movies?page={page}&pageSize={pageSize}", cancellationToken);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<MovieListResponseModel>(cancellationToken)
            ?? throw new InvalidOperationException("The movie API returned an empty response.");
    }
}
