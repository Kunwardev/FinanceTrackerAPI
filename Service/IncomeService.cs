using AutoMapper;
using FinanceTrackerAPI.Data.Repositories;
using FinanceTrackerAPI.DTO;
using FinanceTrackerAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Serilog;

namespace FinanceTrackerAPI.Service;

public class IncomeService : IIncomeService
{
    private readonly IIncomeRepository _repo;
    private readonly IMapper _mapper;

    public IncomeService(IIncomeRepository repo, IMapper mapper){
        _repo = repo;
        _mapper = mapper;
    }
    public async Task<IncomeDTO> CreateAsync(IncomeDTO incomeDTO)
    {
        try{
            var income = _mapper.Map<Income>(incomeDTO);
            var created = await _repo.AddAsync(income);
            Log.Information("Received income: {@incomeDTO}", incomeDTO);
            return _mapper.Map<IncomeDTO>(created);
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            return null;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try{
            Log.Information("Deleting Id: "+id);
            var deleted = await _repo.DeleteAsync(id);
            return deleted;
         }catch(Exception ex){
            Log.Error(ex, ex.Message);
            return false;
        }
    }

    public async Task<IncomeDTO> Get(int id)
    {
        try{
            var income = await _repo.GetByIdAsync(id);
            return _mapper.Map<IncomeDTO>(income);
        } catch(Exception ex){
            Log.Error(ex, ex.Message);
            return null;
        }
    }

    public async Task<IEnumerable<IncomeDTO>> GetAllAsync()
    {
        try{
            var incomes = await _repo.GetAllAsync();
            Log.Information("Fetched {count} incomes", incomes.Count());
            return _mapper.Map<IEnumerable<IncomeDTO>>(incomes);
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            return null;
        }
    }
}