using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace mywebsite.backend
{
    public class Profile
    {
        private IList<OAuthIdentity> _oAuthIdentities;
        public int Id { get; set; }
        /// <summary>
        /// the profile's display name for the site
        /// </summary>

        [Required]
        public string DisplayName { get; set; }
        
        [System.ComponentModel.DataAnnotations.EmailAddress]
        public string EmailAddress { get; set; }

        public string Location { get; set; }

        [Raven.Imports.Newtonsoft.Json.JsonIgnore]
        public bool IsGuest { get; set; }

        [Raven.Imports.Newtonsoft.Json.JsonIgnore]
        public IList<OAuthIdentity> OAuthIdentities
        {
            get { return _oAuthIdentities ?? (_oAuthIdentities = new List<OAuthIdentity>()); }
            set { _oAuthIdentities = value; }
        }

        internal static Profile GuestProfile()
        {
            return new Profile() {IsGuest = true, DisplayName = "Friend"};
        }
    }
}
