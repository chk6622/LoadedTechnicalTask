using System.Collections.Generic;

namespace LoadedTechnicalTask.Dto
{
    /// <summary>
    /// Staff member data transfer object
    /// </summary>
    public class StaffMemberDto
    {
        /// <summary>
        /// A unique identifier for this staff member
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// This staff member's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This staff member's timesheets
        /// </summary>
        public IList<TimesheetDto> Timesheets { get; set; } = new List<TimesheetDto>();
    }
}
