My assumptions:
1. Staff cannot clock in twice in a row. 
2. Staff cannot clock out before clocking in.
3. In one timesheet, the time of clocking out cannot earlier the clocking in.
4. Because business logic is simple, I decide to write business logic in the controller. In the future, if the business logic becomes complex, I will move them to the service layer. 

Api:
Add a staff: Post http://host_ip:5000/Staff
Get a staff list: Get http://host_ip:5000/Staff
Get a staff: Get http://host_ip:5000/Staff/staff_id

Get a timesheet: Get http://host_ip:5000/Timesheet/timesheet_id
Clock in: Post http://host_ip:5000/Timesheet/ClockIn/staff_id
Clock out: Post http://host_ip:5000/Timesheet/ClockOut/staff_id
Update a timesheet: Put http://host_ip:5000/Timesheet