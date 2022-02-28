using System.Collections.Generic;

namespace ServerManagementSystem.Models
{
    public class RedisDataModelGraphql
    {
        public string TimeStamp { get; set; }
        public string KeyName { get; set; }
        public List<BiosDetails> Data { get; set; }
    }
}
