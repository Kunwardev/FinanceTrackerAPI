using AutoMapper;
using FinanceTrackerAPI.Data.Repositories;
using FinanceTrackerAPI.DTO;
using FinanceTrackerAPI.Models;
using Serilog;

namespace FinanceTrackerAPI.Service;

public class ExpenseService : IExpenseService
{
    private readonly IExpenseRepository _repo;
    private readonly IMapper _mapper;

    public ExpenseService(IExpenseRepository repo, IMapper mapper){
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<ExpenseDTO> CreateAsync(ExpenseDTO dto)
    {
        try{
            var expense = _mapper.Map<Expense>(dto);
            await _repo.AddAsync(expense);
            return dto;
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            throw ex;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try{
            Log.Information("Deleting Id: {id}", id);
            return await _repo.DeleteAsync(id);
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            throw ex;
        }
    }

    public async Task<ExpenseDTO> Get(int id)
    {
        try{
            var expense = await _repo.GetByIdAsync(id);
            Log.Information("Get Successful of Id: {id}", id);
            return _mapper.Map<ExpenseDTO>(expense);
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            throw ex;
        }
    }

    public async Task<IEnumerable<ExpenseDTO>> GetAllAsync()
    {
        try{
            var expenses = await _repo.GetAllAsync();
            Log.Information("Count of Expenses: {count} ", expenses.Count());
            return _mapper.Map<IEnumerable<ExpenseDTO>>(expenses);
        }
        catch(Exception ex){
            Log.Error(ex, ex.Message);
            throw ex;
        }
    }
}