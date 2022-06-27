using CleanArchitecture.Data;
using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;

StreamerDbContext _dbContext = new();
await QueryStreaming();

async Task QueryStreaming()
{
    Streamer _streamer = new()
    {
        Name = "Amazon Prime",
        Url = "http:\\www.amazonprime.com"
    };

    _dbContext.Streamers!.Add(_streamer);

    await _dbContext.SaveChangesAsync();

    var _movies = new List<Video>
    {
        new Video
        {
            Name = "Mad Max",
            StreamerId = _streamer.Id
        },
        new Video
        {
            Name = "Batman",
            StreamerId = _streamer.Id
        },
        new Video
        {
            Name = "Crepusculo",
            StreamerId = _streamer.Id
        },
        new Video
        {
            Name = "Citizen Kane",
            StreamerId = _streamer.Id
        }
    };

    await _dbContext.Videos!.AddRangeAsync(_movies);
    await _dbContext.SaveChangesAsync();
}
