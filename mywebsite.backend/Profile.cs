using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mywebsite.backend
{
    public class Profile
    {
        public int Id { get; set; }
        /// <summary>
        /// the profile's display name for the site
        /// </summary>
        public string DisplayName { get; set; }

        public string EmailAddress { get; set; }

        public string Location { get; set; }

        /// <summary>
        /// a system generated unique name for this profile.
        /// </summary>
        public string UniqueName { get; set; }

        [Newtonsoft.Json.JsonIgnore]
        public IList<OAuthIdentity> OAuthIdentities { get; set; } 

    }
}
