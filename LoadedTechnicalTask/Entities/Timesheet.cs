using System;

namespace LoadedTechnicalTask.Entities
{
    /// <summary>
    /// Records the time worked for a staff member's shift
    /// </summary>
    public class Timesheet
    {
        /// <summary>
        /// A unique identifier for this timesheet
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// The time that the staff member clocked in for this shift
        /// </summary>
        public DateTimeOffset ClockIn { get; set; }

        /// <summary>
        /// The time that the staff member clocked out for this shift
        /// </summary>
        public DateTimeOffset? ClockOut { get; set; }

        /// <summary>
        /// The staff member who worked this shift
        /// </summary>
        public StaffMember StaffMember { get; set; }

        /// <summary>
        /// The unique identifier for the staff member who worked this shift
        /// </summary>
        public Guid StaffMemberId { get; set; }
    }
}
