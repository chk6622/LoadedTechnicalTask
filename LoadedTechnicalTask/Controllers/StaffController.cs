using LoadedTechnicalTask.Dto;
using LoadedTechnicalTask.Entities;
using LoadedTechnicalTask.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoadedTechnicalTask.Controllers
{
    /// <summary>
    /// Staff member end points.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class StaffController : Controller
    {
        private readonly TimeclockContext _context;

        public StaffController( TimeclockContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get staff list
        /// </summary>
        /// <returns>StaffMemberDto list</returns>
        [HttpGet]
        public async Task<IEnumerable<StaffMemberDto>> GetStaffsAsync()
        {
            return await _context.StaffMembers.OrderBy(e => e.Name).Select(e => e.ToStaffMemberDto()).ToListAsync();
        }

        /// <summary>
        /// Get a staff information
        /// </summary>
        /// <param name="id">the staff's id</param>
        /// <returns>StaffMemberDto</returns>
        [HttpGet("{id}", Name = nameof(GetStaffAsync))]
        public async Task<IActionResult> GetStaffAsync(Guid id)
        {
            //Guid guid = Guid.Parse(id);
                
            StaffMember staffMember = await _context.StaffMembers.Include(e => e.Timesheets).Where(e => e.Id == id).FirstOrDefaultAsync();

            return staffMember == null ? NotFound() : Ok(staffMember.ToStaffMemberDto());
        }

        /// <summary>
        /// Add a staff
        /// </summary>
        /// <param name="staffMemberDto">StaffMemberDto</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddStaffMemberAsync(StaffMemberDto staffMemberDto)
        {
            StaffMember newStaffMember = newStaffMember = staffMemberDto.ToStaffMember();

            await _context.StaffMembers.AddAsync(newStaffMember);
            await _context.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetStaffAsync), new { Id = newStaffMember.Id }, newStaffMember.ToStaffMemberDto());
        }
    }
}
