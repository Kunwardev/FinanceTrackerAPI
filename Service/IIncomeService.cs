using FinanceTrackerAPI.DTO;
using FinanceTrackerAPI.Models;

namespace FinanceTrackerAPI.Service;

public interface IIncomeService{
    Task<IEnumerable<IncomeDTO>> GetAllAsync();
    Task<IncomeDTO> CreateAsync(IncomeDTO dto);
    Task<IncomeDTO> Get(int id);
    Task<Boolean> Delete(int id);

}