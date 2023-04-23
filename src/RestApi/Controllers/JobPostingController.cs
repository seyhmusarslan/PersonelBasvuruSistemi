using System;
using Application.Dto.Common;
using Application.Dto.JobPosting;
using Application.Services.JobPostings;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers
{
    [ApiController]
    [Route("api/job-posting")]
    public class JobPostingController : ControllerBase
    {
        private readonly IJobPostingService _jobPostingService;

        public JobPostingController(IJobPostingService jobPostingService)
        {
            _jobPostingService = jobPostingService;
        }
        [HttpPost("create")]
        public async Task<IActionResult> Post([FromBody] JobPostingInputDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            };
            var result = await _jobPostingService.CreateJobPostingAsync(input);
            if(!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
            
        }
        [HttpGet("get/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            
            if(id == 0)
                return BadRequest();
            var result = await _jobPostingService.GetJobPostingByIdAsync(id);
            if(!result.IsSuccess)
                return BadRequest(result);
            return Ok(result);
            
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _jobPostingService.DeleteJobPostingByIdAsync(id);
            if(!result.IsSuccess)
                return BadRequest(result);
            return Ok();
        }

    }

}

