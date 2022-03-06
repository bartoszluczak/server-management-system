using System.Collections.Generic;
using System;

namespace ServerManagementSystem.Models
{
    public class JobsList
    {
        public JobsList()
        {
           List<JobItem> AllJobsList = new List<JobItem>();

            AllJobsList.Add(new JobItem() { DataType = Type.GetType("ServerManagementSystem.Models.BiosDetails"), DataName = "BiosDetails", DataModel = "ServerManagementSystem.Models.BiosDetails", DataToQuery ="Win32_BIOS" });
        }
    }
}
