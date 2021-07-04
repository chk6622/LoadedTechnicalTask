using System;
using System.ComponentModel.DataAnnotations;

namespace LoadedTechnicalTask.Dto
{
    /// <summary>
    /// Timesheet data transfer object
    /// </summary>
    public class TimesheetDto
    {
        /// <summary>
        /// A unique identifier for this timesheet
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// The time that the staff member clocked in for this shift
        /// </summary>
        [Required]
        public string ClockIn { get; set; }

        /// <summary>
        /// The time that the staff member clocked out for this shift
        /// </summary>
        [Required]
        public string ClockOut { get; set; }
    }
}
