using Application.Dto.Common;
using Application.Dto.JobType;
using Application.Services.JobTypes;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers;

[ApiController]
[Route("api/job-type")]
public class JobTypeController : ControllerBase
{
    private readonly IJobTypeService _jobTypeService;

    public JobTypeController(IJobTypeService jobTypeService)
    {
        _jobTypeService = jobTypeService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> Post([FromBody] JobTypeInputDto input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        };
        var result = await _jobTypeService.CreateJobTypeAsync(input);
        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);

    }
   
    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(int id)
    {

        if (id == 0)
            return BadRequest();
        var result = await _jobTypeService.GetJobTypeByIdAsync(id);
        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);

    }
    
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _jobTypeService.DeleteJobTypeByIdAsync(id);
        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok();
    }
    
    [HttpGet("get-all")]
    public async Task<IActionResult> Get()
    {
        var result = await _jobTypeService.GetJobTypesAsync();
        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);
    }
   
    [HttpPut("update/{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] JobTypeInputDto input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(
                new ResponseMessageDto
                {
                    Message = "Invalid input",
                    IsSuccess = false,
                    Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage))
                });
        };
        var jobType = await _jobTypeService.GetJobTypeByIdAsync(id);
        if (!jobType.IsSuccess)
            return BadRequest(jobType);
        var result = await _jobTypeService.UpdateJobTypeAsync(id, input);
        if (!result.IsSuccess)
            return BadRequest(result);
        return Ok(result);
    }
}
