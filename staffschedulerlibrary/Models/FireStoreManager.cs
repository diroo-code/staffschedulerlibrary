using Google.Cloud.Firestore;
using System;
using System.Threading.Tasks;
using Google.Protobuf.WellKnownTypes;

namespace staffschedulerlibrary.Models
{
    public class FirestoreManager
    {
        private FirestoreDb _firestoreDb;

        public FirestoreManager(string projectId, string credentialsFilePath)
        {

            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", credentialsFilePath);
            _firestoreDb = FirestoreDb.Create(projectId);
            Console.WriteLine("Connected to Firestore");
        }

        // Save staff data to Firestore
        public async Task SaveStaffAsync(Staff staff)
        {
            DocumentReference docRef = _firestoreDb.Collection("staff").Document(staff.Id.ToString());
            await docRef.SetAsync(staff);
        }

        // Retrieve staff data from Firestore
        public async Task<Staff> GetStaffAsync(int staffId)
        {
            DocumentReference docRef = _firestoreDb.Collection("staff").Document(staffId.ToString());
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                return snapshot.ConvertTo<Staff>();
            }

            return null;
        }

        // Save shift data to Firestore
        public async Task SaveShiftAsync(Shift shift)
        {
            CollectionReference collection = _firestoreDb.Collection("shifts");
            DocumentReference document = collection.Document(shift.ShiftId.ToString());

            WriteResult writeResult = await document.SetAsync(shift);
            Console.WriteLine($"Saved Shift ID {shift.ShiftId} to Firestore.");
        }

        // Retrieve shift data from Firestore
        public async Task<Shift> GetShiftAsync(int shiftId)
        {
            DocumentReference docRef = _firestoreDb.Collection("shifts").Document(shiftId.ToString());
            DocumentSnapshot snapshot = await docRef.GetSnapshotAsync();

            if (snapshot.Exists)
            {
                return snapshot.ConvertTo<Shift>();
            }

            return null;
        }
    }
}
