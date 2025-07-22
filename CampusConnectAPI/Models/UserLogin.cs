using System.ComponentModel.DataAnnotations;

namespace CampusConnectAPI.Models
{
    public class UserLogin
    {
        [Key]
        public  Guid LoginId {  get; set; }
        public Guid UserId {  get; set; }
        public DateTime LoginTime { get; set; }
        public string IpAddress {  get; set; }
        
        public User User { get; set; }
    }
}
