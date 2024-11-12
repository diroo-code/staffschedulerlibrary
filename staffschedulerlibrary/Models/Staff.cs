using System.Collections.Generic;
using staffschedulerlibrary.Models;
using Google.Cloud.Firestore;

namespace staffschedulerlibrary.Models
{
    [FirestoreData]
    public class Staff
    {
        [FirestoreProperty]
        public int Id { get; set; }

        [FirestoreProperty]
        public string Name { get; set; }

        [FirestoreProperty]
        public string Position { get; set; }

        [FirestoreProperty]
        public List<TaskAllocation> TaskAllocations { get; set; }

        [FirestoreProperty]
        public List<ShiftAssignment> ShiftAssignments { get; set; }
        public object Availability { get; set; }

        public Staff()
        {
            TaskAllocations = new List<TaskAllocation>();
            ShiftAssignments = new List<ShiftAssignment>();
        }
        public void AssignToShift(Shift shift)
        {
            var assignment = new ShiftAssignment(this, shift);
            ShiftAssignments.Add(assignment);
            shift.AddStaff(this);
        }
    }
}
