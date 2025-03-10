using FeedbackPages.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackPages.Data;

public sealed class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> contextOptions) : base(contextOptions)
    {
        Database.EnsureCreated();
    }

    public DbSet<PageStats> Stats { get; set; }
    public DbSet<Admin> Admins { get; set; }
}