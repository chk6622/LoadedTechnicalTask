using System;
using System.Collections.Generic;

namespace LoadedTechnicalTask.Entities
{
    public class StaffMember
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public IList<Timesheet> Timesheets { get; set; } = new List<Timesheet>();
    }
}
