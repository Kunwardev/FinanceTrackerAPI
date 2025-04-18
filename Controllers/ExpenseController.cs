using FinanceTrackerAPI.DTO;
using FinanceTrackerAPI.Models;
using FinanceTrackerAPI.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace FinanceTrackerAPI.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class ExpenseController : ControllerBase{
    private readonly IExpenseService _expenseservice;

    public ExpenseController(IExpenseService expenseService){
        _expenseservice = expenseService;
    }

    [HttpGet]
    [Route("getall")]
    public async Task<ActionResult<IEnumerable<ExpenseDTO>>> getAll(){
        try{
            var expenses = await _expenseservice.GetAllAsync();
            return Ok(expenses);
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            throw ex;
        }
    }

    [HttpGet]
    [Route("get({id})")]
    public async Task<ActionResult<ExpenseDTO>> get(int id){
        try{
            var expense = await _expenseservice.Get(id);
            return Ok(expense);
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            throw ex;
        }
    }

    [HttpPost]
    [Route("add")]
    public async Task<ActionResult<ExpenseDTO>> add([FromBody] ExpenseDTO expenseDTO){
        try{
            var created = _expenseservice.CreateAsync(expenseDTO);
            Log.Information("Expense Create Successful");
            return Ok(created);
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            throw ex;
        }
    }

    [HttpDelete]
    [Route("delete({id})")]
    public async Task<ActionResult> delete(int id){
        try{
            var deleted = await _expenseservice.Delete(id);
            return deleted ? Ok() : NotFound();
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            throw ex;
        }
    }
}