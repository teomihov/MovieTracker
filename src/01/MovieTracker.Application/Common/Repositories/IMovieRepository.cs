using MovieTracker.Domain.Movies;

namespace MovieTracker.Application.Common.Repositories;

public interface IMovieRepository
{
    Task<int> CountAsync(CancellationToken cancellationToken = default);

    Task<IReadOnlyList<Movie>> GetPagedAsync(
        int skip,
        int take,
        CancellationToken cancellationToken = default);
}
