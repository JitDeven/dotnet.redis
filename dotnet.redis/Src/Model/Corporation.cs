using System;

namespace dotnet.redis.Model
{
    public class Corporation
    {
        public Corporation()
        {
            CreateTime = DateTime.Now;
        }

        public string UniqueCode { get; set; }

        public string OrgName { get; set; }
        public string Address { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
