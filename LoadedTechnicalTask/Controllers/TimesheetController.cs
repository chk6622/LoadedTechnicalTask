using LoadedTechnicalTask.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace LoadedTechnicalTask.Controllers
{
    /// <summary>
    /// Time sheet end points.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class TimesheetController : Controller
    {
        /// <summary>
        /// Get a time sheet by id
        /// </summary>
        /// <param name="id">The time sheet's id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetTimesheetAsync))]
        public async Task<IActionResult> GetTimesheetAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Staff clock in
        /// </summary>
        /// <param name="staffId">The staff's id</param>
        /// <returns></returns>
        [HttpPost("ClockIn/{staffId}")]
        public async Task<IActionResult> ClockIn(string staffId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Staff clock out
        /// </summary>
        /// <param name="staffId">The staff's id</param>
        /// <returns></returns>
        [HttpPost("ClockOut/{staffId}")]
        public async Task<IActionResult> ClockOut(string staffId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update time sheet
        /// </summary>
        /// <param name="timesheetDto">New time sheet information</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(TimesheetDto timesheetDto)
        {
            throw new NotImplementedException();
        }
    }
}
