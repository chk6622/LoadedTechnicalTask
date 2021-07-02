using LoadedTechnicalTask.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace LoadedTechnicalTask
{
    /// <summary>
    /// Generates database seed data.
    /// </summary>
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new TimeclockContext(serviceProvider.GetRequiredService<DbContextOptions<TimeclockContext>>());
            var alice = new StaffMember
            {
                Name = "Alice",
            };

            var bobTimesheet = new Timesheet()
            {
                ClockIn = new DateTimeOffset(DateTime.Today).AddHours(9),
            };
            var bob = new StaffMember
            {
                Name = "Bob",
                Timesheets = new[] { bobTimesheet }
            };

            var charlie = new StaffMember
            {
                Name = "Charlie",
            };

            context.StaffMembers.AddRange(alice, bob, charlie);
            context.Timesheets.Add(bobTimesheet);

            context.SaveChanges();
        }
    }
}
