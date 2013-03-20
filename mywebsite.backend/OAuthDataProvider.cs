//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using DotNetOpenAuth.AspNet;
//using Raven.Client;

//namespace mywebsite.backend
//{
//    public class OAuthDataProvider : IOpenAuthDataProvider
//    {
//        private readonly IDocumentSession _docSession;

//        public OAuthDataProvider(IDocumentSession docSession)
//        {
//            _docSession = docSession;
//        }

//        public string GetUserNameFromOpenAuth(string openAuthProvider, string openAuthId)
//        {
//            var oid = _docSession.Query<OAuthIdentity>().FirstOrDefault(i => i.Provider == openAuthProvider && i.ProviderUserId == openAuthId);

//            if (oid == null)
//            {
//                return null;
//            }

//            var profile = _docSession.Load<Profile>(oid.ProfileId);
//            if (profile == null)
//            {
//                return null;
//            }

//            return profile.UniqueName;
//        }
//    }
//}
