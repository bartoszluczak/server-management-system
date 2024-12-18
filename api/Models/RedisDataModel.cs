﻿using System.Collections.Generic;

namespace ServerManagementSystem.Models
{
    public class RedisDataModel<T>
    {
        public string TimeStamp { get; set; }
        public string KeyName { get; set; }
        public List<T> Data { get; set; }
    }
}
