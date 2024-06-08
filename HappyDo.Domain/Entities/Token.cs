using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HappyDo.Domain.Entities
{
    public class Token
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        public bool IsExpired { get; set; }
        public DateTime ExpirationRefreshToken { get; set; }
        public DateTime ExpirationToken { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime? DateUpdate { get; set; }

    }
}
