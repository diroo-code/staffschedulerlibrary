using System;
using Google.Cloud.Firestore;
using Google.Type;

namespace staffschedulerlibrary.Models
{
    [FirestoreData]
    public class RealTimeStatusUpdate
    {
        public int StatusId { get; set; }
        public Staff Staff { get; set; }
        public Shift Shift { get; set; }
        public string Status { get; set; }
        public System.DateTime UpdateTime { get; set; }

        // Constructor to initialize status update with status ID, staff, shift, and status
        public RealTimeStatusUpdate(int statusId, Shift shift, string status)
        {
            StatusId = statusId;
            Shift = shift;
            Status = status;
            UpdateTime = System.DateTime.Now;
            Staff = shift.Staff; // Assuming each shift has a staff assigned
        }

        // Method to display the status update details
        public string GetStatus()
        {
            return $"{Staff.Name} is currently {Status} during shift {Shift.ShiftId} as of {UpdateTime}.";
        }

        // Virtual method to update the status. Can be overridden in derived classes.
        public virtual void UpdateStatus()
        {
            // Default status update logic, can be overridden.
            Console.WriteLine("Status updated to: " + Status);
        }
    }

}
