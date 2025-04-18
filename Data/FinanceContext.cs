using FinanceTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceTrackerAPI.Data;

public class FinanceContext : DbContext
{
    public FinanceContext(DbContextOptions<FinanceContext> options): base(options){}

    public DbSet<Income> Incomes {get; set;}
    public DbSet<Expense> Expenses{get; set;}
    public DbSet<User> users{get; set;}

}