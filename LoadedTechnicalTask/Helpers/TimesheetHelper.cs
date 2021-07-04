using LoadedTechnicalTask.Dto;
using LoadedTechnicalTask.Entities;
using System;
using System.Globalization;

namespace LoadedTechnicalTask.Helpers
{
    public static class TimesheetHelper
    {
        private const string TIME_FORMAT = "MM/dd/yyyy HH:mm:ss";

        /// <summary>
        /// Create a TimesheetDto object according to the Timesheet object 
        /// </summary>
        /// <param name="timesheet">Timesheet object</param>
        /// <returns>TimesheetDto object</returns>
        public static TimesheetDto ToTimesheetDto(this Timesheet timesheet)
        {
            return new TimesheetDto()
            {
                Id = timesheet.Id.ToString(),
                ClockOut = timesheet.ClockOut?.ToString(TIME_FORMAT, CultureInfo.InvariantCulture),
                ClockIn = timesheet.ClockIn.ToString(TIME_FORMAT, CultureInfo.InvariantCulture)
            };
        }

        /// <summary>
        /// Create a Timesheet object according to the TimesheetDto object 
        /// </summary>
        /// <param name="timesheetDto">TimesheetDto object</param>
        /// <returns>timesheet object</returns>
        public static Timesheet ToTimesheet(this TimesheetDto timesheetDto)
        {
            return new Timesheet()
            {
                Id = string.IsNullOrWhiteSpace(timesheetDto.Id) ? Guid.NewGuid() : Guid.Parse(timesheetDto.Id),
                ClockOut = DateTimeOffset.ParseExact(timesheetDto.ClockOut, TIME_FORMAT, CultureInfo.InvariantCulture),
                ClockIn = DateTimeOffset.ParseExact(timesheetDto.ClockIn, TIME_FORMAT, CultureInfo.InvariantCulture)
            };
        }
    }
}
