using FinanceTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FinanceTrackerAPI.Data.Repositories;

public class IncomeRepository : IIncomeRepository
{
    private readonly FinanceContext _context;

    public IncomeRepository(FinanceContext context){
        _context = context;
    }
    public async Task<Income> AddAsync(Income income)
    {
        try{
            Log.Information("Adding Income to the Database");
            await _context.AddAsync(income);
            await _context.SaveChangesAsync();
            Log.Information("Save Successful");
            return income;
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
        }
        return null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try{
            var income = await _context.Incomes.FindAsync(id);
            if(income == null)
                return false;
            _context.Incomes.Remove(income);
            await _context.SaveChangesAsync();
            return true;
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
        }
        return false;
    }

    public async Task<IEnumerable<Income>> GetAllAsync()
    {
        try{
            Log.Information("Getting All the Data");
            var result = await _context.Incomes.ToListAsync();
            Log.Information("Download Successful with count of "+result.Count);
            return result;
        } catch(Exception ex){
            Log.Error(ex, ex.Message);
        }
        return null;
    }

    public async Task<Income?> GetByIdAsync(int id)
    {
        try{
            Log.Information("Fetching Data with Id: "+ id);
            var result = await _context.Incomes.FindAsync(id);
            Log.Information("Fetch Successful");
            return result;
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
        }
        return null;
    }

    public async Task<Income?> UpdateAsync(Income income)
    {
        try{
            Log.Information("Updating Income");
            var updatedincome = await _context.Incomes.FindAsync(income.id);
            if(updatedincome == null){
                Log.Warning("Data not found to Update");
                return null;
            }
            updatedincome.amount = income.amount;
            updatedincome.source = income.source;
            updatedincome.datetime = income.datetime;
            await _context.SaveChangesAsync();
            return updatedincome;

        }catch(Exception ex){
            Log.Error(ex, ex.Message);
        }
        return null;
    }
}