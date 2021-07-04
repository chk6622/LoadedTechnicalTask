using LoadedTechnicalTask.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        /// <summary>
        /// Get staff list
        /// </summary>
        /// <returns>StaffMemberDto list</returns>
        [HttpGet]
        public async Task<IEnumerable<StaffMemberDto>> GetStaffsAsync()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get a staff information
        /// </summary>
        /// <param name="id">the staff's id</param>
        /// <returns>StaffMemberDto</returns>
        [HttpGet("{id}", Name = nameof(GetStaffAsync))]
        public async Task<IActionResult> GetStaffAsync(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Add a staff
        /// </summary>
        /// <param name="staffMemberDto">StaffMemberDto</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddStaffMemberAsync(StaffMemberDto staffMemberDto)
        {
            throw new NotImplementedException();
        }
    }
}
