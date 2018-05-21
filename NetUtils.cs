using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Net;
using System.Text;

namespace inteGREAT.Utility
{
    /// <summary>
    /// Network Utility class.
    /// </summary>
    public sealed class NetUtils
    {
        /// <summary>
        /// Determines whether [is valid user] [the specified user name].
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The password.</param>
        /// <param name="domain">The domain.</param>
        /// <returns></returns>
        public static bool IsValidUser(string userName, string password, string domain)
        {
			// Just added a comment another update and here another one too
            bool valid = false;

            try
            {
                if (string.IsNullOrEmpty(domain))
                {
                    using (PrincipalContext context = new PrincipalContext(ContextType.Machine, "127.0.0.1"))
                    {
                        valid = context.ValidateCredentials(userName, password);
                    }
                }
                else
                {
                    using (PrincipalContext context = new PrincipalContext(ContextType.Domain, domain))
                    {
                        valid = context.ValidateCredentials(userName, password);
                    }
                }
            }
            catch (Exception err)
            {}

            return valid;
        }
    }
}
