using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Type;

namespace staffschedulerlibrary.Models
{
    public class ShiftStatusUpdate : RealTimeStatusUpdate
    {
        // Constructor for ShiftStatusUpdate, passing values to the base class constructor
        public ShiftStatusUpdate(int statusId, Shift assignedShift, string status)
            : base(statusId, assignedShift, status)
        {
        }

        // Override UpdateStatus to implement shift-specific logic
        public override void UpdateStatus()
        {
            // For example, we might want to log that the shift status has been updated.
            Console.WriteLine($"Shift {Shift.ShiftId} status updated to: {Status} for staff {Staff.Name} at {UpdateTime}");
        }
    }

}
