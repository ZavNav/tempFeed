using FeedbackPages.Entities;

namespace FeedbackPages.Services;

public interface IStatsService
{
    Task<List<PageStats>> GetAllStats();
    void UpdateStatById(int id);
}