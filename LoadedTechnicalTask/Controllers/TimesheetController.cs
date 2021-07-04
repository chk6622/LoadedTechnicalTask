using LoadedTechnicalTask.Dto;
using LoadedTechnicalTask.Entities;
using LoadedTechnicalTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
        private readonly TimeclockContext _context;

        public TimesheetController(TimeclockContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get a time sheet by id
        /// </summary>
        /// <param name="id">The time sheet's id</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = nameof(GetTimesheetAsync))]
        public async Task<IActionResult> GetTimesheetAsync([Required] Guid id)
        {
            Timesheet timesheet = await _context.Timesheets.Where(e => e.Id == id).FirstOrDefaultAsync();

            return timesheet == null ? NotFound() : Ok(timesheet.ToTimesheetDto());
        }

        /// <summary>
        /// Staff clock in
        /// </summary>
        /// <param name="staffId">The staff's id</param>
        /// <returns></returns>
        [HttpPost("ClockIn/{staffId}")]
        public async Task<IActionResult> ClockIn([Required] Guid staffId)
        { 
            StaffMember staffMember = await _context.StaffMembers.Include(e => e.Timesheets).Where(e => e.Id == staffId).FirstOrDefaultAsync();
            if (staffMember == null)
            {
                return NotFound("There is not the staff!");
            }
            Timesheet timesheet = staffMember.Timesheets?.Where(e => e.ClockOut == null).FirstOrDefault();
            if (timesheet != null)
            {
                return BadRequest("Please clock out first!");
            }

            timesheet = new Timesheet()
            {
                ClockIn = DateTimeOffset.Now,
                StaffMember = staffMember,
            };
            await _context.Timesheets.AddAsync(timesheet);
            await _context.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetTimesheetAsync), new { Id = timesheet.Id }, timesheet.ToTimesheetDto());
        }

        /// <summary>
        /// Staff clock out
        /// </summary>
        /// <param name="staffId">The staff's id</param>
        /// <returns></returns>
        [HttpPost("ClockOut/{staffId}")]
        public async Task<IActionResult> ClockOut([Required] Guid staffId)
        {
            Timesheet timesheet = await _context.Timesheets.Where(e => e.StaffMemberId == staffId && e.ClockOut == null).FirstOrDefaultAsync();
            if (timesheet == null)
            {
                return BadRequest("Please clock in first!");
            }

            timesheet.ClockOut = DateTimeOffset.Now;
            await _context.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetTimesheetAsync), new { Id = timesheet.Id }, timesheet.ToTimesheetDto());
        }

        /// <summary>
        /// Update time sheet
        /// </summary>
        /// <param name="timesheetDto">New time sheet information</param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Update(TimesheetDto timesheetDto)
        {
            Timesheet newTimesheet = newTimesheet = timesheetDto.ToTimesheet();

            Timesheet oldTimesheet = await _context.Timesheets.Where(e => e.Id == newTimesheet.Id).FirstOrDefaultAsync();
            if (oldTimesheet == null)
            {
                return NotFound();
            }

            oldTimesheet.ClockIn = newTimesheet.ClockIn;
            oldTimesheet.ClockOut = newTimesheet.ClockOut;
            await _context.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetTimesheetAsync), new { Id = oldTimesheet.Id }, timesheetDto);
        }
    }
}
