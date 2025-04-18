using FinanceTrackerAPI.DTO;
using FinanceTrackerAPI.Models;

namespace FinanceTrackerAPI.Service;

public interface IExpenseService{
    Task<IEnumerable<ExpenseDTO>> GetAllAsync();
    Task<ExpenseDTO> CreateAsync(ExpenseDTO dto);
    Task<ExpenseDTO> Get(int id);
    Task<Boolean> Delete(int id);

}