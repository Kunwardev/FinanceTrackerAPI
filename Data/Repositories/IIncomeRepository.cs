using FinanceTrackerAPI.Models;

namespace FinanceTrackerAPI.Data.Repositories;


public interface IIncomeRepository
{
    Task<IEnumerable<Income>> GetAllAsync();
    Task<Income?> GetByIdAsync(int id);
    Task<Income> AddAsync(Income income);
    Task<Income?> UpdateAsync(Income income);
    Task<bool> DeleteAsync(int id);
}