using System;

namespace LoadedTechnicalTask.Entities
{
    public class Timesheet
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public DateTimeOffset ClockIn { get; set; }

        public DateTimeOffset? ClockOut { get; set; }

        public StaffMember StaffMember { get; set; }
        public Guid StaffMemberId { get; set; }
    }
}
