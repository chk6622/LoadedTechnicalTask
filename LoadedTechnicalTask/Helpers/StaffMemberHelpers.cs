using LoadedTechnicalTask.Dto;
using LoadedTechnicalTask.Entities;
using System;
using System.Linq;

namespace LoadedTechnicalTask.Helpers
{
    public static class StaffMemberHelpers
    {
        /// <summary>
        /// Create a staffMemberDto object according to the StaffMember object.
        /// </summary>
        /// <param name="staffMember">StaffMember object</param>
        /// <returns>StaffMemberDto object</returns>
        public static StaffMemberDto ToStaffMemberDto(this StaffMember staffMember)
        {
            return new StaffMemberDto()
            {
                Id = staffMember.Id,
                Name = staffMember.Name,
                Timesheets = staffMember.Timesheets.Select(e => e.ToTimesheetDto()).ToList<TimesheetDto>()
            };
        }

        /// <summary>
        /// Create a staffMember object according to the StaffMemberDto object.
        /// </summary>
        /// <param name="staffMemberDto">StaffMemberDto object</param>
        /// <returns>StaffMember object</returns>
        public static StaffMember ToStaffMember(this StaffMemberDto staffMemberDto)
        {
            return new StaffMember()
            {
                Id = staffMemberDto.Id,
                Name = staffMemberDto.Name,
                Timesheets = staffMemberDto.Timesheets.Select(e => e.ToTimesheet()).ToList()
            };
        }
    }
}
