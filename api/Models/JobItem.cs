using System;

namespace ServerManagementSystem.Models
{
    public class JobItem
    {
        public Type DataType { get; set; }
        public string DataModel { get; set; }
        public string DataName { get; set; }
        public string DataToQuery { get; set; }
    }
}
