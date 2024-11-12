using Google.Cloud.Firestore;

namespace staffschedulerlibrary.Models

{
    [FirestoreData]
    public class TaskAllocation
    {
        [FirestoreProperty]
        public int TaskId { get; set; }

        [FirestoreProperty]
        public string TaskName { get; set; }

        [FirestoreProperty]
        public Staff AssignedStaff { get; set; }

        public void AssignTask(Staff staff)
        {
            AssignedStaff = staff;
        }
    }
}
