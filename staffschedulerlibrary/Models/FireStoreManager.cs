using Google.Cloud.Firestore;
using System;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;
using FirebaseAdmin;


namespace staffschedulerlibrary.Models
{
    public class FirestoreManager
    {
        private FirestoreDb _firestoreDb;
        private const string firebase_key = "scheduler-dc971";



        // Initialize FirestoreManager with Firebase project ID and credentials
        public void InitFireStore()
        {
            FirebaseApp.Create();
            _firestoreDb = FirestoreDb.Create(firebase_key);
            Console.WriteLine("Created Cloud Firestore client with project ID: {0}", firebase_key);
        }
        // Save staff data to Firestore
        public async Task SaveStaffAsync(Staff staff)
        {
            DocumentReference docRef = _firestoreDb.Collection("staff").Document(staff.Id.ToString());
            await docRef.SetAsync(staff);
        }

        // Retrieve staff data from Firestore
        public async Task<List<Staff>> GetAllStaffAsync()
        {
            var staffCollection = _firestoreDb.Collection("staff");
            var snapshot = await staffCollection.GetSnapshotAsync();
            var staffList = new List<Staff>();

            foreach (var document in snapshot.Documents)
            {
                var staff = document.ConvertTo<Staff>(); // Convert Firestore document to Staff object
                staffList.Add(staff);
            }

            return staffList;
        }

        // Save shift data to Firestore
        public async Task SaveShiftAsync(Shift shift)
        {
            // Ensure you use the correct collection name
            DocumentReference docRef = _firestoreDb.Collection("shifts").Document(shift.ShiftId.ToString());
            await docRef.SetAsync(shift); // Save the shift object to Firestore
        }

        // Retrieve shift data from Firestore
        public async Task<List<Shift>> GetAllShiftAsync()
        {
            var shiftCollection = _firestoreDb.Collection("shifts");
            var snapshot = await shiftCollection.GetSnapshotAsync();
            var shiftList = new List<Shift>();

            foreach (var document in snapshot.Documents)
            {
                var shift = document.ConvertTo<Shift>(); // Convert Firestore document to Shift object
                shiftList.Add(shift);
            }

            return shiftList;
        }

        // Method to save TaskAllocation to Firestore
        public async Task SaveTaskAsync(TaskAllocation taskAllocation)
        {
            DocumentReference docRef = _firestoreDb.Collection("taskAllocations").Document(taskAllocation.TaskId.ToString());
            await docRef.SetAsync(taskAllocation); // Save the TaskAllocation object to Firestore
        }

        // Method to retrieve all TaskAllocations from Firestore
        public async Task<List<TaskAllocation>> GetAllTasksAsync()
        {
            var taskCollection = _firestoreDb.Collection("taskAllocations");
            var snapshot = await taskCollection.GetSnapshotAsync();
            var taskList = new List<TaskAllocation>();

            foreach (var document in snapshot.Documents)
            {
                var taskAllocation = document.ConvertTo<TaskAllocation>(); // Convert Firestore document to TaskAllocation object
                taskList.Add(taskAllocation);
            }

            return taskList;
        }

    }
}
