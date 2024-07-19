using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Ragnarok
{
    public class LoginEntity
    {
        [Key]
        public int account_id { get; set; }
        public string userid { get; set; }
        public string user_pass { get; set; }
        public sex sex { get; set; }
        public string email { get; set; }
        public int group_id { get; set; }
        public int state { get; set; }
        public int unban_time { get; set; }
        public int expiration_time { get; set; }
        public int logincount { get; set; }
        public DateTime lastlogin { get; set; }
        public string last_ip { get; set; }
        public DateTime birthdate { get; set; }
        public int character_slots { get; set; }
        public int pincode { get; set; }
        public int pincode_change { get; set; }
        public int vip_time { get; set; }
        public int old_group { get; set; }
        public int web_auth_token { get; set; }
        public int web_auth_token_enabled { get; set; }
    }

    public enum sex
    {
        M,
        F,
        S
    }
}
