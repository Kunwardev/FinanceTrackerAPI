using FinanceTrackerAPI.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace FinanceTrackerAPI.Data.Repositories;

public class ExpenseRepository: IExpenseRepository{
    private readonly FinanceContext _context;

    public ExpenseRepository(FinanceContext context){
        _context = context;
    }

    public async Task<Expense> AddAsync(Expense expense)
    {
        try{
            Log.Information("Adding Income to the Database");
            await _context.AddAsync(expense);
            await _context.SaveChangesAsync();
            Log.Information("Save Successful");
            return expense;
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
        }
        return null;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        try{
            var expense = await _context.Expenses.FindAsync(id);
            if(expense == null)
                return false;
            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();
            return true;
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
        }
        return false;
    }

    public async Task<IEnumerable<Expense>> GetAllAsync()
    {
        try{
            Log.Information("Getting all the data");
            var expenses = await _context.Expenses.ToListAsync();
            Log.Information("Number of Expenses: {count}", expenses.Count);
            return expenses;
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            return null;
        }
    }

    public async Task<Expense> GetByIdAsync(int id)
    {
        try{
            Log.Information("Fetching Expense with id: {id}", id);
            var expense = await _context.Expenses.FindAsync(id);
            return expense;
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            throw ex;
        }
    }

    public Task<Expense?> UpdateAsync(Expense expense)
    {
        throw new NotImplementedException();
    }
}