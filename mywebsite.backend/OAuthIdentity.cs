using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mywebsite.backend
{
    public class OAuthIdentity
    {
        public int Id { get; set; }
        public string Provider { get; set; }
        public string ProviderUserId { get; set; }
        public int ProfileId { get; set; }

    }
}
