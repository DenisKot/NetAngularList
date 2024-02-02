using System;
using System.ComponentModel.DataAnnotations;

namespace NetAngularList.Domain
{
    public class ClientInfo
    {
        [Key]
        public int NumberInLine { get; set; }
        public ClientInfoState State { get; set; }
        public string FullName { get; set; }
        public DateTimeOffset CheckInTime { get; set; }
    }
}
