using System.Collections.Generic;
using System.Linq;
using Google.Cloud.Firestore;

namespace staffschedulerlibrary.Models
{
    [FirestoreData]
    public class StaffList
    {
        [FirestoreProperty]
        public List<Staff> StaffMembers { get; private set; }

        public StaffList()
        {
            StaffMembers = new List<Staff>();
        }

        public void AddStaff(Staff staff)
        {
            StaffMembers.Add(staff);
        }

        public Staff GetStaff(int id)
        {
            return StaffMembers.FirstOrDefault(s => s.Id == id);
        }
    }
}
