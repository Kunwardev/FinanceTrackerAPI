using AutoMapper;
using FinanceTrackerAPI.Data.Repositories;
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
public class IncomeController : ControllerBase
{
    private readonly IIncomeService _incomeService;

    public IncomeController(IIncomeService incomeService){
       _incomeService = incomeService;
    }

    [HttpGet]
    [Route("getall")]
    public async Task<ActionResult<IEnumerable<IncomeDTO>>> GetAll(){
        try{
            var result = await _incomeService.GetAllAsync();
            return Ok(result);
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            return BadRequest(ex);
        }
    }

    [HttpGet("get({id})")]
    public async Task<ActionResult<IncomeDTO>> Get(int id){
        try{
            var income = _incomeService.Get(id);
            return Ok(income);
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            return BadRequest(ex);
        }
    }

    [HttpDelete("delete{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try{
            var deleted = await _incomeService.Delete(id);
            return deleted ? NoContent() : NotFound();
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            return null;
        }

    }

    [HttpPost]
    [Route("add")]
    public async Task<ActionResult<IncomeDTO>> Create([FromBody] IncomeDTO incomeDTO){
        try{
            var created = await _incomeService.CreateAsync(incomeDTO);
            return Ok(created);
        }catch(Exception ex){
            Log.Error(ex, ex.Message);
            return null;
        }
        
    }
}