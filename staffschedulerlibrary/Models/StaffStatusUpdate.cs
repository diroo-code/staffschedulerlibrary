using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace staffschedulerlibrary.Models
{
    public class StaffStatusUpdate : RealTimeStatusUpdate
    {
        // Additional property for staff-specific status updates
        public Staff AssignedStaff { get; set; }

        // Constructor to initialize status update with status ID, shift, staff, and status
        public StaffStatusUpdate(int statusId, Shift assignedShift, Staff assignedStaff, string status)
            : base(statusId, assignedShift, status)
        {
            AssignedStaff = assignedStaff; // Initialize the specific staff member for this update
        }

        // Override UpdateStatus to implement staff-specific update logic
        public override void UpdateStatus()
        {
            // Staff-specific logic for status update
            Console.WriteLine($"Staff {AssignedStaff.Name} status updated to: {Status} for shift {Shift.ShiftId} at {UpdateTime}");
        }
    }

}
