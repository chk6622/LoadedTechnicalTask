using System;
using System.Collections.Generic;

namespace LoadedTechnicalTask.Entities
{
    /// <summary>
    /// The details of a staff member.
    /// </summary>
    public class StaffMember
    {
        /// <summary>
        /// A unique identifier for this staff member
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// This staff member's name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// This staff member's timesheets
        /// </summary>
        public IList<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
    }
}
