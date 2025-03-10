using FeedbackPages.Data;
using FeedbackPages.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackPages.Services;

public class StatsService(DataContext context) : IStatsService
{
    public async Task<List<PageStats>> GetAllStats()
    {
        var stats = await context.Stats.ToListAsync();
        return stats;
    }

    public async void UpdateStatById(int id)
    {
        var stat = await context.FindAsync<PageStats>(id);
        Console.WriteLine($"{id} .. {stat}");
        if (stat == null)
            return;
        
        stat.Count++;
        await context.SaveChangesAsync();
    }
}