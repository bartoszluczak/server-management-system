namespace ServerManagementSystem.Models
{
    public class RedisDataModel
    {
        public string TimeStamp { get; set; }
        public string KeyName { get; set; }
        public object Data { get; set; }
    }
}
